using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace API_Testing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DayController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public DayController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"SELECT  *   FROM    tbl_Day";
            DataTable dt = new DataTable();
            SqlDataReader sqlDataReader;
            using (SqlConnection myCon = new SqlConnection(_configuration.GetConnectionString("AttendanceAppCon")))
            {
                myCon.Open();
                using (SqlCommand sc = new SqlCommand(query, myCon))
                {
                    sqlDataReader = sc.ExecuteReader();
                    dt.Load(sqlDataReader);
                    sqlDataReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult(dt);

        }


    }
}

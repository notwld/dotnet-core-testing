using API_Testing.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class TimeSlotController : ControllerBase
    {
        [HttpGet]
        public JsonResult Get()
        {
            SqlCommand sc = new SqlCommand("Select * from tbl_TimeSlot where Status='1'", Connection.GetSqlConnection());
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(sc);
            sda.Fill(dt);
            return new JsonResult(dt);
        }
        [HttpPost]
        public JsonResult Post(TimeSlot timeSlot)
        {
            SqlCommand sc = new SqlCommand(@"INSERT INTO tbl_TimeSlot VALUES(@TSCode,@StartTime,@EndTime,'1')", Connection.GetSqlConnection());
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(sc);
            sc.Parameters.AddWithValue("@TSCode", timeSlot.TSCode);
            sc.Parameters.AddWithValue("@StartTime", timeSlot.StartTime);
            sc.Parameters.AddWithValue("@EndTime", timeSlot.EndTime);
            sc.ExecuteNonQuery();
            return new JsonResult("TimeSlot Added!");
        }
        [HttpPut]
        public JsonResult Put(TimeSlot timeSlot)
        {
            SqlCommand sc = new SqlCommand(@"Update tbl_TimeSlot SET TSCode=@TSCode, StartTime=@StartTime,EndTime=@EndTime where TSID=@TSID", Connection.GetSqlConnection());
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(sc);
            sc.Parameters.AddWithValue("@TSCode", timeSlot.TSCode);
            sc.Parameters.AddWithValue("@StartTime", timeSlot.StartTime);
            sc.Parameters.AddWithValue("@EndTime", timeSlot.EndTime);
            sc.Parameters.AddWithValue("@TSId", timeSlot.TSId);
            sc.ExecuteNonQuery();
            return new JsonResult("TimeSlot Update");
        }
        [HttpDelete]
        public JsonResult Delete(TimeSlot timeSlot)
        {
            SqlCommand sc = new SqlCommand(@"Update tbl_TimeSlot SET Status='0' where TSId=@TSId", Connection.GetSqlConnection());
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(sc);
            sc.Parameters.AddWithValue("@TSId", timeSlot.TSId);
            sc.ExecuteNonQuery();
            return new JsonResult("TimeSlot Deleted!");
        }


    }
}

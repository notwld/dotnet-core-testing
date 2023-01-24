using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using API_Testing.Models;
using Microsoft.Extensions.Configuration;

namespace API_Testing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeSlotController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public TimeSlotController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"SELECT  *   FROM    tbl_TimeSlot INNER JOIN  tbl_Room ON tbl_TimeSlot.RoomId=tbl_Room.RoomId WHERE Status = 1 ORDER BY 1 DESC";
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

        [HttpPost]
        public JsonResult Post(TimeSlot timeSlot)
        {
            string query = @"INSERT INTO tbl_TimeSlot VALUES(@TSCode, @StartTime, @EndTime,@RoomId, 1)";
            DataTable dt = new DataTable();
            SqlDataReader sqlDataReader;
            using (SqlConnection myCon = new SqlConnection(_configuration.GetConnectionString("AttendanceAppCon")))
            {
                myCon.Open();
                using (SqlCommand sc = new SqlCommand(query, myCon))
                {
                    sc.Parameters.AddWithValue("@TSCode", timeSlot.TSCode);
                    sc.Parameters.AddWithValue("@StartTime", timeSlot.StartTime);
                    sc.Parameters.AddWithValue("@EndTime", timeSlot.EndTime);
                    sc.Parameters.AddWithValue("@RoomId", timeSlot.RoomId);
                    sqlDataReader = sc.ExecuteReader();
                    dt.Load(sqlDataReader);
                    sqlDataReader.Close();
                    myCon.Close();
                }
            }
            //SqlCommand sc = new SqlCommand(query, Connection.GetSqlConnection());
            //sc.ExecuteNonQuery();
            return new JsonResult("TimeSlot Added Successfully");
        }

        [HttpPut]
        public JsonResult Put(TimeSlot timeSlot)
        {
            string query = @"UPDATE tbl_TimeSlot 
                            SET TSCode = @TSCode, 
                                StartTime = @StartTime, 
                                EndTime = @EndTime
                            WHERE TSId = @TSId";
            //SqlCommand sc = new SqlCommand(query, Connection.GetSqlConnection());
            //sc.Parameters.AddWithValue("@TSCode", timeSlot.TSCode);
            //sc.Parameters.AddWithValue("@StartTime", timeSlot.StartTime);
            //sc.Parameters.AddWithValue("@EndTime", timeSlot.EndTime);
            //sc.Parameters.AddWithValue("@TSId", timeSlot.TSId);
            //sc.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataReader sqlDataReader;
            using (SqlConnection myCon = new SqlConnection(_configuration.GetConnectionString("AttendanceAppCon")))
            {
                myCon.Open();
                using (SqlCommand sc = new SqlCommand(query, myCon))
                {
                    sc.Parameters.AddWithValue("@TSCode", timeSlot.TSCode);
                    sc.Parameters.AddWithValue("@StartTime", timeSlot.StartTime);
                    sc.Parameters.AddWithValue("@EndTime", timeSlot.EndTime);
                    sc.Parameters.AddWithValue("@TSId", timeSlot.TSId);
                    sqlDataReader = sc.ExecuteReader();
                    dt.Load(sqlDataReader);
                    sqlDataReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("TimeSlot Updated Successfully");
        }

        [HttpDelete]
        public JsonResult Delete(TimeSlot timeSlot)
        {
            string query = @"UPDATE tbl_TimeSlot SET Status = 0 WHERE TSId = @TSId";
            //SqlCommand sc = new SqlCommand(query, Connection.GetSqlConnection());
            //sc.Parameters.AddWithValue("@TSId", timeSlot.TSId);
            //sc.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataReader sqlDataReader;
            using (SqlConnection myCon = new SqlConnection(_configuration.GetConnectionString("AttendanceAppCon")))
            {
                myCon.Open();
                using (SqlCommand sc = new SqlCommand(query, myCon))
                {
                    sc.Parameters.AddWithValue("@TSId", timeSlot.TSId);
                    sqlDataReader = sc.ExecuteReader();
                    dt.Load(sqlDataReader);
                    sqlDataReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("TimeSlot Deleted Successfully");
        }
    }
}

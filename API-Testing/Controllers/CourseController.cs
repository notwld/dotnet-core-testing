using API_Testing.Models;
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
    public class CourseController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public CourseController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"SELECT  *   FROM    tbl_Course ORDER BY 1 DESC";
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
        public JsonResult Post(Course course)
        {
            string query = @"INSERT INTO tbl_Course VALUES(@CourseCode, @CourseName, @CourseShortName)";
            DataTable dt = new DataTable();
            SqlDataReader sqlDataReader;
            using (SqlConnection myCon = new SqlConnection(_configuration.GetConnectionString("AttendanceAppCon")))
            {
                myCon.Open();
                using (SqlCommand sc = new SqlCommand(query, myCon))
                {
                    sc.Parameters.AddWithValue("@CourseCode", course.CourseCode);
                    sc.Parameters.AddWithValue("@CourseName", course.CourseName);
                    sc.Parameters.AddWithValue("@CourseShortName", course.CourseShortName);
                    sqlDataReader = sc.ExecuteReader();
                    dt.Load(sqlDataReader);
                    sqlDataReader.Close();
                    myCon.Close();
                }
            }
            //SqlCommand sc = new SqlCommand(query, Connection.GetSqlConnection());
            //sc.ExecuteNonQuery();
            return new JsonResult("Course Added Successfully");
        }

        [HttpPut]
        public JsonResult Put(Course course)
        {
            string query = @"UPDATE tbl_Course 
                            SET CourseCode = @CourseCode, 
                                CourseName = @CourseName, 
                                CourseShortName = @CourseShortName
                            WHERE CourseId = @CourseId";
            //SqlCommand sc = new SqlCommand(query, Connection.GetSqlConnection());
            //sc.Parameters.AddWithValue("@CourseCode", course.CourseCode);
            //sc.Parameters.AddWithValue("@CourseName", course.CourseName);
            //sc.Parameters.AddWithValue("@CourseShortName", course.CourseShortName);
            //sc.Parameters.AddWithValue("@CourseId", course.CourseId);
            //sc.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataReader sqlDataReader;
            using (SqlConnection myCon = new SqlConnection(_configuration.GetConnectionString("AttendanceAppCon")))
            {
                myCon.Open();
                using (SqlCommand sc = new SqlCommand(query, myCon))
                {
                    sc.Parameters.AddWithValue("@CourseCode", course.CourseCode);
                    sc.Parameters.AddWithValue("@CourseName", course.CourseName);
                    sc.Parameters.AddWithValue("@CourseShortName", course.CourseShortName);
                    sc.Parameters.AddWithValue("@CourseId", course.CourseId);
                    sqlDataReader = sc.ExecuteReader();
                    dt.Load(sqlDataReader);
                    sqlDataReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Course Updated Successfully");
        }

        [HttpDelete]
        public JsonResult Delete(Course course)
        {
            string query = @"Delete from tbl_Course where CourseId = @CourseId";
            //SqlCommand sc = new SqlCommand(query, Connection.GetSqlConnection());
            //sc.Parameters.AddWithValue("@CourseId", course.CourseId);
            //sc.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataReader sqlDataReader;
            using (SqlConnection myCon = new SqlConnection(_configuration.GetConnectionString("AttendanceAppCon")))
            {
                myCon.Open();
                using (SqlCommand sc = new SqlCommand(query, myCon))
                {
                    sc.Parameters.AddWithValue("@CourseId", course.CourseId);
                    sqlDataReader = sc.ExecuteReader();
                    dt.Load(sqlDataReader);
                    sqlDataReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Course Deleted Successfully");
        }
    }
}

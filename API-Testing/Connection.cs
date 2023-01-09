using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace API_Testing
{
    public class Connection
    {
        public static SqlConnection sqlConnection;
        public static SqlConnection GetSqlConnection()
        {
            if (sqlConnection == null)
            {
                sqlConnection = new SqlConnection();
                sqlConnection.ConnectionString = @"Data Source=CL2-13\SQLEXPRESS; Initial Catalog=InstituteAttendenceSystem;User=sa;Password=UIT12345";
                sqlConnection.Open();

            }
            return sqlConnection;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeStatusTestMVC
{
    public static class Database
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
        private static SqlConnection connection;
        

        public static SqlConnection GetConnection()
        {
            if (connection == null)
            {
                connection = new SqlConnection(connectionString);
            }

            return connection;
        }

        
    }
}

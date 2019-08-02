using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public static class Database
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        private static SqlConnection connection;


        public static SqlConnection GetConnection()
        {
            connection = new SqlConnection(connectionString);
            if (connection == null)
            {
                connection = new SqlConnection(connectionString);
            }

            return connection;
        }
    }
}

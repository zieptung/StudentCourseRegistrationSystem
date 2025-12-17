using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCourseRegistrationSystem
{
    internal class ConnectDB
    {
        private static string connectionString =
        @"Data Source=DIEPTUNG\SQLEXPRESS;
              Initial Catalog=QLTC;
              Integrated Security=True";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}

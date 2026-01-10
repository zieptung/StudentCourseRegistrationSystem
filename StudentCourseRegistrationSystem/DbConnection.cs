using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StudentCourseRegistrationSystem
{
    internal static class DbConnection
    {
        private static readonly string connectionString = @"Server=DIEPTUNG\SQLEXPRESS;Database=QLTC;Trusted_Connection=True;TrustServerCertificate=True;";

        public static SqlConnection conn = new SqlConnection(connectionString);
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        public static bool CheckConnection()
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}

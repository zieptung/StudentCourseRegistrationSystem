using System;
using System.Data.SqlClient;

namespace StudentCourseRegistrationSystem
{
    internal static class DbConnection
    {
        // 🔹 CHUỖI KẾT NỐI – sửa cho đúng máy bạn
        private static readonly string connectionString =
            @"Data Source=localhost;
              Initial Catalog=QLTC;
              Integrated Security=True";

        // 🔹 LẤY KẾT NỐI
        public static SqlConnection GetConnection()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            return conn;
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

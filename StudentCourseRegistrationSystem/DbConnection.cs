using System.Data.SqlClient;

namespace StudentCourseRegistrationSystem
{
    internal static class DbConnection
    {
        // 1 dòng cho chắc, tránh lỗi do xuống dòng/space
        private static readonly string connectionString =
            @"Server=DIEPTUNG\SQLEXPRESS;Database=QLTC;Trusted_Connection=True;TrustServerCertificate=True;";

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

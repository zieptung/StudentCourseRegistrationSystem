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

        public static void ketnoi_dulieu(DataGridView DRV, String sql)
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmd.Dispose();
            conn.Close();
            DRV.DataSource = dt;
            DRV.Refresh();
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

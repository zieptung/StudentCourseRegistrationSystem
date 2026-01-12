using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StudentCourseRegistrationSystem
{
    internal static class DbConnection
    {
        private static readonly string connectionString = @"Server=PHAMHIEN;Database=QLTC;Trusted_Connection=True;TrustServerCertificate=True;";

        public static SqlConnection conn = new SqlConnection(connectionString);
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        public static void ketnoi(DataGridView dgv, string sql)
        {
            //b1: tạo kết nối db
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            //b2: tạo đối tượng command để thực thi câu lệnh sql
            SqlCommand cmd = new SqlCommand(sql, conn);
            //b3: tạo đối tượng dataadapter để đổ dữ liệu từ db vào dataset
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            //b4: tao doi tuong datatable de lay du lieu tu da
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmd.Dispose();
            conn.Close();
            //b5: đổ dữ liệu từ datatable vào datagridview
            dgv.DataSource = dt;
            dgv.Refresh();
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

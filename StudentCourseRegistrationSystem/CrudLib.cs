using System;
using System.Data;
using System.Data.SqlClient;

namespace StudentCourseRegistrationSystem
{
    internal class CrudLib
    {
        // THÊM / SỬA / XOÁ
        public static int IUDQuery(string sql)
        {
            try
            {
                using (SqlConnection conn = DbConnection.GetConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    return cmd.ExecuteNonQuery(); // số dòng bị ảnh hưởng
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi ExecuteNonQuery: " + ex.Message);
            }
        }

        // LẤY DỮ LIỆU / TÌM KIẾM
        public static DataTable GetDataTable(string sql)
        {
            try
            {
                using (SqlConnection conn = DbConnection.GetConnection())
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi ExecuteQuery: " + ex.Message);
            }
        }
        // LẤY 1 GIÁ TRỊ (COUNT, SUM…)
        public static object GetValue(string sql)
        {
            try
            {
                using (SqlConnection conn = DbConnection.GetConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    return cmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi ExecuteScalar: " + ex.Message);
            }
        }
    }
}
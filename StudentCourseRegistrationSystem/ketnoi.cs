using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace StudentCourseRegistrationSystem
{
    internal class ketnoi
    {
        public static SqlConnection conn = new SqlConnection("Data Source=laptop-4t6o4tn1\\sqlexpress;Initial Catalog=QLTC;Integrated Security=True");
        public static void ketnoi_dulieu(DataGridView DRV, String sql)
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            SqlCommand cmd = new SqlCommand(sql,conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmd.Dispose();
            conn.Close();
            DRV.DataSource = dt;
            DRV.Refresh();
        }           
     }
}


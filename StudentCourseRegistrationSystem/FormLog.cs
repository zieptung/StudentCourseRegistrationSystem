using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentCourseRegistrationSystem
{
    public partial class FormLog : Form
    {
        public FormLog()
        {
            InitializeComponent();
            this.Load += FormLog_Load;
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            string username = txtmsv.Text.Trim();
            string password = txtmk.Text.Trim();

            if (username == "" || password == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            using (SqlConnection conn = ConnectDB.GetConnection())
            {
                try
                {
                    conn.Open();

                    string sql = @"SELECT ma_vai_tro, ma_lien_ket
                       FROM TaiKhoan
                       WHERE ten_dang_nhap = @tenDangNhap
                         AND mat_khau = @matKhau";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@tenDangNhap", username);
                    cmd.Parameters.AddWithValue("@matKhau", password);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        string Vaitro = reader["ma_vai_tro"].ToString();
                        string Malienket = reader["ma_lien_ket"].ToString();

                        if (Vaitro == "SV")
                            new FormSV(Malienket).Show();
                        else if (Vaitro == "GV")
                            new FormGV(Malienket).Show();
                        else if (Vaitro == "AD")
                            new FormAdmin().Show();

                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Sai tài khoản hoặc mật khẩu!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void FormLog_Load(object sender, EventArgs e)
        {
        }

        private void txtmsv_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

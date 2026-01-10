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
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            string user = txtmsv.Text.Trim();
            string pass = txtmk.Text.Trim();

            if (user == "" || pass == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            try
            {
                using (SqlConnection conn = DbConnection.GetConnection())
                {
                    conn.Open();

                    string sql =
                        "SELECT vai_tro, ma_lien_ket " +
                        "FROM Admin " +
                        "WHERE username = '" + user + "' " +
                        "AND password = '" + pass + "' " +
                        "AND trang_thai = N'Hoạt động'";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataReader rd = cmd.ExecuteReader();

                    if (rd.Read() == false)
                    {
                        MessageBox.Show("Sai tài khoản hoặc mật khẩu!");
                        txtmk.Clear();
                        txtmk.Focus();
                        return;
                    }

                    string role = rd["vai_tro"].ToString();
                    string maLienKet = rd["ma_lien_ket"].ToString();

                    if (role == "AD")
                    {
                        FormAdmin f = new FormAdmin();
                        f.Show();
                    }
                    else if (role == "SV")
                    {
                        FormSV f = new FormSV(maLienKet);
                        f.Show();
                    }
                    else
                    {
                        MessageBox.Show("Vai trò không hợp lệ!");
                        return;
                    }

                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                 MessageBox.Show("Lỗi: " + ex.Message);
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

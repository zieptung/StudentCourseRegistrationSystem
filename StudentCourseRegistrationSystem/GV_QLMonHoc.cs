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
    public partial class GV_QLMonHoc : Form
    {
        string connectionString = @"Data Source=DIEPTUNG\SQLEXPRESS;Initial Catalog=QLTC;Integrated Security=True";

        public GV_QLMonHoc()
        {
            InitializeComponent();
        }

        private void Form_QLMonHoc_Load(object sender, EventArgs e)
        {
            LoadMonHoc();
            LoadMaKhoa();
        }

        private void LoadMonHoc()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM MonHoc";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void LoadMaKhoa()
        { 
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT ma_khoa, ten_khoa FROM Khoa";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);

                DataTable dt = new DataTable();
                da.Fill(dt);

                cbMaKhoa.DataSource = dt;
                cbMaKhoa.DisplayMember = "ma_khoa";  
                cbMaKhoa.ValueMember = "ma_khoa";     
                cbMaKhoa.SelectedIndex = -1;         
            }
        }

        private void ClearForm()
        {
            txtMaMon.Text = "";
            txtTenMon.Text = "";
            txtSoTinChi.Text = "";
            txtSoTietLT.Text = "";
            txtSoTietTH.Text = "";
            cbMaKhoa.SelectedIndex = -1;
            txtMaMon.Enabled = true;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaMon.Text) ||
                string.IsNullOrWhiteSpace(txtTenMon.Text) ||
                string.IsNullOrWhiteSpace(txtSoTinChi.Text) ||
                string.IsNullOrWhiteSpace(txtSoTietLT.Text) ||
                string.IsNullOrWhiteSpace(txtSoTietTH.Text) ||
        cbMaKhoa.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            if (!int.TryParse(txtSoTinChi.Text, out int tc) ||
                !int.TryParse(txtSoTietLT.Text, out int lt) ||
                !int.TryParse(txtSoTietTH.Text, out int th))
            {
                MessageBox.Show("Số tín chỉ và số tiết phải là số!");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = @"INSERT INTO MonHoc
                       (ma_mon, ten_mon, so_tin_chi,
                        so_tiet_ly_thuyet, so_tiet_thuc_hanh, ma_khoa)
                       VALUES
                       (@ma, @ten, @tc, @lt, @th, @khoa)";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ma", txtMaMon.Text);
                cmd.Parameters.AddWithValue("@ten", txtTenMon.Text);
                cmd.Parameters.AddWithValue("@tc", tc);
                cmd.Parameters.AddWithValue("@lt", lt);
                cmd.Parameters.AddWithValue("@th", th);
                cmd.Parameters.AddWithValue("@khoa", cbMaKhoa.SelectedValue.ToString());

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            LoadMonHoc();
            MessageBox.Show("Thêm môn học thành công!");
            txtMaMon.Enabled = true;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

            txtMaMon.Text = row.Cells["ma_mon"].Value.ToString();
            txtTenMon.Text = row.Cells["ten_mon"].Value.ToString();
            txtSoTinChi.Text = row.Cells["so_tin_chi"].Value.ToString();
            txtSoTietLT.Text = row.Cells["so_tiet_ly_thuyet"].Value.ToString();
            txtSoTietTH.Text = row.Cells["so_tiet_thuc_hanh"].Value.ToString();
            cbMaKhoa.SelectedValue = row.Cells["ma_khoa"].Value.ToString();
            txtMaMon.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaMon.Text))
            {
                MessageBox.Show("Vui lòng chọn môn học cần sửa!");
                return;
            }

            if (cbMaKhoa.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn khoa!");
                return;
            }
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = @"UPDATE MonHoc SET
                       ten_mon = @ten,
                       so_tin_chi = @tc,
                       so_tiet_ly_thuyet = @lt,
                       so_tiet_thuc_hanh = @th,
                       ma_khoa = @khoa
                       WHERE ma_mon = @ma";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ma", txtMaMon.Text);
                cmd.Parameters.AddWithValue("@ten", txtTenMon.Text);
                cmd.Parameters.AddWithValue("@tc", int.Parse(txtSoTinChi.Text));
                cmd.Parameters.AddWithValue("@lt", int.Parse(txtSoTietLT.Text));
                cmd.Parameters.AddWithValue("@th", int.Parse(txtSoTietTH.Text));
                cmd.Parameters.AddWithValue("@khoa", cbMaKhoa.SelectedValue.ToString());
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            LoadMonHoc();
            MessageBox.Show("Sửa môn học thành công!");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaMon.Text))
            {
                MessageBox.Show("Vui lòng chọn môn học cần xóa!");
                return;
            }

            DialogResult rs = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa môn học này?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
            if (rs == DialogResult.No)
                return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = "DELETE FROM MonHoc WHERE ma_mon = @ma";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ma", txtMaMon.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
            LoadMonHoc();
            ClearForm();
            MessageBox.Show("Xóa môn học thành công!");
        }

        private void btnTK_Click(object sender, EventArgs e)
        {
            string key = txtTenMon.Text.Trim();
            string maKhoa = cbMaKhoa.SelectedIndex == -1
                            ? null
                            : cbMaKhoa.SelectedValue.ToString();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = @"SELECT * FROM MonHoc
                       WHERE ( @key IS NULL
                               OR ma_mon LIKE '%' + @key + '%'
                               OR ten_mon LIKE N'%' + @key + '%' )
                         AND ( @khoa IS NULL
                               OR ma_khoa = @khoa )";

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);

                da.SelectCommand.Parameters.AddWithValue(
                    "@key",
                    string.IsNullOrWhiteSpace(key) ? (object)DBNull.Value : key
                );

                da.SelectCommand.Parameters.AddWithValue(
                    "@khoa",
                    maKhoa == null ? (object)DBNull.Value : maKhoa
                );

                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void btnQuay_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }
}
}

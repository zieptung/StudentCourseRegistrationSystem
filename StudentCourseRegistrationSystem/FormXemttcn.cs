using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace StudentCourseRegistrationSystem
{
    public partial class FormXemttcn : Form
    {
        private readonly string connectionString =
            @"Data Source=LAPTOP-4T6O4TN1\SQLEXPRESS;Initial Catalog=QLTC;Integrated Security=True;TrustServerCertificate=True";
        string maSV = "SV01";
        public FormXemttcn()
        {
            InitializeComponent();
            Load += FormXemttcn_Load;
            btnLuu.Click += btnLuu_Click;
        }
        private SqlConnection GetConn() => new SqlConnection(connectionString);
        
        private void FormXemttcn_Load(object sender, EventArgs e)
        {
            LoadThongTin(maSV);
        }
        private void LoadThongTin(string maSv)
        {
            string sql = @"
SELECT
    sv.ma_sv, sv.ho_ten, sv.ngay_sinh, sv.gioi_tinh, sv.email, sv.so_dien_thoai, sv.dia_chi,
    sv.khoa_hoc, sv.trang_thai,
    ctdt.ten_ctdt, ctdt.bac_dao_tao,
    k.ten_khoa
FROM SinhVien sv
LEFT JOIN ChuongTrinhDaoTao ctdt ON sv.ma_ctdt = ctdt.ma_ctdt
LEFT JOIN Khoa k ON ctdt.ma_khoa = k.ma_khoa
WHERE sv.ma_sv = @ma_sv;";
            if (string.IsNullOrWhiteSpace(maSv))
            {
                MessageBox.Show("Chưa có mã SV");
                return;
            }

            var conn = GetConn();
            var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@ma_sv", maSv);

            conn.Open();
            var rd = cmd.ExecuteReader();

            if (!rd.Read())
            {
                MessageBox.Show("Không tìm thấy sinh viên!");
                return;
            }

            txtMaSV.Text = rd["ma_sv"]?.ToString();
            txtHoTen.Text = rd["ho_ten"]?.ToString();

            if (rd["ngay_sinh"] != DBNull.Value)
                dtpNgaySinh.Value = Convert.ToDateTime(rd["ngay_sinh"]);
            else
                dtpNgaySinh.Value = DateTime.Today;

            txtGioiTinh.Text = rd["gioi_tinh"]?.ToString();
            txtEmail.Text = rd["email"]?.ToString();
            txtSDT.Text = rd["so_dien_thoai"]?.ToString();
            txtDiaChi.Text = rd["dia_chi"]?.ToString();
            txtKhoaHoc.Text = rd["khoa_hoc"]?.ToString();
            txtTrangThai.Text = rd["trang_thai"]?.ToString();

            txtCTDT.Text = rd["ten_ctdt"]?.ToString();
            txtBacDaoTao.Text = rd["bac_dao_tao"]?.ToString();
            txtKhoa.Text = rd["ten_khoa"]?.ToString();

            // Khóa xem
            SetReadOnly();
        }
        private void SetReadOnly()
        {
            txtMaSV.ReadOnly = true;
            txtHoTen.ReadOnly = true;
            dtpNgaySinh.Enabled = false;
            txtGioiTinh.ReadOnly = true;
            txtKhoaHoc.ReadOnly = true;
            txtTrangThai.ReadOnly = true;

            txtCTDT.ReadOnly = true;
            txtBacDaoTao.ReadOnly = true;
            txtKhoa.ReadOnly = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text) ||
        string.IsNullOrWhiteSpace(txtSDT.Text))
            {
                MessageBox.Show("Email và Số điện thoại không được để trống!");
                return;
            }

            // (Optional) check định dạng email
            if (!txtEmail.Text.Contains("@"))
            {
                MessageBox.Show("Email không hợp lệ!");
                return;
            }

            string sql = @"
UPDATE SinhVien
SET email = @email,
    so_dien_thoai = @sdt,
    dia_chi = @dia_chi
WHERE ma_sv = @ma_sv;";

            try
            {
                var conn = GetConn();
                var cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@sdt", txtSDT.Text.Trim());
                cmd.Parameters.AddWithValue("@dia_chi", txtDiaChi.Text.Trim());
                cmd.Parameters.AddWithValue("@ma_sv", txtMaSV.Text.Trim());

                conn.Open();
                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                    MessageBox.Show("Cập nhật thông tin thành công!");
                else
                    MessageBox.Show("Không có thay đổi nào được lưu.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật: " + ex.Message);
            }
        }

       
    }
}

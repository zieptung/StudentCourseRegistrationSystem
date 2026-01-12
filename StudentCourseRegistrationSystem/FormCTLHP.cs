using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentCourseRegistrationSystem
{
    public partial class FormCTLHP : Form
    {
        private string ma_LHP;
        public FormCTLHP(string maLHP)
        {
            InitializeComponent();
            ma_LHP = maLHP;
        }

        private void FormCTLHP_Load(object sender, EventArgs e)
        {
            LoadSoLuongSinhVien();
            LoadSinhVienDangKy();
        }
        private void LoadSinhVienDangKy()
        {
            string sql = $@"
            SELECT
            sv.ma_sv,
            sv.ho_ten,
            sv.gioi_tinh,
            sv.ngay_sinh,
            sv.lop,
            sv.khoa,
            dk.ngay_dang_ky,
            dk.trang_thai
            FROM DangKyLopHocPhan dk
            JOIN SinhVien sv ON dk.ma_sv = sv.ma_sv
            WHERE dk.ma_lhp = N'{ma_LHP}'";

            dgvChiTietLHP.AutoGenerateColumns = false;
            dgvChiTietLHP.DataSource = CrudLib.GetDataTable(sql);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string maSV = txtMaSinhVien.Text.Trim();
            string hoTen = txtHoTen.Text.Trim();
            string khoa = txtKhoa.Text.Trim();
            string lop = txtLop.Text.Trim();

            string sql = $@"
            SELECT
            sv.ma_sv,
            sv.ho_ten,
            sv.gioi_tinh,
            sv.ngay_sinh,
            sv.lop,
            sv.khoa,
            dk.ngay_dang_ky,
            dk.trang_thai
            FROM DangKyLopHocPhan dk
            JOIN SinhVien sv ON dk.ma_sv = sv.ma_sv
            WHERE dk.ma_lhp = N'{ma_LHP}'
            AND sv.ma_sv  LIKE N'%{maSV}%'
            AND sv.ho_ten LIKE N'%{hoTen}%'
            AND sv.khoa   LIKE N'%{khoa}%'
            AND sv.lop    LIKE N'%{lop}%'
    ";

            dgvChiTietLHP.AutoGenerateColumns = false;
            dgvChiTietLHP.DataSource = CrudLib.GetDataTable(sql);
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaSinhVien.Clear();
            txtHoTen.Clear();
            txtKhoa.Clear();
            txtLop.Clear();

            LoadSinhVienDangKy();
        }
        private void LoadSoLuongSinhVien()
        {
            string sql = $@"
            SELECT COUNT(*)
            FROM DangKyLopHocPhan
            WHERE ma_lhp = N'{ma_LHP}'";

            int soSV = Convert.ToInt32(CrudLib.GetValue(sql));

            lblSoLuongSV.Text = $"Số sinh viên đã đăng ký: {soSV}";
        }

    }
}
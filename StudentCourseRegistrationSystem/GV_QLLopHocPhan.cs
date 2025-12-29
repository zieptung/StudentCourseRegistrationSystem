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
    public partial class GV_QLLopHocPhan : Form
    {
        public GV_QLLopHocPhan()
        {
            InitializeComponent();
        }
        private void LoadLopHocPhan()
        {
            string sql = @"
        SELECT 
    l.ma_lhp            AS N'Mã lớp học phần',
    m.ma_mon            AS N'Mã môn học',
    m.ten_mon           AS N'Tên môn học',
    m.so_tin_chi        AS N'Số tín chỉ',
    l.ma_gv             AS N'Mã giảng viên',
    hk.ma_hoc_ky       AS N'Mã học kỳ',
    l.so_luong_toi_da   AS N'Sĩ số tối đa',
    l.so_luong_da_dang_ky AS N'Đã đăng ký',
    l.trang_thai        AS N'Trạng thái'
FROM LopHocPhan l
JOIN MonHoc m ON l.ma_mon = m.ma_mon
JOIN HocKy hk ON l.ma_hoc_ky = hk.ma_hoc_ky
";

            dgvLopHocPhan.DataSource = CrudLib.GetDataTable(sql);
        }
        private void LamMoiForm()
        {
            txtMaLHP.Clear();
            txtMonHoc.Clear();
            txtTenMon.Clear();
            txtSoTinChi.Clear();
            txtMaGV.Clear();
            txtSoLuong.Clear();

            txtDaDangKy.Text = "0";

            cboHocKy.SelectedIndex = -1;
            cboTrangThai.SelectedIndex = 0;

            txtMaLHP.Enabled = true;
        }
        private void LoadHocKy()
        {
            string sql = "SELECT ma_hoc_ky, ten_hoc_ky FROM HocKy";

            DataTable dt = CrudLib.GetDataTable(sql);
            cboHocKy.DataSource = dt;
            cboHocKy.DisplayMember = "ma_hoc_ky";
            cboHocKy.ValueMember = "ma_hoc_ky";
            cboHocKy.SelectedIndex = -1;
        }
        private void LoadTrangThai()
        {
            cboTrangThai.Items.Clear();
            cboTrangThai.Items.Add("Mở");
            cboTrangThai.Items.Add("Đóng");
            cboTrangThai.SelectedIndex = 0;
        }


        private void btnThemLop_Click(object sender, EventArgs e)
        {
            // 1️⃣ Kiểm tra dữ liệu
            if (string.IsNullOrWhiteSpace(txtMaLHP.Text) ||
                string.IsNullOrWhiteSpace(txtMonHoc.Text) ||
                string.IsNullOrWhiteSpace(txtMaGV.Text) ||
                cboHocKy.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(txtSoLuong.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maLHP = txtMaLHP.Text.Trim();
            string maMon = txtMonHoc.Text.Trim();
            string maGV = txtMaGV.Text.Trim();
            string maHocKy = cboHocKy.SelectedValue.ToString();
            int soLuong = int.Parse(txtSoLuong.Text);
            string trangThai = cboTrangThai.Text;

            // 2️⃣ Kiểm tra tồn tại mã giảng viên
            string sqlCheckGV = $"SELECT COUNT(*) FROM GiangVien WHERE ma_gv = '{maGV}'";
            if (Convert.ToInt32(CrudLib.GetValue(sqlCheckGV)) == 0)
            {
                MessageBox.Show("Mã giảng viên không tồn tại!",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 3️⃣ Kiểm tra trùng mã lớp
            string sqlCheck = $"SELECT COUNT(*) FROM LopHocPhan WHERE ma_lhp = '{maLHP}'";
            if (Convert.ToInt32(CrudLib.GetValue(sqlCheck)) > 0)
            {
                MessageBox.Show("Mã lớp học phần đã tồn tại!",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 4️⃣ Thêm lớp học phần
            string sqlInsert = $@"
        INSERT INTO LopHocPhan
        (ma_lhp, ma_mon, ma_gv, ma_hoc_ky,
         so_luong_toi_da, so_luong_da_dang_ky, trang_thai)
        VALUES
        ('{maLHP}', '{maMon}', '{maGV}', '{maHocKy}',
         {soLuong}, 0, N'{trangThai}')";

            int result = CrudLib.IUDQuery(sqlInsert);

            if (result > 0)
            {
                MessageBox.Show("Thêm lớp học phần thành công!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadLopHocPhan();
                LamMoiForm();
            }
        }

        private void GV_QLLopHocPhan_Load(object sender, EventArgs e)
        {
            LoadHocKy();
            LoadTrangThai();
            LoadLopHocPhan();

            txtDaDangKy.Text = "0";
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dgvLopHocPhan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // 1️⃣ Không xử lý khi click header
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvLopHocPhan.Rows[e.RowIndex];

            // 2️⃣ Đổ dữ liệu lên các TextBox
            txtMaLHP.Text = row.Cells["Mã lớp học phần"].Value.ToString();
            txtMonHoc.Text = row.Cells["Mã môn học"].Value.ToString();
            txtTenMon.Text = row.Cells["Tên môn học"].Value.ToString();
            txtSoTinChi.Text = row.Cells["Số tín chỉ"].Value.ToString();
            txtMaGV.Text = row.Cells["Mã giảng viên"].Value.ToString();
            txtSoLuong.Text = row.Cells["Sĩ số tối đa"].Value.ToString();
            txtDaDangKy.Text = row.Cells["Đã đăng ký"].Value.ToString();

            // 3️⃣ Đổ dữ liệu lên ComboBox
            cboHocKy.SelectedValue = row.Cells["Mã học kỳ"].Value.ToString();
            cboTrangThai.Text = row.Cells["Trạng thái"].Value.ToString();

            // 4️⃣ Không cho sửa khóa chính
            txtMaLHP.Enabled = false;
        }

        private void btnSuaLop_Click(object sender, EventArgs e)
        {
            // 1️⃣ Kiểm tra đã chọn lớp chưa
            if (string.IsNullOrWhiteSpace(txtMaLHP.Text))
            {
                MessageBox.Show("Vui lòng chọn lớp học phần cần sửa!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2️⃣ Kiểm tra nhập liệu
            if (string.IsNullOrWhiteSpace(txtMonHoc.Text) ||
                string.IsNullOrWhiteSpace(txtMaGV.Text) ||
                cboHocKy.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(txtSoLuong.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maLHP = txtMaLHP.Text.Trim();
            string maMon = txtMonHoc.Text.Trim();
            string maGV = txtMaGV.Text.Trim();
            string maHocKy = cboHocKy.SelectedValue.ToString();
            int soLuong = int.Parse(txtSoLuong.Text);
            string trangThai = cboTrangThai.Text;

            // 3️⃣ Kiểm tra mã môn học tồn tại
            string sqlCheckMon = $"SELECT COUNT(*) FROM MonHoc WHERE ma_mon = '{maMon}'";
            if (Convert.ToInt32(CrudLib.GetValue(sqlCheckMon)) == 0)
            {
                MessageBox.Show("Mã môn học không tồn tại!",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMonHoc.Focus();
                return;
            }

            // 4️⃣ Kiểm tra mã giảng viên tồn tại
            string sqlCheckGV = $"SELECT COUNT(*) FROM GiangVien WHERE ma_gv = '{maGV}'";
            if (Convert.ToInt32(CrudLib.GetValue(sqlCheckGV)) == 0)
            {
                MessageBox.Show("Mã giảng viên không tồn tại!",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaGV.Focus();
                return;
            }

            // 5️⃣ UPDATE lớp học phần
            string sqlUpdate = $@"
        UPDATE LopHocPhan
        SET 
            ma_mon = '{maMon}',
            ma_gv = '{maGV}',
            ma_hoc_ky = '{maHocKy}',
            so_luong_toi_da = {soLuong},
            trang_thai = N'{trangThai}'
        WHERE ma_lhp = '{maLHP}'";

            int result = CrudLib.IUDQuery(sqlUpdate);

            if (result > 0)
            {
                MessageBox.Show("Cập nhật lớp học phần thành công!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadLopHocPhan();
                LamMoiForm();
            }
        }

        private void btnXoaLop_Click(object sender, EventArgs e)
        {
            // 1️⃣ Kiểm tra đã chọn lớp chưa
            if (string.IsNullOrWhiteSpace(txtMaLHP.Text))
            {
                MessageBox.Show("Vui lòng chọn lớp học phần cần xóa!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maLHP = txtMaLHP.Text.Trim();

            // 2️⃣ Xác nhận xóa
            DialogResult dr = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa lớp học phần này không?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (dr == DialogResult.No)
                return;

            // 3️⃣ Kiểm tra lớp đã có sinh viên đăng ký chưa
            string sqlCheckSV = $"SELECT COUNT(*) FROM DangKyHocPhan WHERE ma_lhp = '{maLHP}'";
            if (Convert.ToInt32(CrudLib.GetValue(sqlCheckSV)) > 0)
            {
                MessageBox.Show("Không thể xóa lớp đã có sinh viên đăng ký!",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 4️⃣ Kiểm tra đã có thời khóa biểu chưa
            string sqlCheckTKB = $"SELECT COUNT(*) FROM ThoiKhoaBieu WHERE ma_lhp = '{maLHP}'";
            if (Convert.ToInt32(CrudLib.GetValue(sqlCheckTKB)) > 0)
            {
                MessageBox.Show("Không thể xóa lớp đã có thời khóa biểu!",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 5️⃣ Kiểm tra đã có kết quả học tập chưa
            string sqlCheckKQ = $"SELECT COUNT(*) FROM KetQuaHocTap WHERE ma_lhp = '{maLHP}'";
            if (Convert.ToInt32(CrudLib.GetValue(sqlCheckKQ)) > 0)
            {
                MessageBox.Show("Không thể xóa lớp đã có kết quả học tập!",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 6️⃣ Xóa lớp học phần
            string sqlDelete = $"DELETE FROM LopHocPhan WHERE ma_lhp = '{maLHP}'";
            int result = CrudLib.IUDQuery(sqlDelete);

            if (result > 0)
            {
                MessageBox.Show("Xóa lớp học phần thành công!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadLopHocPhan();
                LamMoiForm();
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoiForm();

        }
    }
}

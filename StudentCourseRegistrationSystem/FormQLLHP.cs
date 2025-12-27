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
using ClosedXML.Excel;


namespace StudentCourseRegistrationSystem
{
    public partial class FormQLLHP : Form
    {
        private readonly string connectionString =
            @"Data Source=LAPTOP-9G6IUBF5;Initial Catalog=QLTC;Integrated Security=True;TrustServerCertificate=True";
        public FormQLLHP()
        {
            InitializeComponent();
            Load += FormQLLHP_Load;
            dgvLHP.CellClick += dgvLHP_CellClick;

            btnMoLop.Click += btnMoLop_Click;
            btnSua.Click += btnSua_Click;
            btnXoa.Click += btnXoa_Click;
            btnMoi.Click += (s, e) => ClearInputs();
            btnXuatExcel.Click += btnXuatExcel_Click;
        }
        private SqlConnection GetConn() => new SqlConnection(connectionString);

        private void FormQLLHP_Load(object sender, EventArgs e)
        {
            LoadCombos();
            LoadLHP();
            ClearInputs();
        }
        private void LoadCombos()
        {
            var conn = GetConn();
            conn.Open();

            // Môn học
            using (var da = new SqlDataAdapter("SELECT ma_mon, ten_mon FROM MonHoc", conn))
            {
                var dt = new DataTable();
                da.Fill(dt);
                cboMon.DataSource = dt;
                cboMon.DisplayMember = "ten_mon";
                cboMon.ValueMember = "ma_mon";
                cboMon.SelectedIndex = -1;
            }

            // Giảng viên
            using (var da = new SqlDataAdapter("SELECT ma_gv, ho_ten FROM GiangVien", conn))
            {
                var dt = new DataTable();
                da.Fill(dt);
                cboGiangVien.DataSource = dt;
                cboGiangVien.DisplayMember = "ho_ten";
                cboGiangVien.ValueMember = "ma_gv";
                cboGiangVien.SelectedIndex = -1;
            }

            // Học kỳ
            using (var da = new SqlDataAdapter(
                "SELECT ma_hoc_ky, ten_hoc_ky + ' - ' + nam_hoc AS ten FROM HocKy", conn))
            {
                var dt = new DataTable();
                da.Fill(dt);
                cboHocKy.DataSource = dt;
                cboHocKy.DisplayMember = "ten";
                cboHocKy.ValueMember = "ma_hoc_ky";
                cboHocKy.SelectedIndex = -1;
            }
        }
        private void LoadLHP()
        {
            string sql = @"
SELECT 
    lhp.ma_lhp AS N'Mã lớp HP', lhp.ma_mon AS N'Mã môn', mh.ten_mon AS N'Tên môn',
    lhp.ma_gv AS N'Mã giảng viên', gv.ho_ten AS N'Họ tên',
    lhp.ma_hoc_ky AS N'Mã học kỳ', hk.ten_hoc_ky AS N'Tên học kỳ', hk.nam_hoc AS N'Năm học',
    lhp.so_luong_toi_da AS N'Số lượng tối đa',
    lhp.so_luong_da_dang_ky AS N'Số lượng đã đăng ký',
    lhp.trang_thai AS N'Trạng thái'
FROM LopHocPhan lhp
JOIN MonHoc mh ON lhp.ma_mon = mh.ma_mon
JOIN GiangVien gv ON lhp.ma_gv = gv.ma_gv
JOIN HocKy hk ON lhp.ma_hoc_ky = hk.ma_hoc_ky
ORDER BY hk.nam_hoc DESC;";

            var da = new SqlDataAdapter(sql, GetConn());
            var dt = new DataTable();
            da.Fill(dt);
            dgvLHP.DataSource = dt;
            dgvLHP.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dgvLHP.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvLHP.ColumnHeadersHeight = 40;
            dgvLHP.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void ClearInputs()
        {
            txtMaLHP.Text = "";
            cboMon.SelectedIndex = -1;
            cboGiangVien.SelectedIndex = -1;
            cboHocKy.SelectedIndex = -1;
            nudSoLuongToiDa.Value = 0;
            txtSoLuongDaDK.Text = "0";
            cboTrangThai.SelectedIndex = -1;

            txtMaLHP.ReadOnly = false;
            txtMaLHP.Focus();
        }
        private bool ValidateLHP()
        {
            if (string.IsNullOrWhiteSpace(txtMaLHP.Text))
            {
                MessageBox.Show("Mã lớp học phần không được trống!");
                return false;
            }
            if (cboMon.SelectedIndex < 0 || cboGiangVien.SelectedIndex < 0 || cboHocKy.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn Môn, Giảng viên và Học kỳ!");
                return false;
            }
            if (cboTrangThai.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn trạng thái!");
                return false;
            }
            if (nudSoLuongToiDa.Value <= 0)
            {
                MessageBox.Show("Số lượng tối đa phải > 0!");
                return false;
            }
            return true;
        }

        private void dgvLHP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvLHP.Rows[e.RowIndex];

            txtMaLHP.Text = row.Cells["Mã lớp HP"].Value.ToString();
            cboMon.SelectedValue = row.Cells["Mã môn"].Value;
            cboGiangVien.SelectedValue = row.Cells["Mã giảng viên"].Value;
            cboHocKy.SelectedValue = row.Cells["Mã học kỳ"].Value;
            nudSoLuongToiDa.Value = Convert.ToDecimal(row.Cells["Số lượng tối đa"].Value);
            txtSoLuongDaDK.Text = row.Cells["Số lượng đã đăng ký"].Value.ToString();
            cboTrangThai.Text = row.Cells["Trạng thái"].Value.ToString();

            txtMaLHP.ReadOnly = true;
        }

        private void btnMoLop_Click(object sender, EventArgs e)
        {
            if (!ValidateLHP()) return;

            string sql = @"
INSERT INTO LopHocPhan
(ma_lhp, ma_mon, ma_gv, ma_hoc_ky, so_luong_toi_da, so_luong_da_dang_ky, trang_thai)
VALUES(@ma_lhp, @ma_mon, @ma_gv, @ma_hoc_ky, @sl, 0, @trang_thai);";

            var conn = GetConn();
            var cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@ma_lhp", txtMaLHP.Text.Trim());
            cmd.Parameters.AddWithValue("@ma_mon", cboMon.SelectedValue);
            cmd.Parameters.AddWithValue("@ma_gv", cboGiangVien.SelectedValue);
            cmd.Parameters.AddWithValue("@ma_hoc_ky", cboHocKy.SelectedValue);
            cmd.Parameters.AddWithValue("@sl", nudSoLuongToiDa.Value);
            cmd.Parameters.AddWithValue("@trang_thai", cboTrangThai.Text);

            conn.Open();
            cmd.ExecuteNonQuery();

            MessageBox.Show("Mở lớp học phần thành công!");
            LoadLHP();
            ClearInputs();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!ValidateLHP()) return;

            int slDaDK = int.Parse(txtSoLuongDaDK.Text);
            if (nudSoLuongToiDa.Value < slDaDK)
            {
                MessageBox.Show("Số lượng tối đa không được nhỏ hơn số đã đăng ký!");
                return;
            }

            string sql = @"
UPDATE LopHocPhan
SET ma_mon=@ma_mon, ma_gv=@ma_gv, ma_hoc_ky=@ma_hoc_ky,
    so_luong_toi_da=@sl, trang_thai=@trang_thai
WHERE ma_lhp=@ma_lhp;";

            var conn = GetConn();
            var cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@ma_lhp", txtMaLHP.Text);
            cmd.Parameters.AddWithValue("@ma_mon", cboMon.SelectedValue);
            cmd.Parameters.AddWithValue("@ma_gv", cboGiangVien.SelectedValue);
            cmd.Parameters.AddWithValue("@ma_hoc_ky", cboHocKy.SelectedValue);
            cmd.Parameters.AddWithValue("@sl", nudSoLuongToiDa.Value);
            cmd.Parameters.AddWithValue("@trang_thai", cboTrangThai.Text);

            conn.Open();
            cmd.ExecuteNonQuery();

            MessageBox.Show("Sửa lớp học phần thành công!");
            LoadLHP();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaLHP.Text)) return;

            var confirm = MessageBox.Show("Xóa lớp học phần này?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;

            try
            {
                var conn = GetConn();
                var cmd = new SqlCommand(
                    "DELETE FROM LopHocPhan WHERE ma_lhp=@ma_lhp", conn);

                cmd.Parameters.AddWithValue("@ma_lhp", txtMaLHP.Text);
                conn.Open();
                cmd.ExecuteNonQuery();

                MessageBox.Show("Xóa lớp học phần thành công!");
                LoadLHP();
                ClearInputs();
            }
            catch (SqlException)
            {
                MessageBox.Show("Không thể xóa vì lớp học phần đã có sinh viên đăng ký!");
            }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            if (dgvLHP.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!");
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Workbook (*.xlsx)|*.xlsx";
            sfd.FileName = "DanhSachLopHocPhan.xlsx";

            if (sfd.ShowDialog() != DialogResult.OK) return;

            try
            {
                ExportDataGridViewToExcel(dgvLHP, sfd.FileName, "LopHocPhan");
                MessageBox.Show("Xuất Excel thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xuất Excel thất bại: " + ex.Message);
            }
        }

        private void ExportDataGridViewToExcel(DataGridView dgv, string filePath, string sheetName)
        {
            var wb = new XLWorkbook();
            var ws = wb.Worksheets.Add(sheetName);

            // Header
            for (int c = 0; c < dgv.Columns.Count; c++)
            {
                ws.Cell(1, c + 1).Value = dgv.Columns[c].HeaderText;
                ws.Cell(1, c + 1).Style.Font.Bold = true;
            }

            // Data
            int r = 2;
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.IsNewRow) continue;

                for (int c = 0; c < dgv.Columns.Count; c++)
                {
                    ws.Cell(r, c + 1).Value = row.Cells[c].Value?.ToString() ?? "";
                }
                r++;
            }

            // Format
            ws.RangeUsed().SetAutoFilter();
            ws.Columns().AdjustToContents();

            wb.SaveAs(filePath);
        }
    }
}

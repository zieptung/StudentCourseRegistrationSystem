using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;


namespace StudentCourseRegistrationSystem
{
    public partial class FormQLSV : Form
    {
        public FormQLSV()
        {
            InitializeComponent();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaSV.Text))
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần xoá!");
                return;
            }

            string checkSql = $@"
                SELECT COUNT(*) 
                FROM DangKyLopHocPhan 
                WHERE ma_sv = '{txtMaSV.Text}'";
            int count = Convert.ToInt32(CrudLib.GetValue(checkSql));

            if (count > 0)
            {
                MessageBox.Show(
                    "Sinh viên đã đăng ký tín chỉ, không thể xoá!",
                    "Cảnh báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xoá sinh viên này?",
                "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            string sql = $"DELETE FROM SinhVien WHERE ma_sv = '{txtMaSV.Text}'";
            CrudLib.IUDQuery(sql);
            LoadData();
            MessageBox.Show("Xoá sinh viên thành công!");
            btnLammoi_Click(sender, e);
        }

        private void FormQLSV_Load(object sender, EventArgs e)
        {
            cbGioitinh.Items.Clear();
            cbGioitinh.Items.Add("Nam");
            cbGioitinh.Items.Add("Nữ");
            cbGioitinh.SelectedIndex = 0;

            LoadData();
        }

        void LoadData()
        {
            string sql = "SELECT * FROM SinhVien";
            dataGridView1.DataSource = CrudLib.GetDataTable(sql);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaSV.Text) ||
            string.IsNullOrWhiteSpace(txtHoten.Text) ||
            string.IsNullOrWhiteSpace(txtLop.Text) ||
            string.IsNullOrWhiteSpace(txtKhoa.Text) ||
            dateNgaysinh.Value == null ||
            cbGioitinh.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tất cả thông tin!");
                return;
            }

            if (dateNgaysinh.Value.Date >= DateTime.Now.Date)
            {
                MessageBox.Show("Ngày sinh phải nhỏ hơn ngày hiện tại!");
                return;
            }

            string checkSql = $"SELECT COUNT(*) FROM SinhVien WHERE ma_sv = '{txtMaSV.Text}'";
            if (Convert.ToInt32(CrudLib.GetValue(checkSql)) > 0)
            {
                MessageBox.Show("Mã sinh viên đã tồn tại!");
                return;
            }

            string sql = $@"
            INSERT INTO SinhVien
            VALUES (
                '{txtMaSV.Text}',
                N'{txtHoten.Text}',
                '{dateNgaysinh.Value:yyyy-MM-dd}',
                N'{cbGioitinh.Text}',
                N'{txtLop.Text}',
                N'{txtKhoa.Text}'
            )";

            CrudLib.IUDQuery(sql);
            LoadData();
            MessageBox.Show("Thêm sinh viên thành công!");
            btnLammoi_Click(sender, e);
        }

        private void btnLammoi_Click(object sender, EventArgs e)
        {
            txtMaSV.Clear();
            txtHoten.Clear();
            txtLop.Clear();
            txtKhoa.Clear();
            cbGioitinh.SelectedIndex = 0;
            dateNgaysinh.Value = DateTime.Now;
            txtMaSV.Enabled = true;
            txtMaSV.Focus();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var r = dataGridView1.Rows[e.RowIndex];
            txtMaSV.Text = r.Cells["ma_sv"].Value.ToString();
            txtHoten.Text = r.Cells["ho_ten"].Value.ToString();
            dateNgaysinh.Value = Convert.ToDateTime(r.Cells["ngay_sinh"].Value);
            cbGioitinh.Text = r.Cells["gioi_tinh"].Value.ToString();
            txtLop.Text = r.Cells["lop"].Value.ToString();
            txtKhoa.Text = r.Cells["khoa"].Value.ToString();

            txtMaSV.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaSV.Text))
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần sửa!");
                return;
            }

            string sql = $@"
            UPDATE SinhVien SET
                ho_ten = N'{txtHoten.Text}',
                ngay_sinh = '{dateNgaysinh.Value:yyyy-MM-dd}',
                gioi_tinh = N'{cbGioitinh.Text}',
                lop = N'{txtLop.Text}',
                khoa = N'{txtKhoa.Text}'
                WHERE ma_sv = '{txtMaSV.Text}'";

            CrudLib.IUDQuery(sql);
            LoadData();
            MessageBox.Show("Cập nhật sinh viên thành công!");
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            string tukhoa = txtTukhoa.Text.Trim();

            if (tukhoa == "")
            {
                LoadData();
                return;
            }

            string sql = $@"
            SELECT * FROM SinhVien
            WHERE khoa LIKE N'%{tukhoa}%'";
            dataGridView1.DataSource = CrudLib.GetDataTable(sql);
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!");
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Files (*.xlsx)|*.xlsx";
            sfd.FileName = "DanhSachSinhVien.xlsx";

            if (sfd.ShowDialog() != DialogResult.OK) return;

            try
            {
                using (XLWorkbook wb = new XLWorkbook())
                {
                    var ws = wb.Worksheets.Add("SinhVien");

                    int colCount = dataGridView1.Columns.Count;

                    for (int col = 0; col < colCount; col++)
                    {
                        ws.Cell(1, col + 1).Value = dataGridView1.Columns[col].HeaderText;
                        ws.Cell(1, col + 1).Style.Font.Bold = true;
                        ws.Cell(1, col + 1).Style.Alignment.Horizontal =
                            XLAlignmentHorizontalValues.Center;
                    }

                    int rowExcel = 2;
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.IsNewRow) continue;

                        for (int col = 0; col < colCount; col++)
                        {
                            object value = row.Cells[col].Value;

                            if (value is DateTime)
                            {
                                ws.Cell(rowExcel, col + 1).Value = (DateTime)value;
                                ws.Cell(rowExcel, col + 1)
                                  .Style.DateFormat.Format = "dd/MM/yyyy";
                            }
                            else
                            {
                                ws.Cell(rowExcel, col + 1).Value = value?.ToString();
                            }
                        }
                        rowExcel++;
                    }

                    ws.Columns().AdjustToContents();

                    wb.SaveAs(sfd.FileName);
                }

                MessageBox.Show("Xuất Excel thành công!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xuất Excel: " + ex.Message);
            }
        }

        private void btnNhap_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel Files (*.xlsx)|*.xlsx";

            if (ofd.ShowDialog() != DialogResult.OK) return;

            try
            {
                using (XLWorkbook wb = new XLWorkbook(ofd.FileName))
                {
                    var ws = wb.Worksheet(1);
                    var rows = ws.RangeUsed().RowsUsed().Skip(1);
                    int dem = 0;

                    foreach (var row in rows)
                    {
                        string maSV = row.Cell(1).GetString().Trim();
                        string hoTen = row.Cell(2).GetString().Trim();
                        DateTime ngaySinh = row.Cell(3).GetDateTime();
                        string gioiTinh = row.Cell(4).GetString().Trim();
                        string lop = row.Cell(5).GetString().Trim();
                        string khoa = row.Cell(6).GetString().Trim();

                        // Bỏ qua dòng trống
                        if (maSV == "" || hoTen == "") continue;

                        // Kiểm tra trùng mã SV
                        string checkSql = $"SELECT COUNT(*) FROM SinhVien WHERE ma_sv = '{maSV}'";
                        int count = Convert.ToInt32(CrudLib.GetValue(checkSql));

                        if (count == 0)
                        {
                            string sql = $@"
                        INSERT INTO SinhVien
                        VALUES (
                            '{maSV}',
                            N'{hoTen}',
                            '{ngaySinh:yyyy-MM-dd}',
                            N'{gioiTinh}',
                            N'{lop}',
                            N'{khoa}'
                        )";

                            CrudLib.IUDQuery(sql);
                            dem++;
                        }
                    }

                    LoadData();
                    MessageBox.Show($"Nhập Excel thành công {dem} sinh viên!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi nhập Excel: " + ex.Message);
            }
        }
    }
}
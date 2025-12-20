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
using xls = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace StudentCourseRegistrationSystem
{
    public partial class FormAdmin : Form
    {
        public FormAdmin()
        {
            InitializeComponent();
        }

        private void FormAdmin_Load(object sender, EventArgs e)
        {
            LoadRole();
            LoadAccount();
           

        }
        private void LoadRole()
        {
            string sql = "SELECT ma_vai_tro, ten_vai_tro FROM VaiTro";
            DataTable dt = CrudLib.GetDataTable(sql);

            cboRole.DataSource = dt;
            cboRole.DisplayMember = "ten_vai_tro"; // Hiển thị: Sinh Viên
            cboRole.ValueMember = "ma_vai_tro";    // Giá trị: SV
            cboRole.SelectedIndex = -1;
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string pass = txtPass.Text.Trim();
            string role = cboRole.SelectedValue.ToString();
            string maLienKet = txtMaLienKet.Text.Trim();
            if (username == "" || pass == "" || maLienKet == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }
            string sqlCheckUser = $"SELECT COUNT(*) FROM TaiKhoan WHERE ten_dang_nhap = '{username}'";
            if (Convert.ToInt32(CrudLib.GetValue(sqlCheckUser)) > 0)
            {
                MessageBox.Show("Tên đăng nhập đã tồn tại!");
                return;
            }

            // Kiểm tra mã liên kết tồn tại
            if (role == "SV")
            {
                string sqlCheckSV = $"SELECT COUNT(*) FROM SinhVien WHERE ma_sv = '{maLienKet}'";
                if (Convert.ToInt32(CrudLib.GetValue(sqlCheckSV)) == 0)
                {
                    MessageBox.Show("Mã sinh viên không tồn tại!");
                    return;
                }
            }
            else if (role == "GV")
            {
                string sqlCheckGV = $"SELECT COUNT(*) FROM GiangVien WHERE ma_gv = '{maLienKet}'";
                if (Convert.ToInt32(CrudLib.GetValue(sqlCheckGV)) == 0)
                {
                    MessageBox.Show("Mã giảng viên không tồn tại!");
                    return;
                }
            }
            // 3. Thêm tài khoản

            string sqlInsert = $@"INSERT INTO TaiKhoan(ten_dang_nhap, mat_khau, ma_vai_tro, ma_lien_ket) VALUES('{username}', '{pass}','{role}', '{maLienKet}')
";

            int kq = CrudLib.IUDQuery(sqlInsert);
            if (kq > 0)
            {
                MessageBox.Show("Thêm tài khoản thành công!");
                LoadAccount();
                ClearForm();
            }
        }

        private void dgvDSAccount_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDSAccount.Rows[e.RowIndex];

                txtUsername.Text = row.Cells["Tên đăng nhập"].Value.ToString();
                txtPass.Text = row.Cells["Mật khẩu"].Value.ToString();
                txtMaLienKet.Text = row.Cells["Mã liên kết"].Value.ToString();
                cboRole.SelectedValue = row.Cells["Mã vai trò"].Value.ToString();
            }
        }
        private void ClearForm()
        {
            txtUsername.Clear();
            txtPass.Clear();
            txtMaLienKet.Clear();
            cboRole.SelectedIndex = -1;
        }
        private void LoadAccount()
        {
            string sql = @"
        SELECT ten_dang_nhap AS [Tên đăng nhập],
               mat_khau AS [Mật khẩu],
               ma_vai_tro AS [Mã vai trò],
               ma_lien_ket AS [Mã liên kết]
        FROM TaiKhoan
    ";
            dgvDSAccount.DataSource = CrudLib.GetDataTable(sql);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnNhapExcel_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel Files|*.xlsx;*.xls";

            if (ofd.ShowDialog() != DialogResult.OK)
                return;

            string filename = ofd.FileName;

            xls.Application excel = new xls.Application();
            xls.Workbook wb = excel.Workbooks.Open(filename);

            int success = 0;
            int fail = 0;

            try
            {
                foreach (xls.Worksheet ws in wb.Worksheets)
                {
                    int i = 4; // bỏ dòng tiêu đề

                    while (true)
                    {
                        var c1 = ws.Cells[i, 1].Value;
                        var c2 = ws.Cells[i, 2].Value;
                        var c3 = ws.Cells[i, 3].Value;
                        var c4 = ws.Cells[i, 4].Value;

                        if (string.IsNullOrWhiteSpace(c1?.ToString()))
                            break;


                        string username = c1?.ToString().Trim();
                        string pass = c2?.ToString().Trim();
                        string role = c3?.ToString().Trim();
                        string maLienKet = c4?.ToString().Trim();

                        if (string.IsNullOrEmpty(username) ||
                            string.IsNullOrEmpty(pass) ||
                            string.IsNullOrEmpty(role))
                        {
                            fail++;
                            i++;
                            continue;
                        }

                        // Check trùng username
                        if (Convert.ToInt32(CrudLib.GetValue(
                            $"SELECT COUNT(*) FROM TaiKhoan WHERE ten_dang_nhap = '{username}'")) > 0)
                        {
                            fail++;
                            i++;
                            continue;
                        }

                        // Check role + mã liên kết
                        if (role == "SV")
                        {
                            if (Convert.ToInt32(CrudLib.GetValue(
                                $"SELECT COUNT(*) FROM SinhVien WHERE ma_sv = '{maLienKet}'")) == 0)
                            {
                                fail++;
                                i++;
                                continue;
                            }
                        }
                        else if (role == "GV")
                        {
                            if (Convert.ToInt32(CrudLib.GetValue(
                                $"SELECT COUNT(*) FROM GiangVien WHERE ma_gv = '{maLienKet}'")) == 0)
                            {
                                fail++;
                                i++;
                                continue;
                            }
                        }
                        else if (role == "ADMIN")
                        {
                            maLienKet = null;
                        }
                        else
                        {
                            fail++;
                            i++;
                            continue;
                        }

                        string sqlInsert = $@"
                    INSERT INTO TaiKhoan(ten_dang_nhap, mat_khau, ma_vai_tro, ma_lien_ket)
                    VALUES('{username}', '{pass}', '{role}', {(maLienKet == null ? "NULL" : $"'{maLienKet}'")})
                ";

                        if (CrudLib.IUDQuery(sqlInsert) > 0)
                            success++;
                        else
                            fail++;

                        i++;
                    }
                }

                MessageBox.Show($"Nhập Excel xong!\nThành công: {success}\nThất bại: {fail}");
                LoadAccount();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi nhập Excel: " + ex.Message);
            }
            finally
            {
                wb.Close(false);
                excel.Quit();

                Marshal.ReleaseComObject(wb);
                Marshal.ReleaseComObject(excel);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string pass = txtPass.Text.Trim();
            string role = cboRole.SelectedValue?.ToString();
            string maLienKet = txtMaLienKet.Text.Trim();

            if (username == "")
            {
                MessageBox.Show("Chọn tài khoản cần sửa!");
                return;
            }

            if (role == null)
            {
                MessageBox.Show("Vui lòng chọn vai trò!");
                return;
            }

            // Kiểm tra mã liên kết theo vai trò
            if (role == "SV")
            {
                string sqlCheckSV = $"SELECT COUNT(*) FROM SinhVien WHERE ma_sv = '{maLienKet}'";
                if (Convert.ToInt32(CrudLib.GetValue(sqlCheckSV)) == 0)
                {
                    MessageBox.Show("Mã sinh viên không tồn tại!");
                    return;
                }
            }
            else if (role == "GV")
            {
                string sqlCheckGV = $"SELECT COUNT(*) FROM GiangVien WHERE ma_gv = '{maLienKet}'";
                if (Convert.ToInt32(CrudLib.GetValue(sqlCheckGV)) == 0)
                {
                    MessageBox.Show("Mã giảng viên không tồn tại!");
                    return;
                }
            }
            else if (role == "ADMIN")
            {
                maLienKet = null;
            }

            string sqlUpdate = $@"
        UPDATE TaiKhoan
        SET mat_khau = '{pass}',
            ma_vai_tro = '{role}',
            ma_lien_ket = {(maLienKet == null ? "NULL" : $"'{maLienKet}'")}
        WHERE ten_dang_nhap = '{username}'
    ";

            int kq = CrudLib.IUDQuery(sqlUpdate);
            if (kq > 0)
            {
                MessageBox.Show("Cập nhật tài khoản thành công!");
                LoadAccount();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();

            if (username == "")
            {
                MessageBox.Show("Chọn tài khoản cần xoá!");
                return;
            }

            DialogResult dr = MessageBox.Show(
                "Bạn có chắc chắn muốn xoá tài khoản này?",
                "Xác nhận xoá",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (dr == DialogResult.Yes)
            {
                string sqlDelete = $"DELETE FROM TaiKhoan WHERE ten_dang_nhap = '{username}'";
                int kq = CrudLib.IUDQuery(sqlDelete);

                if (kq > 0)
                {
                    MessageBox.Show("Xoá tài khoản thành công!");
                    LoadAccount();
                    ClearForm();
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtMaLienKet.Text.Trim();
            string role = cboRole.SelectedValue?.ToString();

            string sql = @"
        SELECT 
            tk.ten_dang_nhap AS [Tên đăng nhập],
            tk.mat_khau AS [Mật khẩu],
            vt.ten_vai_tro AS [Vai trò],
            tk.ma_vai_tro AS [MaVaiTro],
            tk.ma_lien_ket AS [Mã liên kết]
        FROM TaiKhoan tk
        JOIN VaiTro vt ON tk.ma_vai_tro = vt.ma_vai_tro
        WHERE 1 = 1
    ";

            if (keyword != "")
                sql += $" AND tk.ten_dang_nhap LIKE '%{keyword}%'";

            if (role != null)
                sql += $" AND tk.ma_vai_tro = '{role}'";

            DataTable dt = CrudLib.GetDataTable(sql);
            dgvDSAccount.DataSource = dt;
        }

        private void cboRole_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            DataTable dt = CrudLib.GetDataTable(@"
        SELECT 
            ten_dang_nhap AS [Username],
            mat_khau AS [Password],
            ma_vai_tro AS [Role],
            ma_lien_ket AS [MaLienKet]
        FROM TaiKhoan
    ");

            xls.Application excel = new xls.Application();
            excel.Visible = true;
            excel.DisplayAlerts = false;

            xls.Workbook wb = excel.Workbooks.Add(Type.Missing);
            xls.Worksheet ws = (xls.Worksheet)wb.Worksheets[1];
            ws.Name = "TaiKhoan";

            // Header
            ws.Range["A1", "D1"].Merge();
            ws.Range["A1"].Value = "DANH SÁCH TÀI KHOẢN";
            ws.Range["A1"].Font.Bold = true;
            ws.Range["A1"].Font.Size = 16;
            ws.Range["A1"].HorizontalAlignment = xls.XlHAlign.xlHAlignCenter;

            // Tiêu đề cột
            string[] headers = { "USERNAME", "PASSWORD", "ROLE", "MÃ LIÊN KẾT" };
            for (int i = 0; i < headers.Length; i++)
            {
                ws.Cells[3, i + 1] = headers[i];
                ws.Columns[i + 1].ColumnWidth = 25;
            }

            // Đổ dữ liệu
            object[,] arr = new object[dt.Rows.Count, dt.Columns.Count];
            for (int r = 0; r < dt.Rows.Count; r++)
                for (int c = 0; c < dt.Columns.Count; c++)
                    arr[r, c] = dt.Rows[r][c];

            xls.Range c1 = (xls.Range)ws.Cells[4, 1];
            xls.Range c2 = (xls.Range)ws.Cells[dt.Rows.Count + 3, dt.Columns.Count];
            ws.Range[c1, c2].Value = arr;

            ws.Range["A3", "D3"].Font.Bold = true;
            ws.Range["A3", "D3"].Borders.LineStyle = xls.XlLineStyle.xlContinuous;
        }
    }
}

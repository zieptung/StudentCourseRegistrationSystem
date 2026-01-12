using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataTable = System.Data.DataTable;
using ex_cel = Microsoft.Office.Interop.Excel;
using xls = Microsoft.Office.Interop.Excel;

namespace StudentCourseRegistrationSystem
{
    public partial class FormQLND : Form
    {
        public FormQLND()
        {
            InitializeComponent();
        }

        private void FormQLND_Load(object sender, EventArgs e)
        {
            LoadVaiTro();
            LoadTrangThai();
            LoadTaiKhoan();
        }

        private void LoadVaiTro()
        {
            cboVaiTro.Items.Clear();
            cboVaiTro.Items.Add("AD");
            cboVaiTro.Items.Add("SV");
            cboVaiTro.SelectedIndex = 0;
        }

        private void LoadTrangThai()
        {
            cboTrangThai.Items.Clear();
            cboTrangThai.Items.Add("Hoạt động");
            cboTrangThai.Items.Add("Khoá");
            cboTrangThai.SelectedIndex = 0;
        }

        private void LoadTaiKhoan()
        {
            using (SqlConnection conn = DbConnection.GetConnection())
            {
                string sql =
                    "SELECT username, password, ho_ten, vai_tro, ma_lien_ket, trang_thai " + "FROM Admin";

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvTK.DataSource = dt;
                dgvTK.Columns["username"].HeaderText = "Tên tài khoản";
                dgvTK.Columns["password"].HeaderText = "Mật khẩu";
                dgvTK.Columns["ho_ten"].HeaderText = "Họ tên";
                dgvTK.Columns["vai_tro"].HeaderText = "Vai trò";
                dgvTK.Columns["ma_lien_ket"].HeaderText = "Mã liên kết";
                dgvTK.Columns["trang_thai"].HeaderText = "Trạng thái";
                dgvTK.Refresh();
            }
        }

        private void ClearForm()
        {
            txtUsername.Clear();
            txtPass.Clear();
            txtHoTen.Clear();
            txtMaLienKet.Clear();
            txtTim.Clear();

            cboVaiTro.SelectedIndex = 0;
            cboTrangThai.SelectedIndex = 0;

            txtUsername.Enabled = true;
            txtUsername.Focus();
        }

        private int CheckTrungUser(string user)
        {
            using (SqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                string sql = "SELECT COUNT(*) FROM Admin WHERE username='" + user + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        private int CheckTonTaiSV(string maSv)
        {
            using (SqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                string sql = "SELECT COUNT(*) FROM SinhVien WHERE ma_sv='" + maSv + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string user = txtUsername.Text.Trim();
            string pass = txtPass.Text.Trim();
            string hoten = txtHoTen.Text.Trim();
            string role = cboVaiTro.Text.Trim();
            string maLienKet = txtMaLienKet.Text.Trim();
            string trangThai = cboTrangThai.Text.Trim();
            string maLK = (maLienKet == "") ? "NULL" : "N'" + maLienKet + "'";

            if (user == "" || pass == "")
            {
                MessageBox.Show("Nhập đủ Username và Password!");
                return;
            }

            if (CheckTrungUser(user) > 0)
            {
                MessageBox.Show("Tên đăng nhập đã tồn tại!");
                txtUsername.Focus();
                return;
            }

            if (role == "SV")
            {
                if (maLienKet == "")
                {
                    MessageBox.Show("Tài khoản SV phải có mã liên kết (mã SV)!");
                    txtMaLienKet.Focus();
                    return;
                }

                if (CheckTonTaiSV(maLienKet) == 0)
                {
                    MessageBox.Show("Mã sinh viên không tồn tại!");
                    txtMaLienKet.Focus();
                    return;
                }
            }
            else
            {
                maLienKet = "";
            }

            using (SqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();

                string sql = "INSERT INTO Admin(username, password, ho_ten, vai_tro, ma_lien_ket, trang_thai) VALUES (" + "'" + user + "', " + "'" + pass + "', " + "N'" + hoten + "', " + "'" + role + "', " + maLK + ", " + "N'" + trangThai + "'" + ")";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Thêm tài khoản thành công!");
            LoadTaiKhoan();
            ClearForm();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string user = txtUsername.Text.Trim();
            string pass = txtPass.Text.Trim();
            string hoten = txtHoTen.Text.Trim();
            string role = cboVaiTro.Text.Trim();
            string maLienKet = txtMaLienKet.Text.Trim();
            string trangThai = cboTrangThai.Text.Trim();

            string maLK= (maLienKet == "") ? "NULL" : "'" + maLienKet + "'";

            if (user == "")
            {
                MessageBox.Show("Chọn tài khoản cần sửa!");
                return;
            }

            if (role == "SV")
            {
                if (maLienKet == "")
                {
                    MessageBox.Show("Tài khoản SV phải có mã liên kết (mã SV)!");
                    return;
                }

                if (CheckTonTaiSV(maLienKet) == 0)
                {
                    MessageBox.Show("Mã sinh viên không tồn tại!");
                    return;
                }
            }
            else
            {
                maLienKet = "";
            }

            using (SqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();

                string sql =
                    "UPDATE Admin SET " +
                    "password='" + pass + "', " +
                    "ho_ten=N'" + hoten + "', " +
                    "vai_tro='" + role + "', " +
                    "ma_lien_ket=" + maLK + ", " +
                    "trang_thai=N'" + trangThai + "' " +
                    "WHERE username='" + user + "'";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Sửa thành công!");
            LoadTaiKhoan();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string user = txtUsername.Text.Trim();
            if (user == "")
            {
                MessageBox.Show("Chọn tài khoản cần xóa!");
                return;
            }

            DialogResult r = MessageBox.Show("Chắc chắn xóa tài khoản này?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.No) return;

            using (SqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                string sql = "DELETE FROM Admin WHERE username='" + user + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Xóa thành công!");
            LoadTaiKhoan();
            ClearForm();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string key = txtTim.Text.Trim();

            using (SqlConnection conn = DbConnection.GetConnection())
            {
                string sql =
                    "SELECT username, password, ho_ten, vai_tro, ma_lien_ket, trang_thai " +
                    "FROM Admin " +
                    "WHERE username LIKE '%" + key + "%' OR ho_ten LIKE N'%" + key + "%'";

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvTK.DataSource = dt;
                dgvTK.Refresh();
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearForm();
            LoadTaiKhoan();
        }

        private void dgvTK_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dgvTK.Rows[e.RowIndex];

            txtUsername.Text = row.Cells["username"].Value.ToString();
            txtPass.Text = row.Cells["password"].Value.ToString();
            txtHoTen.Text = row.Cells["ho_ten"].Value == DBNull.Value ? "" : row.Cells["ho_ten"].Value.ToString();
            cboVaiTro.Text = row.Cells["vai_tro"].Value == DBNull.Value ? "AD" : row.Cells["vai_tro"].Value.ToString();
            txtMaLienKet.Text = row.Cells["ma_lien_ket"].Value == DBNull.Value ? "" : row.Cells["ma_lien_ket"].Value.ToString();

            string trangThai = "";

            if (row.Cells["trang_thai"].Value != DBNull.Value)
                trangThai = row.Cells["trang_thai"].Value.ToString();

            if (trangThai == "Hoạt động")
                cboTrangThai.SelectedIndex = 0;
            else
                cboTrangThai.SelectedIndex = 1;


            txtUsername.Enabled = false;
        }

        public void ExportExcel(DataTable tb, string sheetname)
        {
            //Tạo các đối tượng Excel
            ex_cel.Application oExcel = new ex_cel.Application();
            ex_cel.Workbooks oBooks;
            ex_cel.Sheets oSheets;
            ex_cel.Workbook oBook;
            ex_cel.Worksheet oSheet;

            //Tạo mới một Excel WorkBook 
            oExcel.Visible = true;
            oExcel.DisplayAlerts = false;
            oExcel.Application.SheetsInNewWorkbook = 1;
            oBooks = oExcel.Workbooks;
            oBook = (ex_cel.Workbook)(oExcel.Workbooks.Add(Type.Missing));
            oSheets = oBook.Worksheets;
            oSheet = (ex_cel.Worksheet)oSheets.get_Item(1);
            oSheet.Name = sheetname;

            // Tạo phần đầu nếu muốn
            ex_cel.Range head = oSheet.get_Range("A1", "F1");
            head.MergeCells = true;
            head.Value2 = "DANH SÁCH TÀI KHOẢN";
            head.Font.Bold = true;
            head.Font.Name = "Tahoma";
            head.Font.Size = "16";
            head.HorizontalAlignment = ex_cel.XlHAlign.xlHAlignCenter;

            // Tạo tiêu đề cột 
            ex_cel.Range cl1 = oSheet.get_Range("A3", "A3");
            cl1.Value2 = "TÊN TÀI KHOẢN";
            cl1.ColumnWidth = 7.5;

            ex_cel.Range cl2 = oSheet.get_Range("B3", "B3");
            cl2.Value2 = "MẬT KHẨU";
            cl2.ColumnWidth = 25.0;

            ex_cel.Range cl3 = oSheet.get_Range("C3", "C3");
            cl3.Value2 = "HỌ TÊN";
            cl3.ColumnWidth = 40.0;

            ex_cel.Range cl4 = oSheet.get_Range("D3", "D3");
            cl4.Value2 = "VAI TRÒ";
            cl4.ColumnWidth = 15.0;

            ex_cel.Range cl5 = oSheet.get_Range("E3", "E3");
            cl5.Value2 = "MÃ SINH VIÊN";
            cl5.ColumnWidth = 15.0;

            ex_cel.Range cl6 = oSheet.get_Range("F3", "F3");
            cl6.Value2 = "TRẠNG THÁI";
            cl6.ColumnWidth = 15.0;

            ex_cel.Range rowHead = oSheet.get_Range("A3", "F3");
            rowHead.Font.Bold = true;

            // Kẻ viền
            rowHead.Borders.LineStyle = ex_cel.Constants.xlSolid;

            // Thiết lập màu nền
            rowHead.Interior.ColorIndex = 15;
            rowHead.HorizontalAlignment = ex_cel.XlHAlign.xlHAlignCenter;
            // Tạo mảng đối tượng để lưu dữ toàn bồ dữ liệu trong DataTable,
            // vì dữ liệu được được gán vào các Cell trong Excel phải thông qua object thuần.

            object[,] arr = new object[tb.Rows.Count, tb.Columns.Count];

            //Chuyển dữ liệu từ DataTable vào mảng đối tượng
            for (int r = 0; r < tb.Rows.Count; r++)
            {
                DataRow dr = tb.Rows[r];
                for (int c = 0; c < tb.Columns.Count; c++)

                {
                    if (c == 5)
                        arr[r, c] = "'" + dr[c];
                    else
                        arr[r, c] = dr[c];

                }
            }

            //Thiết lập vùng điền dữ liệu
            int rowStart = 4;
            int columnStart = 1;
            int rowEnd = rowStart + tb.Rows.Count - 1;
            int columnEnd = tb.Columns.Count;

            // Ô bắt đầu điền dữ liệu
            ex_cel.Range c1 = (ex_cel.Range)oSheet.Cells[rowStart, columnStart];

            // Ô kết thúc điền dữ liệu
            ex_cel.Range c2 = (ex_cel.Range)oSheet.Cells[rowEnd, columnEnd];

            // Lấy về vùng điền dữ liệu
            ex_cel.Range range = oSheet.get_Range(c1, c2);

            //Điền dữ liệu vào vùng đã thiết lập
            range.Value2 = arr;

            // Kẻ viền
            range.Borders.LineStyle = ex_cel.Constants.xlSolid;

            // Căn giữa cột STT
            ex_cel.Range c3 = (ex_cel.Range)oSheet.Cells[rowEnd, columnStart];
            ex_cel.Range c4 = oSheet.get_Range(c1, c3);
            oSheet.get_Range(c3, c4).HorizontalAlignment = ex_cel.XlHAlign.xlHAlignCenter;

            //Định dạng ngày sinh
            //ex_cel.Range cl_ngs = oSheet.get_Range("E" + rowStart, "E" + rowEnd);
            //cl_ngs.Columns.NumberFormat = "dd/mm/yyyy";


        }

        private void dgvTK_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            if (dgvTK.DataSource == null)
            {
                MessageBox.Show("Không có dữ liệu để xuất!");
                return;
            }

            DataTable tb = (DataTable)dgvTK.DataSource;

            if (tb.Rows.Count == 0)
            {
                MessageBox.Show("Danh sách rỗng, không có gì để xuất!");
                return;
            }

            ExportExcel(tb, "Tài khoản người dùng");
        }

        string filename = "";

        private void ImportExcel()
        {
            if (filename == null || filename.Trim() == "")
            {
                MessageBox.Show("Chưa chọn file");
                return;
            }

            xls.Application Excel = new xls.Application();
            xls.Workbook wb = Excel.Workbooks.Open(filename);

            try
            {
                foreach (xls.Worksheet wsheet in wb.Worksheets)
                {
                    int i = 2; // bắt đầu đọc từ dòng 2

                    while (true)
                    {
                        // dừng khi username & password trống
                        if (wsheet.Cells[i, 1].Value == null && wsheet.Cells[i, 2].Value == null)
                            break;

                        string user = (wsheet.Cells[i, 1].Value == null) ? "" : wsheet.Cells[i, 1].Value.ToString().Trim();
                        string pass = (wsheet.Cells[i, 2].Value == null) ? "" : wsheet.Cells[i, 2].Value.ToString().Trim();
                        string hoten = (wsheet.Cells[i, 3].Value == null) ? "" : wsheet.Cells[i, 3].Value.ToString().Trim();
                        string role = (wsheet.Cells[i, 4].Value == null) ? "" : wsheet.Cells[i, 4].Value.ToString().Trim();
                        string maLK = (wsheet.Cells[i, 5].Value == null) ? "" : wsheet.Cells[i, 5].Value.ToString().Trim();
                        string tt = (wsheet.Cells[i, 6].Value == null) ? "" : wsheet.Cells[i, 6].Value.ToString().Trim();

                        ThemMoiTaiKhoan(user, pass, hoten, role, maLK, tt);

                        i++;
                    }

                    Marshal.ReleaseComObject(wsheet);
                }

                MessageBox.Show("Nhập Excel tài khoản thành công!");
                LoadTaiKhoan(); // hàm load dgv tài khoản của m
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đọc Excel: " + ex.Message);
            }

            wb.Close(false);
            Excel.Quit();
            Marshal.ReleaseComObject(wb);
            Marshal.ReleaseComObject(Excel);
        }

        private void ThemMoiTaiKhoan(string user, string pass, string hoten, string role, string maLienKet, string trangThai)
        {
            if (user == "" || pass == "") return;

            using (SqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();

                // check trùng username
                string check = "SELECT COUNT(*) FROM Admin WHERE username='" + user + "'";
                SqlCommand cmdCheck = new SqlCommand(check, conn);
                int kq = (int)cmdCheck.ExecuteScalar();
                cmdCheck.Dispose();

                if (kq == 0)
                {
                    // nếu không có mã liên kết thì NULL
                    string maLK = (maLienKet == "") ? "NULL" : "N'" + maLienKet + "'";

                    string sql =
                        "INSERT INTO Admin(username,password,ho_ten,vai_tro,ma_lien_ket,trang_thai) VALUES(" +
                        "'" + user + "'," +
                        "'" + pass + "'," +
                        "N'" + hoten + "'," +
                        "'" + role + "'," +
                        maLK + "," +
                        "N'" + trangThai + "'" +
                        ")";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }

                conn.Close();
            }
        }

        private void btnNhap_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel Files|*.xls;*.xlsx";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filename = ofd.FileName;
                ImportExcel();
            }
        }
    }
}

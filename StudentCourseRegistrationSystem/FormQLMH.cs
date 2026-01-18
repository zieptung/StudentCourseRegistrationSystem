using Microsoft.Office.Interop.Excel;
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
    public partial class FormQLMH : Form
    {
        public FormQLMH()
        {
            InitializeComponent();
        }

        private void FormQLMH_Load(object sender, EventArgs e)
        {
            LoadMonHoc();
        }

        private void LoadMonHoc()
        {
            using (SqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                string sql = "SELECT ma_mon, ten_mon, so_tin_chi FROM MonHoc";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvMonHoc.DataSource = dt;
                dgvMonHoc.Columns["ma_mon"].HeaderText = "Mã môn";
                dgvMonHoc.Columns["ten_mon"].HeaderText = "Tên môn";
                dgvMonHoc.Columns["so_tin_chi"].HeaderText = "Số tín chỉ";
                dgvMonHoc.Refresh();
            }
        }

        private void ClearForm()
        {
            txtMaMon.Clear();
            txtTenMon.Clear();
            txtSoTinChi.Clear();
            txtTimKiem1.Clear();
            txtMaMon.Enabled = true;
            txtMaMon.Focus();
        }

        private int CheckTrungMa(string ma)
        {
            using (SqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                string sql = "SELECT COUNT(*) FROM MonHoc WHERE ma_mon = '" + ma + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                return (int)cmd.ExecuteScalar();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string ma = txtMaMon.Text.Trim();
            string ten = txtTenMon.Text.Trim();
            string stc = txtSoTinChi.Text.Trim();
            int soTinChi;
            try
            {
                soTinChi = int.Parse(stc);
            }
            catch
            {
                MessageBox.Show("Số tín chỉ phải là số!");
                return;
            }   

            if (ma == "" || ten == "" || stc == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            if (CheckTrungMa(ma) > 0)
            {
                MessageBox.Show("Mã môn đã tồn tại!");
                txtMaMon.Focus();
                return;
            }

            using (SqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                string sql = "INSERT INTO MonHoc(ma_mon, ten_mon, so_tin_chi) " + "VALUES('" + ma + "', N'" + ten + "', " + soTinChi + ")";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Thêm môn học thành công!");
            LoadMonHoc();
            ClearForm();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string ma = txtMaMon.Text.Trim();
            string ten = txtTenMon.Text.Trim();
            string stc = txtSoTinChi.Text.Trim();
            int soTinChi;
            try
            {
                soTinChi = int.Parse(stc);
            }
            catch
            {
                MessageBox.Show("Số tín chỉ phải là số!");
                return;
            }

            if (ma == "")
            {
                MessageBox.Show("Vui lòng chọn môn học cần sửa!");
                return;
            }

            if (ten == "" || stc == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            using (SqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                string sql = "UPDATE MonHoc SET " + "ten_mon = N'" + ten + "', " + "so_tin_chi = " + soTinChi + " " + "WHERE ma_mon = '" + ma + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                int rows = cmd.ExecuteNonQuery();

                if (rows == 0)
                {
                    MessageBox.Show("Không tìm thấy môn học để sửa!");
                    return;
                }
            }

            MessageBox.Show("Sửa môn học thành công!");
            LoadMonHoc();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string ma = txtMaMon.Text.Trim();
            if (ma == "")
            {
                MessageBox.Show("Vui lòng chọn môn học cần xoá!");
                return;
            }

            DialogResult rs = MessageBox.Show("Bạn có chắc chắn muốn xoá môn học này?", "Xác nhận xoá", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (rs == DialogResult.No) return;

            using (SqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();

                string sql = "DELETE FROM MonHoc WHERE ma_mon = '" + ma + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Xoá môn học thành công!");
            LoadMonHoc();
            ClearForm();
        }
        private void btnTim_Click(object sender, EventArgs e)
        {
            string ma = txtTimKiem1.Text.Trim();
            string ten = txtTimKiem2.Text.Trim();   

            using (SqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                string sql ="SELECT ma_mon, ten_mon FROM MonHoc " + "WHERE ma_mon LIKE '%" + ma + "%' " + "AND ten_mon LIKE N'%" + ten + "%'";
                
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvMonHoc.DataSource = dt;
                dgvMonHoc.Refresh();
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadMonHoc();
            ClearForm();
        }

        private void dgvMonHoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if (i < 0) return;

            txtMaMon.Text = dgvMonHoc.Rows[i].Cells["ma_mon"].Value.ToString();
            txtTenMon.Text = dgvMonHoc.Rows[i].Cells["ten_mon"].Value.ToString();
            txtSoTinChi.Text = dgvMonHoc.Rows[i].Cells["so_tin_chi"].Value.ToString();

            txtMaMon.Enabled = false;
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
            ex_cel.Range head = oSheet.get_Range("A1", "D1");
            head.MergeCells = true;
            head.Value2 = "DANH SÁCH MÔN HỌC";
            head.Font.Bold = true;
            head.Font.Name = "Tahoma";
            head.Font.Size = "16";
            head.HorizontalAlignment = ex_cel.XlHAlign.xlHAlignCenter;

            // Tạo tiêu đề cột 
            ex_cel.Range cl1 = oSheet.get_Range("A3", "A3");
            cl1.Value2 = "STT";
            cl1.ColumnWidth = 7.5;

            ex_cel.Range cl2 = oSheet.get_Range("B3", "B3");
            cl2.Value2 = "MÃ MÔN";
            cl2.ColumnWidth = 25.0;

            ex_cel.Range cl3 = oSheet.get_Range("C3", "C3");
            cl3.Value2 = "TÊN MÔN";
            cl3.ColumnWidth = 40.0;

            ex_cel.Range cl4 = oSheet.get_Range("D3", "D3");
            cl4.Value2 = "SỐ TÍN CHỈ";
            cl4.ColumnWidth = 15.0;

            ex_cel.Range rowHead = oSheet.get_Range("A3", "D3");
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

        private void btnXuat_Click(object sender, EventArgs e)
        {
            string ma = txtMaMon.Text.Trim();
            string ten = txtTenMon.Text.Trim();
            string stc = txtSoTinChi.Text.Trim();

            using (SqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                string sql = "SELECT ROW_NUMBER() OVER(ORDER BY ma_mon) STT,* FROM MonHoc WHERE ma_mon LIKE '%" + ma + "%' and ten_mon LIKE N'%" + ten + "%' and so_tin_chi LIKE '%" + stc + "%'";

                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataTable tb = new DataTable();
                da.Fill(tb);

                cmd.Dispose();
                conn.Close();
                ExportExcel(tb, "Môn học");
            }    
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

                    do
                    {
                        // dừng khi cột A và B trống
                        if (wsheet.Cells[i, 1].Value == null && wsheet.Cells[i, 2].Value == null)
                            break;

                        string ma = wsheet.Cells[i, 1].Value.ToString().Trim();
                        string ten = wsheet.Cells[i, 2].Value.ToString().Trim();
                        string stc = wsheet.Cells[i, 3].Value.ToString().Trim();

                        // đổ vào DB
                        ThemmoiMonHoc(ma, ten, stc);

                        i++;
                    }
                    while (true);

                    Marshal.ReleaseComObject(wsheet);
                }

                MessageBox.Show("Nhập Excel thành công!");
                LoadMonHoc();
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

        private void ThemmoiMonHoc(string ma, string ten, string stc)
        {
            if (ma == "" || ten == "") return;

            using (SqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                // check trùng mã
                string check = "SELECT COUNT(*) FROM MonHoc WHERE ma_mon='" + ma + "'";
                SqlCommand cmdCheck = new SqlCommand(check, conn);
                int kq = (int)cmdCheck.ExecuteScalar();
                cmdCheck.Dispose();

                if (kq == 0)
                {
                    string sql = "INSERT INTO MonHoc VALUES('" + ma + "',N'" + ten + "','" + stc + "')";

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

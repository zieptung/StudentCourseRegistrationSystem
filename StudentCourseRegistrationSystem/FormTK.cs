using Microsoft.Office.Interop.Excel;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using DataTable = System.Data.DataTable;
using ex_cel = Microsoft.Office.Interop.Excel;

namespace StudentCourseRegistrationSystem
{
    public partial class FormTK : Form
    {
        private string cacheHocKy = "";
        private string cacheNamHoc = "";
        private int cacheTong = 0;
        private DataTable cacheTable = null;

        public FormTK()
        {
            InitializeComponent();
        }

        private void FormThongKe_Load(object sender, EventArgs e)
        {
            LoadHocKy();
            if (cboHocKy.Items.Count > 0)
            {
                cboHocKy.SelectedIndex = 0;
                ThongKe();
            }
        }

        // ===================== LOAD HỌC KỲ =====================
        private void LoadHocKy()
        {
            using (SqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                string sql = "SELECT ma_hoc_ky FROM HocKy ORDER BY nam_hoc, ma_hoc_ky";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    cboHocKy.Items.Clear();
                    while (rd.Read())
                        cboHocKy.Items.Add(rd["ma_hoc_ky"].ToString());
                }
            }
        }

        private string GetNamHocByHocKy(string maHocKy)
        {
            using (SqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                string sql = "SELECT nam_hoc FROM HocKy WHERE ma_hoc_ky = @hk";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@hk", maHocKy);
                    object val = cmd.ExecuteScalar();
                    return val == null ? "" : val.ToString();
                }
            }
        }

        // ===================== THỐNG KÊ =====================
        private void ThongKe()
        {
            if (cboHocKy.SelectedItem == null) return;

            string hk = cboHocKy.SelectedItem.ToString();
            string namHoc = GetNamHocByHocKy(hk);

            using (SqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();

                // 1) Tổng lượt đăng ký
                string sqlTong = @"
                    SELECT COUNT(*) AS tong
                    FROM DangKyLopHocPhan dk
                    JOIN LopHocPhan lhp ON dk.ma_lhp = lhp.ma_lhp
                    WHERE lhp.ma_hoc_ky = @hk
                      AND dk.trang_thai = N'Đã đăng ký'
                ";

                int tong = 0;
                using (SqlCommand cmdTong = new SqlCommand(sqlTong, conn))
                {
                    cmdTong.Parameters.AddWithValue("@hk", hk);
                    object val = cmdTong.ExecuteScalar();
                    tong = val == null ? 0 : Convert.ToInt32(val);
                }

                // 2) Bảng thống kê theo môn
                string sql = @"
                    SELECT 
                        @hk AS hoc_ky,
                        @namhoc AS nam_hoc,
                        @tong AS tong_luot_dang_ky,
                        mh.ten_mon AS mon_hoc,
                        COUNT(DISTINCT dk.ma_sv) AS so_sv
                    FROM DangKyLopHocPhan dk
                    JOIN LopHocPhan lhp ON dk.ma_lhp = lhp.ma_lhp
                    JOIN MonHoc mh ON lhp.ma_mon = mh.ma_mon
                    WHERE lhp.ma_hoc_ky = @hk
                      AND dk.trang_thai = N'Đã đăng ký'
                    GROUP BY mh.ten_mon
                    ORDER BY so_sv DESC
                ";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@hk", hk);
                    cmd.Parameters.AddWithValue("@namhoc", namHoc);
                    cmd.Parameters.AddWithValue("@tong", tong);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // bind grid
                    dgvThongKe.AutoGenerateColumns = true;
                    dgvThongKe.DataSource = dt;

                    // header đẹp như FormQLGV
                    if (dgvThongKe.Columns["hoc_ky"] != null) dgvThongKe.Columns["hoc_ky"].HeaderText = "Học kỳ";
                    if (dgvThongKe.Columns["nam_hoc"] != null) dgvThongKe.Columns["nam_hoc"].HeaderText = "Năm học";
                    if (dgvThongKe.Columns["tong_luot_dang_ky"] != null) dgvThongKe.Columns["tong_luot_dang_ky"].HeaderText = "Tổng lượt đăng ký";
                    if (dgvThongKe.Columns["mon_hoc"] != null) dgvThongKe.Columns["mon_hoc"].HeaderText = "Môn học";
                    if (dgvThongKe.Columns["so_sv"] != null) dgvThongKe.Columns["so_sv"].HeaderText = "Số SV";

                    dgvThongKe.Refresh();

                    // set textbox
                    txtNamHoc.Text = namHoc;
                    txtTongLuot.Text = tong.ToString();

                    // cache để export
                    cacheHocKy = hk;
                    cacheNamHoc = namHoc;
                    cacheTong = tong;
                    cacheTable = dt;
                }
            }
        }

        // ===================== EVENTS =====================
        private void cboHocKy_SelectedIndexChanged(object sender, EventArgs e)
        {
            ThongKe();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            ThongKe();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtNamHoc.Clear();
            txtTongLuot.Text = "0";
            dgvThongKe.DataSource = null;

            cacheHocKy = "";
            cacheNamHoc = "";
            cacheTong = 0;
            cacheTable = null;
        }

        // ===================== EXPORT EXCEL (Interop) =====================
        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            if (cacheTable == null || cacheTable.Rows.Count == 0)
            {
                MessageBox.Show("Chưa có dữ liệu. Bấm Thống kê trước.");
                return;
            }

            ExportExcel_ThongKe(cacheTable, "Thống kê");
        }

        // theo style ExportExcel của bạn, nhưng cột là A->E
        public void ExportExcel_ThongKe(DataTable tb, string sheetname)
        {
            ex_cel.Application oExcel = new ex_cel.Application();
            ex_cel.Workbook oBook = (ex_cel.Workbook)(oExcel.Workbooks.Add(Type.Missing));
            ex_cel.Worksheet oSheet = (ex_cel.Worksheet)oBook.Worksheets.get_Item(1);

            oExcel.Visible = true;
            oExcel.DisplayAlerts = false;
            oSheet.Name = sheetname;

            // ===== Title =====
            ex_cel.Range head = oSheet.get_Range("A1", "E1");
            head.MergeCells = true;
            head.Value2 = "THỐNG KÊ ĐĂNG KÝ THEO MÔN";
            head.Font.Bold = true;
            head.Font.Name = "Tahoma";
            head.Font.Size = 16;
            head.HorizontalAlignment = ex_cel.XlHAlign.xlHAlignCenter;

            // ===== Header row =====
            oSheet.Cells[2, 1] = "HỌC KỲ";
            oSheet.Cells[2, 2] = "NĂM HỌC";
            oSheet.Cells[2, 3] = "TỔNG LƯỢT ĐK";
            oSheet.Cells[2, 4] = "MÔN HỌC";
            oSheet.Cells[2, 5] = "SỐ SV";

            ex_cel.Range rowHead = oSheet.get_Range("A2", "E2");
            rowHead.Font.Bold = true;
            rowHead.Borders.LineStyle = ex_cel.Constants.xlSolid;
            rowHead.Interior.ColorIndex = 15;
            rowHead.HorizontalAlignment = ex_cel.XlHAlign.xlHAlignCenter;

            // ===== Data =====
            object[,] arr = new object[tb.Rows.Count, tb.Columns.Count];
            for (int r = 0; r < tb.Rows.Count; r++)
            {
                DataRow dr = tb.Rows[r];
                for (int c = 0; c < tb.Columns.Count; c++)
                {
                    arr[r, c] = dr[c];
                }
            }

            int rowStart = 3, colStart = 1;
            int rowEnd = rowStart + tb.Rows.Count - 1;
            int colEnd = tb.Columns.Count;

            ex_cel.Range c1 = (ex_cel.Range)oSheet.Cells[rowStart, colStart];
            ex_cel.Range c2 = (ex_cel.Range)oSheet.Cells[rowEnd, colEnd];
            ex_cel.Range range = oSheet.get_Range(c1, c2);

            range.Value2 = arr;
            range.Borders.LineStyle = ex_cel.Constants.xlSolid;

            // auto fit
            oSheet.Columns.AutoFit();
        }
    }
}
using Microsoft.Office.Interop.Excel;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using DataTable = System.Data.DataTable;
using ex_cel = Microsoft.Office.Interop.Excel;
using xls = Microsoft.Office.Interop.Excel;

namespace StudentCourseRegistrationSystem
{
    public partial class FormQLGV : Form
    {
        string filename = "";

        public FormQLGV()
        {
            InitializeComponent();

            // Nếu designer có gắn CellFormatting thì vẫn OK, nhưng giờ ta không cần nữa.
            // Nếu bạn muốn giữ cũng được, nhưng mình sẽ KHÔNG dựa vào nó nữa.
        }

        private void FormQLGV_Load(object sender, EventArgs e)
        {
            cbTrangThai.Items.Clear();
            cbTrangThai.Items.Add("Hoạt động"); // 1
            cbTrangThai.Items.Add("Khóa");      // 0
            cbTrangThai.SelectedIndex = 0;

            LoadGiangVien();
        }

        // ====== 1) LOAD: trả về trang_thai dạng chữ ======
        private void LoadGiangVien()
        {
            using (SqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();

                string sql = @"
                    SELECT 
                        ma_gv, 
                        ten_gv, 
                        hoc_vi, 
                        ISNULL(hoc_ham,'') AS hoc_ham, 
                        email, 
                        dien_thoai, 
                        ma_khoa, 
                        CASE WHEN trang_thai = 1 THEN N'Hoạt động' ELSE N'Khóa' END AS trang_thai
                    FROM GiangVien
                ";

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvGiangVien.AutoGenerateColumns = true;
                dgvGiangVien.DataSource = dt;

                // ÉP cột trạng_thai về TEXT (nếu lỡ đang là checkbox do designer)
                EnsureTrangThaiIsTextColumn();

                dgvGiangVien.Columns["ma_gv"].HeaderText = "Mã GV";
                dgvGiangVien.Columns["ten_gv"].HeaderText = "Tên GV";
                dgvGiangVien.Columns["hoc_vi"].HeaderText = "Học vị";
                dgvGiangVien.Columns["hoc_ham"].HeaderText = "Học hàm";
                dgvGiangVien.Columns["email"].HeaderText = "Email";
                dgvGiangVien.Columns["dien_thoai"].HeaderText = "Điện thoại";
                dgvGiangVien.Columns["ma_khoa"].HeaderText = "Mã khoa";
                dgvGiangVien.Columns["trang_thai"].HeaderText = "Trạng thái";

                dgvGiangVien.Refresh();
            }
        }

        // Nếu designer đã tạo checkbox column cho trang_thai → thay lại thành textbox column
        private void EnsureTrangThaiIsTextColumn()
        {
            if (dgvGiangVien.Columns["trang_thai"] is DataGridViewCheckBoxColumn)
            {
                int idx = dgvGiangVien.Columns["trang_thai"].Index;
                dgvGiangVien.Columns.Remove("trang_thai");

                var col = new DataGridViewTextBoxColumn();
                col.Name = "trang_thai";
                col.DataPropertyName = "trang_thai";
                col.HeaderText = "Trạng thái";

                dgvGiangVien.Columns.Insert(idx, col);
            }
        }

        private void ClearForm()
        {
            txtMaGV.Clear();
            txtTenGV.Clear();
            txtHocVi.Clear();
            txtHocHam.Clear();
            txtEmail.Clear();
            txtDienThoai.Clear();
            txtMaKhoa.Clear();
            txtTim.Clear();
            cbTrangThai.SelectedIndex = 0;

            txtMaGV.Enabled = true;
            txtMaGV.Focus();
        }

        private int CheckTrungMa(string ma)
        {
            using (SqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                string sql = "SELECT COUNT(*) FROM GiangVien WHERE ma_gv = @ma";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@ma", ma);
                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        // ====== helper: map combobox -> bit ======
        private int GetTrangThaiBitFromCombo()
        {
            // index 0: Hoạt động -> 1 ; index 1: Khóa -> 0
            return (cbTrangThai.SelectedIndex == 0) ? 1 : 0;
        }

        // ====== 2) THÊM ======
        private void btnThem_Click(object sender, EventArgs e)
        {
            string ma = txtMaGV.Text.Trim();
            string ten = txtTenGV.Text.Trim();
            string hv = txtHocVi.Text.Trim();
            string hh = txtHocHam.Text.Trim();
            string email = txtEmail.Text.Trim();
            string dt = txtDienThoai.Text.Trim();
            string khoa = txtMaKhoa.Text.Trim();
            int tt = GetTrangThaiBitFromCombo();

            if (ma == "" || ten == "" || khoa == "")
            {
                MessageBox.Show("Vui lòng nhập đủ: Mã GV, Tên GV, Mã khoa!");
                return;
            }

            if (CheckTrungMa(ma) > 0)
            {
                MessageBox.Show("Mã giảng viên đã tồn tại!");
                txtMaGV.Focus();
                return;
            }

            using (SqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                string sql = @"
                    INSERT INTO GiangVien(ma_gv, ten_gv, hoc_vi, hoc_ham, email, dien_thoai, ma_khoa, trang_thai)
                    VALUES(@ma, @ten, @hv, @hh, @email, @dt, @khoa, @tt)
                ";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@ma", ma);
                    cmd.Parameters.AddWithValue("@ten", ten);
                    cmd.Parameters.AddWithValue("@hv", hv);
                    cmd.Parameters.AddWithValue("@hh", (object)hh ?? DBNull.Value);
                    if (hh == "") cmd.Parameters["@hh"].Value = DBNull.Value;

                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@dt", dt);
                    cmd.Parameters.AddWithValue("@khoa", khoa);
                    cmd.Parameters.AddWithValue("@tt", tt);

                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Thêm giảng viên thành công!");
            LoadGiangVien();
            ClearForm();
        }

        // ====== 3) SỬA ======
        private void btnSua_Click(object sender, EventArgs e)
        {
            string ma = txtMaGV.Text.Trim();
            string ten = txtTenGV.Text.Trim();
            string hv = txtHocVi.Text.Trim();
            string hh = txtHocHam.Text.Trim();
            string email = txtEmail.Text.Trim();
            string dt = txtDienThoai.Text.Trim();
            string khoa = txtMaKhoa.Text.Trim();
            int tt = GetTrangThaiBitFromCombo();

            if (ma == "")
            {
                MessageBox.Show("Vui lòng chọn giảng viên cần sửa!");
                return;
            }
            if (ten == "" || khoa == "")
            {
                MessageBox.Show("Vui lòng nhập đủ: Tên GV, Mã khoa!");
                return;
            }

            using (SqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                string sql = @"
                    UPDATE GiangVien SET
                        ten_gv = @ten,
                        hoc_vi = @hv,
                        hoc_ham = @hh,
                        email = @email,
                        dien_thoai = @dt,
                        ma_khoa = @khoa,
                        trang_thai = @tt
                    WHERE ma_gv = @ma
                ";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@ma", ma);
                    cmd.Parameters.AddWithValue("@ten", ten);
                    cmd.Parameters.AddWithValue("@hv", hv);

                    cmd.Parameters.AddWithValue("@hh", (object)hh ?? DBNull.Value);
                    if (hh == "") cmd.Parameters["@hh"].Value = DBNull.Value;

                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@dt", dt);
                    cmd.Parameters.AddWithValue("@khoa", khoa);
                    cmd.Parameters.AddWithValue("@tt", tt);

                    int rows = cmd.ExecuteNonQuery();
                    if (rows == 0)
                    {
                        MessageBox.Show("Không tìm thấy giảng viên để sửa!");
                        return;
                    }
                }
            }

            MessageBox.Show("Sửa giảng viên thành công!");
            LoadGiangVien();
        }

        // ====== 4) XOÁ ======
        private void btnXoa_Click(object sender, EventArgs e)
        {
            string ma = txtMaGV.Text.Trim();
            if (ma == "")
            {
                MessageBox.Show("Vui lòng chọn giảng viên cần xoá!");
                return;
            }

            DialogResult rs = MessageBox.Show("Bạn có chắc muốn xoá giảng viên này?", "Xác nhận xoá",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (rs == DialogResult.No) return;

            using (SqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                string sql = "DELETE FROM GiangVien WHERE ma_gv = @ma";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@ma", ma);
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Xoá giảng viên thành công!");
            LoadGiangVien();
            ClearForm();
        }

        // ====== 5) TÌM: vẫn trả về trạng_thai dạng chữ ======
        private void btnTim_Click(object sender, EventArgs e)
        {
            string key = txtTim.Text.Trim();

            using (SqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();

                string sql = @"
                    SELECT 
                        ma_gv, 
                        ten_gv, 
                        hoc_vi, 
                        ISNULL(hoc_ham,'') AS hoc_ham, 
                        email, 
                        dien_thoai, 
                        ma_khoa, 
                        CASE WHEN trang_thai = 1 THEN N'Hoạt động' ELSE N'Khóa' END AS trang_thai
                    FROM GiangVien
                    WHERE ma_gv LIKE @k OR ten_gv LIKE @kN OR ma_khoa LIKE @k
                ";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@k", "%" + key + "%");
                    cmd.Parameters.AddWithValue("@kN", "%" + key + "%");

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvGiangVien.DataSource = dt;
                    EnsureTrangThaiIsTextColumn();
                    dgvGiangVien.Refresh();
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadGiangVien();
            ClearForm();
        }

        // ====== 6) CLICK ROW: vì grid giờ là chữ -> set combo theo chữ ======
        private void dgvGiangVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if (i < 0) return;

            txtMaGV.Text = dgvGiangVien.Rows[i].Cells["ma_gv"].Value?.ToString();
            txtTenGV.Text = dgvGiangVien.Rows[i].Cells["ten_gv"].Value?.ToString();
            txtHocVi.Text = dgvGiangVien.Rows[i].Cells["hoc_vi"].Value?.ToString();
            txtHocHam.Text = dgvGiangVien.Rows[i].Cells["hoc_ham"].Value?.ToString();
            txtEmail.Text = dgvGiangVien.Rows[i].Cells["email"].Value?.ToString();
            txtDienThoai.Text = dgvGiangVien.Rows[i].Cells["dien_thoai"].Value?.ToString();
            txtMaKhoa.Text = dgvGiangVien.Rows[i].Cells["ma_khoa"].Value?.ToString();

            string ttText = dgvGiangVien.Rows[i].Cells["trang_thai"].Value?.ToString();
            cbTrangThai.SelectedIndex = (ttText == "Hoạt động") ? 0 : 1;

            txtMaGV.Enabled = false;
        }

        // ===================== EXPORT EXCEL =====================
        public void ExportExcel(DataTable tb, string sheetname)
        {
            ex_cel.Application oExcel = new ex_cel.Application();
            ex_cel.Workbook oBook = (ex_cel.Workbook)(oExcel.Workbooks.Add(Type.Missing));
            ex_cel.Worksheet oSheet = (ex_cel.Worksheet)oBook.Worksheets.get_Item(1);

            oExcel.Visible = true;
            oExcel.DisplayAlerts = false;
            oSheet.Name = sheetname;

            ex_cel.Range head = oSheet.get_Range("A1", "H1");
            head.MergeCells = true;
            head.Value2 = "DANH SÁCH GIẢNG VIÊN";
            head.Font.Bold = true;
            head.Font.Name = "Tahoma";
            head.Font.Size = "16";
            head.HorizontalAlignment = ex_cel.XlHAlign.xlHAlignCenter;

            oSheet.Cells[2, 1] = "MÃ GV";
            oSheet.Cells[2, 2] = "TÊN GV";
            oSheet.Cells[2, 3] = "HỌC VỊ";
            oSheet.Cells[2, 4] = "HỌC HÀM";
            oSheet.Cells[2, 5] = "EMAIL";
            oSheet.Cells[2, 6] = "ĐIỆN THOẠI";
            oSheet.Cells[2, 7] = "MÃ KHOA";
            oSheet.Cells[2, 8] = "TRẠNG THÁI";

            ex_cel.Range rowHead = oSheet.get_Range("A2", "H2");
            rowHead.Font.Bold = true;
            rowHead.Borders.LineStyle = ex_cel.Constants.xlSolid;
            rowHead.Interior.ColorIndex = 15;
            rowHead.HorizontalAlignment = ex_cel.XlHAlign.xlHAlignCenter;

            object[,] arr = new object[tb.Rows.Count, tb.Columns.Count];
            for (int r = 0; r < tb.Rows.Count; r++)
            {
                DataRow dr = tb.Rows[r];
                for (int c = 0; c < tb.Columns.Count; c++)
                {
                    if (tb.Columns[c].ColumnName == "dien_thoai")
                        arr[r, c] = "'" + dr[c];
                    else
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
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();

                // Xuất luôn chữ để file đẹp
                string sql = @"
                    SELECT 
                        ma_gv, 
                        ten_gv, 
                        hoc_vi, 
                        ISNULL(hoc_ham,'') AS hoc_ham, 
                        email, 
                        dien_thoai, 
                        ma_khoa, 
                        CASE WHEN trang_thai = 1 THEN N'Hoạt động' ELSE N'Khóa' END AS trang_thai
                    FROM GiangVien
                ";

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable tb = new DataTable();
                da.Fill(tb);

                ExportExcel(tb, "Giảng viên");
            }
        }

        // ===================== IMPORT EXCEL =====================
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

        private void ImportExcel()
        {
            if (string.IsNullOrWhiteSpace(filename))
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
                    int i = 3; // đọc từ dòng 3
                    do
                    {
                        if (wsheet.Cells[i, 1].Value == null && wsheet.Cells[i, 2].Value == null) break;

                        string ma = (wsheet.Cells[i, 1].Value ?? "").ToString().Trim();
                        string ten = (wsheet.Cells[i, 2].Value ?? "").ToString().Trim();
                        string hv = (wsheet.Cells[i, 3].Value ?? "").ToString().Trim();
                        string hh = (wsheet.Cells[i, 4].Value ?? "").ToString().Trim();
                        string email = (wsheet.Cells[i, 5].Value ?? "").ToString().Trim();
                        string dt = (wsheet.Cells[i, 6].Value ?? "").ToString().Trim();
                        string khoa = (wsheet.Cells[i, 7].Value ?? "").ToString().Trim();
                        string ttRaw = (wsheet.Cells[i, 8].Value ?? "").ToString().Trim();

                        int tt = ParseTrangThaiToBit(ttRaw);

                        ThemmoiGiangVien(ma, ten, hv, hh, email, dt, khoa, tt);
                        i++;
                    } while (true);

                    Marshal.ReleaseComObject(wsheet);
                }

                MessageBox.Show("Nhập Excel thành công!");
                LoadGiangVien();
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

        private int ParseTrangThaiToBit(string ttRaw)
        {
            if (string.IsNullOrWhiteSpace(ttRaw)) return 1;

            string s = ttRaw.Trim().ToLower();

            // chấp nhận: 0/1, true/false, hoạt động/khóa
            if (s == "0" || s == "false" || s.Contains("khóa") || s.Contains("khoa"))
                return 0;

            return 1;
        }

        private void ThemmoiGiangVien(string ma, string ten, string hv, string hh, string email, string dt, string khoa, int tt)
        {
            if (ma == "" || ten == "" || khoa == "") return;

            using (SqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();

                string check = "SELECT COUNT(*) FROM GiangVien WHERE ma_gv = @ma";
                using (SqlCommand cmdCheck = new SqlCommand(check, conn))
                {
                    cmdCheck.Parameters.AddWithValue("@ma", ma);
                    int kq = (int)cmdCheck.ExecuteScalar();

                    if (kq == 0)
                    {
                        string sql = @"
                            INSERT INTO GiangVien(ma_gv, ten_gv, hoc_vi, hoc_ham, email, dien_thoai, ma_khoa, trang_thai)
                            VALUES(@ma, @ten, @hv, @hh, @email, @dt, @khoa, @tt)
                        ";

                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@ma", ma);
                            cmd.Parameters.AddWithValue("@ten", ten);
                            cmd.Parameters.AddWithValue("@hv", hv);

                            cmd.Parameters.AddWithValue("@hh", (object)hh ?? DBNull.Value);
                            if (hh == "") cmd.Parameters["@hh"].Value = DBNull.Value;

                            cmd.Parameters.AddWithValue("@email", email);
                            cmd.Parameters.AddWithValue("@dt", dt);
                            cmd.Parameters.AddWithValue("@khoa", khoa);
                            cmd.Parameters.AddWithValue("@tt", tt);

                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
        }
    }
}
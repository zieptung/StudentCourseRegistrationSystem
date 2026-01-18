using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ex_cel = Microsoft.Office.Interop.Excel;

namespace StudentCourseRegistrationSystem
{
    public partial class FormQLLHP : Form
    {
        public FormQLLHP()
        {
            InitializeComponent();
        }
        string maLHP_DangChon = "";
        private void FormQLLHP_Load(object sender, EventArgs e)
        {
            LoadCboMaMon();
            LoadCboHocKy();
            LoadCboGiangVien();
            LoadLopHocPhan();
        }
        private void LoadLopHocPhan()
        {
            string sql = $@"SELECT 
            lhp.ma_lhp,
            lhp.ma_mon,
            lhp.ma_mon + N' - ' + mh.ten_mon AS ma_mon_hienthi,
            lhp.ma_hoc_ky,
            lhp.giang_vien,
            gv.ma_gv + N' - ' + gv.ten_gv AS giang_vien_hienthi,
            lhp.so_luong_toi_da,
            lhp.thu,
            lhp.ca_hoc,
            lhp.phong_hoc,
            lhp.trang_thai
            FROM LopHocPhan lhp
            JOIN MonHoc mh ON lhp.ma_mon = mh.ma_mon
            JOIN GiangVien gv ON lhp.giang_vien = gv.ma_gv";
            dgvLopHocPhan.AutoGenerateColumns = false;
            dgvLopHocPhan.DataSource = CrudLib.GetDataTable(sql);
        }
        private void LoadCboMaMon()
        {
            string sql = @"
        SELECT 
            ma_mon,
            ma_mon + N' - ' + ten_mon AS ten_mon_hienthi
        FROM MonHoc";

            DataTable dt = CrudLib.GetDataTable(sql);

            cboMaMon.DataSource = dt;
            cboMaMon.DisplayMember = "ten_mon_hienthi";
            cboMaMon.ValueMember = "ma_mon";
            cboMaMon.SelectedIndex = -1; // không chọn sẵn
        }
        private void LoadCboHocKy()
        {
            string sql = "SELECT ma_hoc_ky FROM HocKy";
            DataTable dt = CrudLib.GetDataTable(sql);

            cboHocKy.DataSource = dt;
            cboHocKy.DisplayMember = "ma_hoc_ky";
            cboHocKy.ValueMember = "ma_hoc_ky";
            cboHocKy.SelectedIndex = -1;
        }
        private void LoadCboGiangVien()
        {
            string sql = @"
        SELECT 
            ma_gv,
            ma_gv + N' - ' + ten_gv AS ten_gv_hienthi
        FROM GiangVien";

            DataTable dt = CrudLib.GetDataTable(sql);

            cboGiangVien.DataSource = dt;
            cboGiangVien.DisplayMember = "ten_gv_hienthi";
            cboGiangVien.ValueMember = "ma_gv";
            cboGiangVien.SelectedIndex = -1;
        }

        private void ClearForm()
        {
            txtMaLHP.Clear();
            txtSoLuong.Clear();
            txtPhongHoc.Clear();

            cboMaMon.SelectedIndex = -1;
            cboHocKy.SelectedIndex = -1;
            cboGiangVien.SelectedIndex = -1;
            cboThu.SelectedIndex = -1;
            cboCaHoc.SelectedIndex = -1;
            cboTrangThai.SelectedIndex = -1;
            txtMaLHP.Enabled = true;
        }
        private void dgvLopHocPhan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvLopHocPhan.Rows[e.RowIndex];

            txtMaLHP.Text = row.Cells["ma_lhp"].Value?.ToString();
            txtSoLuong.Text = row.Cells["so_luong_toi_da"].Value?.ToString();
            txtPhongHoc.Text = row.Cells["phong_hoc"].Value?.ToString();

            cboMaMon.SelectedValue = row.Cells["ma_mon"].Value?.ToString().Trim();
            cboHocKy.SelectedValue = row.Cells["ma_hoc_ky"].Value?.ToString();
            cboGiangVien.SelectedValue = row.Cells["giang_vien"].Value?.ToString();

            cboThu.Text = row.Cells["thu"].Value?.ToString();
            cboCaHoc.Text = row.Cells["ca_hoc"].Value?.ToString();
            cboTrangThai.Text = row.Cells["trang_thai"].Value?.ToString();
            txtMaLHP.Enabled = false;

            if (e.RowIndex < 0) return;
            maLHP_DangChon = dgvLopHocPhan.Rows[e.RowIndex]
                                .Cells["ma_lhp"].Value.ToString();

        }
        private bool CheckTrungMaLHP(string maLHP)
        {
            string sql = $@"
        SELECT COUNT(*) 
        FROM LopHocPhan 
        WHERE ma_lhp = N'{maLHP}'";

            int count = Convert.ToInt32(CrudLib.GetValue(sql));
            return count > 0;
        }

        private bool CheckTrungCaThuPhong(
        string thu,
        string caHoc,
        string phongHoc,
        string hocKy,
        string maLHP = null)
        {
            string sql = $@"
            SELECT COUNT(*)
            FROM LopHocPhan
            WHERE thu = N'{thu}'
            AND ca_hoc = N'{caHoc}'
            AND phong_hoc = N'{phongHoc}'
            AND ma_hoc_ky = N'{hocKy}'";

            if (!string.IsNullOrEmpty(maLHP))
            {
                sql += $" AND ma_lhp <> N'{maLHP}'";
            }

            int count = Convert.ToInt32(CrudLib.GetValue(sql));

            return count > 0;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaLHP.Text))
            {
                MessageBox.Show("Vui lòng nhập mã lớp học phần");
                return;
            }

            if (cboMaMon.SelectedValue == null ||
                cboHocKy.SelectedValue == null ||
                cboGiangVien.SelectedValue == null ||
                cboThu.SelectedIndex == -1 ||
                cboCaHoc.SelectedIndex == -1 ||
                cboTrangThai.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                return;
            }
            if (CheckTrungMaLHP(txtMaLHP.Text.Trim()))
            {
                MessageBox.Show("Mã lớp học phần đã tồn tại!");
                return;
            }
            if (!int.TryParse(txtSoLuong.Text, out int soLuong))
            {
                MessageBox.Show("Số lượng tối đa phải là số");
                return;
            }
            bool trung = CheckTrungCaThuPhong(
                cboThu.Text,
                cboCaHoc.Text,
                txtPhongHoc.Text,
                cboHocKy.SelectedValue.ToString()
            );

            if (trung)
            {
                MessageBox.Show(
                    "Phòng học đã có lớp khác vào cùng ca và thứ!",
                    "Trùng lịch",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            string sqlCheck = $"SELECT COUNT(*) FROM LopHocPhan WHERE ma_lhp = N'{txtMaLHP.Text.Trim()}'";
            if (Convert.ToInt32(CrudLib.GetValue(sqlCheck)) > 0)
            {
                MessageBox.Show("Mã lớp học phần đã tồn tại!");
                return;
            }

            string maMon = cboMaMon.SelectedValue.ToString().Trim();
            string hocKy = cboHocKy.SelectedValue.ToString().Trim();
            string maGV = cboGiangVien.SelectedValue.ToString().Trim();

            string sqlInsert = $@"
        INSERT INTO LopHocPhan
        (ma_lhp, ma_mon, ma_hoc_ky, giang_vien,
         so_luong_toi_da, thu, ca_hoc, phong_hoc, trang_thai)
        VALUES
        (N'{txtMaLHP.Text.Trim()}',
         N'{maMon}',
         N'{hocKy}',
         N'{maGV}',
         {soLuong},
         N'{cboThu.Text}',
         N'{cboCaHoc.Text}',
         N'{txtPhongHoc.Text}',
         N'{cboTrangThai.Text}')";

            int result = CrudLib.IUDQuery(sqlInsert);

            if (result > 0)
            {
                MessageBox.Show("Thêm lớp học phần thành công!");
                LoadLopHocPhan();
                ClearForm();
            }
            else
            {
                MessageBox.Show("Thêm thất bại!");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaLHP.Text))
            {
                MessageBox.Show("Vui lòng chọn lớp học phần cần sửa");
                return;
            }

            if (cboMaMon.SelectedValue == null ||
                cboHocKy.SelectedValue == null ||
                cboGiangVien.SelectedValue == null ||
                cboThu.SelectedIndex == -1 ||
                cboCaHoc.SelectedIndex == -1 ||
                cboTrangThai.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                return;
            }

            if (!int.TryParse(txtSoLuong.Text, out int soLuong))
            {
                MessageBox.Show("Số lượng tối đa phải là số");
                return;
            }
            bool trung = CheckTrungCaThuPhong(
            cboThu.Text,
            cboCaHoc.Text,
            txtPhongHoc.Text,
            cboHocKy.SelectedValue.ToString(),
            txtMaLHP.Text);

            if (trung)
            {
                MessageBox.Show(
                    "Phòng học đã có lớp khác vào cùng ca và thứ!",
                    "Trùng lịch",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }
            string maLHP = txtMaLHP.Text.Trim();
            string maMon = cboMaMon.SelectedValue.ToString().Trim();
            string hocKy = cboHocKy.SelectedValue.ToString().Trim();
            string maGV = cboGiangVien.SelectedValue.ToString().Trim();

            string sqlUpdate = $@"
        UPDATE LopHocPhan
        SET
            ma_mon = N'{maMon}',
            ma_hoc_ky = N'{hocKy}',
            giang_vien = N'{maGV}',
            so_luong_toi_da = {soLuong},
            thu = N'{cboThu.Text}',
            ca_hoc = N'{cboCaHoc.Text}',
            phong_hoc = N'{txtPhongHoc.Text}',
            trang_thai = N'{cboTrangThai.Text}'
        WHERE ma_lhp = N'{maLHP}' AND ma_mon = N'{maMon}'";

            int result = CrudLib.IUDQuery(sqlUpdate);

            if (result > 0)
            {
                MessageBox.Show("Cập nhật lớp học phần thành công!");
                LoadLopHocPhan();
                ClearForm();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại!");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaLHP.Text))
            {
                MessageBox.Show("Vui lòng chọn lớp học phần cần xóa");
                return;
            }

            string maLHP = txtMaLHP.Text.Trim();

            string sqlCheck = $@"
        SELECT COUNT(*) 
        FROM DangKyLopHocPhan
        WHERE ma_lhp = N'{maLHP}'";

            int soLuongDangKy = Convert.ToInt32(CrudLib.GetValue(sqlCheck));

            if (soLuongDangKy > 0)
            {
                MessageBox.Show(
                    "Không thể xóa lớp học phần này vì đã có sinh viên đăng ký.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            DialogResult dr = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa lớp học phần này không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (dr != DialogResult.Yes)
                return;

            string sqlDelete = $@"
            DELETE FROM LopHocPhan
            WHERE ma_lhp = N'{maLHP}'";

            int result = CrudLib.IUDQuery(sqlDelete);

            if (result > 0)
            {
                MessageBox.Show("Xóa lớp học phần thành công!");
                LoadLopHocPhan();
                ClearForm();
            }
            else
            {
                MessageBox.Show("Xóa thất bại!");
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTuKhoa.Text.Trim();

            if (string.IsNullOrWhiteSpace(keyword))
            {
                LoadLopHocPhan();
                return;
            }

            string sql = $@"
            SELECT 
            lhp.ma_lhp,
            lhp.ma_mon,
            mh.ma_mon + N' - ' + mh.ten_mon AS ma_mon_hienthi,
            lhp.ma_hoc_ky,
            lhp.giang_vien AS ma_gv,
            gv.ma_gv + N' - ' + gv.ten_gv AS giang_vien_hienthi,
            lhp.so_luong_toi_da,
            lhp.thu,
            lhp.ca_hoc,
            lhp.phong_hoc,
            lhp.trang_thai
            FROM LopHocPhan lhp
            JOIN MonHoc mh ON lhp.ma_mon = mh.ma_mon
            JOIN GiangVien gv ON lhp.giang_vien = gv.ma_gv
            WHERE
            lhp.ma_lhp LIKE N'%{keyword}%'
            OR lhp.ma_mon LIKE N'%{keyword}%'
            OR mh.ten_mon LIKE N'%{keyword}%'
            OR gv.ma_gv LIKE N'%{keyword}%'
            OR gv.ten_gv LIKE N'%{keyword}%'
    ";

            dgvLopHocPhan.DataSource = CrudLib.GetDataTable(sql);
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            DataTable tb = dgvLopHocPhan.DataSource as DataTable;
            if (tb == null || tb.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất Excel");
                return;
            }
            ex_cel.Application oExcel = new ex_cel.Application();
            ex_cel.Workbooks oBooks;
            ex_cel.Sheets oSheets;
            ex_cel.Workbook oBook;
            ex_cel.Worksheet oSheet;

            oExcel.Visible = true;
            oExcel.DisplayAlerts = false;
            oExcel.Application.SheetsInNewWorkbook = 1;

            oBooks = oExcel.Workbooks;
            oBook = (ex_cel.Workbook)(oBooks.Add(Type.Missing));
            oSheets = oBook.Worksheets;
            oSheet = (ex_cel.Worksheet)oSheets.get_Item(1);
            oSheet.Name = "LopHocPhan";

            ex_cel.Range head = oSheet.get_Range("A1", "J1");
            head.MergeCells = true;
            head.Value2 = "DANH SÁCH LỚP HỌC PHẦN";
            head.Font.Bold = true;
            head.Font.Name = "Tahoma";
            head.Font.Size = 16;
            head.HorizontalAlignment = ex_cel.XlHAlign.xlHAlignCenter;

            string[] headers =
            {
        "STT",
        "Mã LHP",
        "Môn học",
        "Học kỳ",
        "Giảng viên",
        "Số lượng tối đa",
        "Thứ",
        "Ca học",
        "Phòng học",
        "Trạng thái"
    };

            for (int i = 0; i < headers.Length; i++)
            {
                ex_cel.Range cl = (ex_cel.Range)oSheet.Cells[3, i + 1];
                cl.Value2 = headers[i];
                cl.ColumnWidth = 20;
            }

            ex_cel.Range rowHead = oSheet.get_Range("A3", "J3");
            rowHead.Font.Bold = true;
            rowHead.Borders.LineStyle = ex_cel.Constants.xlSolid;
            rowHead.Interior.ColorIndex = 15;
            rowHead.HorizontalAlignment = ex_cel.XlHAlign.xlHAlignCenter;

            object[,] arr = new object[tb.Rows.Count, 10];

            for (int r = 0; r < tb.Rows.Count; r++)
            {
                DataRow dr = tb.Rows[r];
                arr[r, 0] = r + 1;
                arr[r, 1] = dr["ma_lhp"];
                arr[r, 2] = dr["ma_mon_hienthi"];
                arr[r, 3] = dr["ma_hoc_ky"];
                arr[r, 4] = dr["giang_vien_hienthi"];
                arr[r, 5] = dr["so_luong_toi_da"];
                arr[r, 6] = dr["thu"];
                arr[r, 7] = dr["ca_hoc"];
                arr[r, 8] = dr["phong_hoc"];
                arr[r, 9] = dr["trang_thai"];
            }

            int rowStart = 4;
            int columnStart = 1;
            int rowEnd = rowStart + tb.Rows.Count - 1;
            int columnEnd = 10;

            ex_cel.Range c1 = (ex_cel.Range)oSheet.Cells[rowStart, columnStart];
            ex_cel.Range c2 = (ex_cel.Range)oSheet.Cells[rowEnd, columnEnd];
            ex_cel.Range range = oSheet.get_Range(c1, c2);

            range.Value2 = arr;
            range.Borders.LineStyle = ex_cel.Constants.xlSolid;
        }

        private void btnNhap_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel Files|*.xlsx;*.xls";

            if (ofd.ShowDialog() != DialogResult.OK)
                return;

            ex_cel.Application oExcel = new ex_cel.Application();
            ex_cel.Workbook oBook = null;
            ex_cel.Worksheet oSheet = null;

            try
            {
                oExcel.Visible = false;
                oExcel.DisplayAlerts = false;

                oBook = oExcel.Workbooks.Open(ofd.FileName);
                oSheet = (ex_cel.Worksheet)oBook.Sheets[1];

                ex_cel.Range usedRange = oSheet.UsedRange;
                int rowCount = usedRange.Rows.Count;

                for (int i = 4; i <= rowCount; i++)
                {
                    string maLHP = (oSheet.Cells[i, 2] as ex_cel.Range)?.Value2?.ToString();
                    if (string.IsNullOrWhiteSpace(maLHP))
                        continue;

                    string sqlCheck = $"SELECT COUNT(*) FROM LopHocPhan WHERE ma_lhp = N'{maLHP}'";
                    int count = Convert.ToInt32(CrudLib.GetValue(sqlCheck));
                    if (count > 0)
                        continue;

                    string maMon = (oSheet.Cells[i, 3] as ex_cel.Range)?.Value2?.ToString();
                    string hocKy = (oSheet.Cells[i, 4] as ex_cel.Range)?.Value2?.ToString();
                    string giangVien = (oSheet.Cells[i, 5] as ex_cel.Range)?.Value2?.ToString();
                    string soLuong = (oSheet.Cells[i, 6] as ex_cel.Range)?.Value2?.ToString();
                    string thu = (oSheet.Cells[i, 7] as ex_cel.Range)?.Value2?.ToString();
                    string caHoc = (oSheet.Cells[i, 8] as ex_cel.Range)?.Value2?.ToString();
                    string phongHoc = (oSheet.Cells[i, 9] as ex_cel.Range)?.Value2?.ToString();
                    string trangThai = (oSheet.Cells[i, 10] as ex_cel.Range)?.Value2?.ToString();

                    if (maMon != null && maMon.Contains("-"))
                        maMon = maMon.Split('-')[0].Trim();

                    if (giangVien != null && giangVien.Contains("-"))
                        giangVien = giangVien.Split('-')[0].Trim();

                    string sqlInsert = $@"
                INSERT INTO LopHocPhan
                (ma_lhp, ma_mon, ma_hoc_ky, giang_vien,
                 so_luong_toi_da, thu, ca_hoc, phong_hoc, trang_thai)
                VALUES
                (N'{maLHP}',
                 N'{maMon}',
                 N'{hocKy}',
                 N'{giangVien}',
                 {soLuong},
                 N'{thu}',
                 N'{caHoc}',
                 N'{phongHoc}',
                 N'{trangThai}')";

                    CrudLib.IUDQuery(sqlInsert);
                }

                MessageBox.Show("Nhập dữ liệu từ Excel thành công!");
                LoadLopHocPhan();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi nhập Excel: " + ex.Message);
            }
            finally
            {
                oBook?.Close(false);
                oExcel.Quit();

                System.Runtime.InteropServices.Marshal.ReleaseComObject(oSheet);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(oBook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(oExcel);
            }
        }

        private void btnXemChiTiet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(maLHP_DangChon))
            {
                MessageBox.Show("Vui lòng chọn lớp học phần");
                return;
            }

            FormCTLHP frm = new FormCTLHP(maLHP_DangChon);
            frm.ShowDialog();
        }
    }
}
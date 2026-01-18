using ClosedXML.Excel;
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
    public partial class FormHP : Form
    {
        public FormHP()
        {
            InitializeComponent();
        }

        private void FormHP_Load(object sender, EventArgs e)
        {
            txtTongTC.ReadOnly = true;
            txtTongtien.ReadOnly = true;
            txtTrangthai.ReadOnly = true;

            txtTrangthai.Text = "Chưa đóng";

            LoadHocKy();
            LoadHocPhi();
        }

        void LoadHocKy()
        {
            string sql = "SELECT ma_hoc_ky FROM HocKy";
            cbHocky.DataSource = CrudLib.GetDataTable(sql);
            cbHocky.DisplayMember = "ma_hoc_ky";
            cbHocky.ValueMember = "ma_hoc_ky";
            cbHocky.SelectedIndex = -1;
        }
        void LoadHocPhi()
        {
            string sql = "SELECT * FROM HocPhi";
            dataGridView1.DataSource = CrudLib.GetDataTable(sql);
        }

        private void cbHocky_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnTinh_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaSV.Text))
            {
                MessageBox.Show("Vui lòng nhập mã sinh viên!");
                return;
            }

            if (cbHocky.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn học kỳ!");
                return;
            }

            string maHocKy = cbHocky.SelectedValue.ToString();

            string sql = $@"
            SELECT ISNULL(SUM(mh.so_tin_chi), 0)
            FROM DangKyLopHocPhan dk
            JOIN LopHocPhan lhp ON dk.ma_lhp = lhp.ma_lhp
            JOIN MonHoc mh ON lhp.ma_mon = mh.ma_mon
            WHERE dk.ma_sv = '{txtMaSV.Text}'
              AND lhp.ma_hoc_ky = '{maHocKy}'";

            int tongTinChi = Convert.ToInt32(CrudLib.GetValue(sql));
            long tongTien = tongTinChi * 520000;

            txtTongTC.Text = tongTinChi.ToString();
            txtTongtien.Text = tongTien.ToString("N0");
            txtTrangthai.Text = "Chưa đóng";

            if (tongTinChi == 0)
            {
                MessageBox.Show(
                    "Sinh viên chưa đăng ký lớp học phần nào trong học kỳ này!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }

        private void btnCapnhap_Click(object sender, EventArgs e)
        {
            if (txtTongTC.Text == "")
            {
                MessageBox.Show("Vui lòng tính học phí trước!");
                return;
            }

            string checkSql = $@"
            SELECT COUNT(*) FROM HocPhi
            WHERE ma_sv = '{txtMaSV.Text}'
              AND ma_hoc_ky = '{cbHocky.SelectedValue}'";

            int count = Convert.ToInt32(CrudLib.GetValue(checkSql));
            string sql;

            if (count == 0)
            {
                sql = $@"
                INSERT INTO HocPhi
                VALUES (
                    '{txtMaSV.Text}',
                    '{cbHocky.SelectedValue}',
                    {txtTongTC.Text},
                    {txtTongtien.Text.Replace(",", "")},
                    N'{txtTrangthai.Text}'
                )";
            }
            else
            {
                sql = $@"
                UPDATE HocPhi SET
                    tong_tin_chi = {txtTongTC.Text},
                    tong_tien = {txtTongtien.Text.Replace(",", "")},
                    trang_thai = N'{txtTrangthai.Text}'
                WHERE ma_sv = '{txtMaSV.Text}'
                  AND ma_hoc_ky = '{cbHocky.SelectedValue}'";
            }

            CrudLib.IUDQuery(sql);
            LoadHocPhi();
            MessageBox.Show("Cập nhật học phí thành công!");
        }

        private void btnDanhdau_Click(object sender, EventArgs e)
        {
            if (txtMaSV.Text == "" || cbHocky.SelectedIndex == -1)
            {
                MessageBox.Show("Chọn sinh viên và học kỳ!");
                return;
            }

            string sql = $@"
            UPDATE HocPhi
            SET trang_thai = N'Đã đóng'
            WHERE ma_sv = '{txtMaSV.Text}'
              AND ma_hoc_ky = '{cbHocky.SelectedValue}'";

            CrudLib.IUDQuery(sql);

            txtTrangthai.Text = "Đã đóng";
            LoadHocPhi();

            MessageBox.Show("Đã đánh dấu học phí là ĐÃ ĐÓNG!");
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
            sfd.FileName = "DanhSachHocPhi.xlsx";

            if (sfd.ShowDialog() != DialogResult.OK) return;
            try
            {
                using (XLWorkbook wb = new XLWorkbook())
                {
                    var ws = wb.Worksheets.Add("HocPhi");

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

                            if (value == null)
                            {
                                ws.Cell(rowExcel, col + 1).Value = "";
                            }
                            else if (value is DateTime)
                            {
                                ws.Cell(rowExcel, col + 1).Value = (DateTime)value;
                                ws.Cell(rowExcel, col + 1)
                                  .Style.DateFormat.Format = "dd/MM/yyyy";
                            }
                            else
                            {
                                ws.Cell(rowExcel, col + 1).Value = value.ToString();
                            }
                        }
                        rowExcel++;
                    }

                    ws.Columns().AdjustToContents();
                    wb.SaveAs(sfd.FileName);
                }
                MessageBox.Show("Xuất Excel học phí thành công!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xuất Excel: " + ex.Message);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow r = dataGridView1.Rows[e.RowIndex];

            txtMaSV.Text = r.Cells["ma_sv"].Value.ToString();
            cbHocky.SelectedValue = r.Cells["ma_hoc_ky"].Value.ToString();

            txtTongTC.Text = r.Cells["tong_tin_chi"].Value.ToString();
            txtTongtien.Text = Convert.ToDecimal(r.Cells["tong_tien"].Value).ToString("N0");
            txtTrangthai.Text = r.Cells["trang_thai"].Value.ToString();

        }
    }
}
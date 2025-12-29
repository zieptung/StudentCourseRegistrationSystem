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
using static System.Net.Mime.MediaTypeNames;

namespace StudentCourseRegistrationSystem
{
    public partial class FormXemtkbGV : Form
    {
        private readonly string connectionString =
            @"Data Source=LAPTOP-9G6IUBF5;Initial Catalog=QLTC;Integrated Security=True;TrustServerCertificate=True";
        public FormXemtkbGV()
        {
            InitializeComponent();
            Load += FormXemtkbGV_Load;
            btnXem.Click += btnXem_Click;
        }
        private SqlConnection GetConn() => new SqlConnection(connectionString);
        string maGV = "GV001";
        private void FormXemtkbGV_Load(object sender, EventArgs e)
        {
            LoadHocKy();
        }
        private void LoadHocKy()
        {
            string sql = @"
SELECT ma_hoc_ky, (ten_hoc_ky + ' - ' + nam_hoc) AS ten
FROM HocKy
ORDER BY nam_hoc DESC, ngay_bat_dau DESC;";

            var da = new SqlDataAdapter(sql, GetConn());
            var dt = new DataTable();
            da.Fill(dt);

            cboHocKy.DataSource = dt;
            cboHocKy.DisplayMember = "ten";
            cboHocKy.ValueMember = "ma_hoc_ky";
            cboHocKy.SelectedIndex = dt.Rows.Count > 0 ? 0 : -1;
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (cboHocKy.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn học kỳ!");
                return;
            }
            LoadTKB();
        }
        private void LoadTKB()
        {
            string sql = @"
SELECT
    tkb.thu AS [Thứ],
    tkb.tiet_bat_dau AS [Tiết bắt đầu],
    tkb.so_tiet AS [Số tiết],
    (tkb.tiet_bat_dau + tkb.so_tiet - 1) AS [Tiết kết thúc],
    tkb.phong_hoc AS [Phòng],
    lhp.ma_lhp AS [Mã LHP],
    mh.ma_mon AS [Mã môn],
    mh.ten_mon AS [Tên môn]
FROM LopHocPhan lhp
JOIN ThoiKhoaBieu tkb ON tkb.ma_lhp = lhp.ma_lhp
JOIN MonHoc mh ON lhp.ma_mon = mh.ma_mon
WHERE lhp.ma_gv = @ma_gv
  AND lhp.ma_hoc_ky = @ma_hoc_ky
ORDER BY tkb.thu, tkb.tiet_bat_dau, mh.ten_mon;";

            var conn = GetConn();
            var da = new SqlDataAdapter(sql, conn);
            da.SelectCommand.Parameters.AddWithValue("@ma_gv", maGV);
            da.SelectCommand.Parameters.AddWithValue("@ma_hoc_ky", cboHocKy.SelectedValue.ToString());

            var dt = new DataTable();
            da.Fill(dt);

            // đổi thứ 2..8 -> "Thứ 2..CN" (để hiển thị đẹp)
            if (dt.Columns.Contains("Thứ"))
            {
                foreach (DataRow r in dt.Rows)
                {
                    if (int.TryParse(r["Thứ"].ToString(), out int thu))
                        r["Thứ"] = ThuToText(thu);
                }
            }

            dgvTKB.DataSource = dt;

            if (dt.Rows.Count == 0)
                MessageBox.Show("Học kỳ này chưa có thời khóa biểu cho giảng viên!");
        }
        private string ThuToText(int thu)
        {
            return thu == 8 ? "CN" : $"Thứ {thu}";
        }
    }
}

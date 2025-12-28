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

namespace StudentCourseRegistrationSystem
{
    public partial class FormDSmondangky : Form
    {
        public string MaSV = "SV001";
        public FormDSmondangky()
        {
            InitializeComponent();
        }

        public void load_Formdangky()
        {
            String sql = "SELECT lhp.ma_lhp,mh.ten_mon,mh.so_tin_chi,lhp.so_luong_toi_da,lhp.so_luong_da_dang_ky FROM LopHocPhan lhp JOIN MonHoc mh ON lhp.ma_mon=mh.ma_mon WHERE lhp.trang_thai = N'mở'AND lhp.so_luong_da_dang_ky < lhp.so_luong_toi_da;";
            DbConnection.ketnoi_dulieu(DRVdsdangky, sql);
        }
        private void FormDSmondangky_Load(object sender, EventArgs e)
        {
            LoadMonDaDangKy();
        }
        private void LoadMonDaDangKy()
        {
            string sql = @"SELECT dk.ma_dk,mh.ma_mon,mh.ten_mon,mh.so_tin_chi,dk.ma_lhp,dk.ma_hoc_ky,hk.ten_hoc_ky,hk.nam_hoc,CONCAT(RTRIM(hk.ten_hoc_ky),N' (',RTRIM(hk.nam_hoc),N')') AS hoc_ky,CONCAT(N'Thứ ', tkb.thu,N' | Tiết ',tkb.tiet_bat_dau, '-', (tkb.tiet_bat_dau + tkb.so_tiet - 1)) AS lich_hoc FROM DangKyHocPhan dk JOIN LopHocPhan lhp ON dk.ma_lhp = lhp.ma_lhp JOIN MonHoc mh ON lhp.ma_mon = mh.ma_mon JOIN ThoiKhoaBieu tkb ON dk.ma_tkb = tkb.ma_tkb JOIN HocKy hk ON dk.ma_hoc_ky = hk.ma_hoc_ky WHERE dk.ma_sv = @sv ORDER BY hk.ngay_bat_dau DESC, mh.ma_mon";

            SqlCommand cmd = new SqlCommand(sql, DbConnection.conn);
            cmd.Parameters.AddWithValue("@sv", MaSV);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            DRVdsdangky.AutoGenerateColumns = false;
            DRVdsdangky.DataSource = dt;
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            string key = txtmamon.Text.Trim();

            if (string.IsNullOrEmpty(key))
                key = txttenmon.Text.Trim();

            if (string.IsNullOrEmpty(key))
            {
                MessageBox.Show("Vui lòng nhập mã môn hoặc tên môn để tìm kiếm!");
                return;
            }

            string sql = @" SELECT dk.ma_dk,mh.ma_mon,mh.ten_mon,mh.so_tin_chi,dk.ma_lhp,dk.ma_hoc_ky,hk.ten_hoc_ky,hk.nam_hoc,CONCAT(N'Thứ ', tkb.thu, N' | Tiết ',tkb.tiet_bat_dau, '-', (tkb.tiet_bat_dau + tkb.so_tiet - 1)) AS lich_hoc FROM DangKyHocPhan dk JOIN LopHocPhan lhp ON dk.ma_lhp = lhp.ma_lhp JOIN MonHoc mh ON lhp.ma_mon = mh.ma_mon JOIN ThoiKhoaBieu tkb ON dk.ma_tkb = tkb.ma_tkb JOIN HocKy hk ON dk.ma_hoc_ky = hk.ma_hoc_ky WHERE dk.ma_sv = @sv AND (mh.ma_mon LIKE @key OR mh.ten_mon LIKE @key) ORDER BY hk.ngay_bat_dau DESC, mh.ma_mon";

            SqlCommand cmd = new SqlCommand(sql, DbConnection.conn);
            cmd.Parameters.AddWithValue("@sv", MaSV);
            cmd.Parameters.AddWithValue("@key", "%" + key + "%");

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            DRVdsdangky.AutoGenerateColumns = false;
            DRVdsdangky.DataSource = dt;

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtmamon_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txttenmon_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

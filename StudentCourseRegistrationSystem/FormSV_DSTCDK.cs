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
    public partial class FormSV_DSTCDK : Form
    {
        private string maSv;
        public FormSV_DSTCDK(String maSv)
        {
            InitializeComponent();
            this.maSv = maSv;
        }

        private void FormSV_DSTCDK_Load(object sender, EventArgs e)
        {
            LoadHocKy();
            LoadDanhSachDaDangKy();
        }

        private void LoadDanhSachDaDangKy()
        {
            string sql = @"
                SELECT 
                    mh.ma_mon,
                    mh.ten_mon,
                    mh.so_tin_chi,
                    hk.ten_hoc_ky + N' - ' + hk.nam_hoc AS hoc_ky,
                    lhp.ma_lhp,
                    lhp.phong_hoc,
                    N'Thứ ' + CAST(lhp.thu AS NVARCHAR) + N' - Ca ' + lhp.ca_hoc AS lich_hoc
                FROM DangKyLopHocPhan dk
                JOIN LopHocPhan lhp ON dk.ma_lhp = lhp.ma_lhp
                JOIN MonHoc mh ON lhp.ma_mon = mh.ma_mon
                JOIN HocKy hk ON lhp.ma_hoc_ky = hk.ma_hoc_ky
                WHERE dk.ma_sv = @sv
                  AND dk.trang_thai = N'Đã đăng ký'
            ";

            SqlCommand cmd = new SqlCommand(sql, DbConnection.conn);
            cmd.Parameters.AddWithValue("@sv", maSv);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dgvdanhsach.DataSource = dt;
        }

        private void LoadLopHocPhanDangMo(string maMon, string maHocKy)
        {
            string sql = @"
                SELECT ma_lhp, phong_hoc, thu, ca_hoc, so_luong_toi_da
                FROM LopHocPhan
                WHERE ma_mon = @maMon
                  AND ma_hoc_ky = @hk
                  AND trang_thai = N'Đang mở'
            ";

            SqlCommand cmd = new SqlCommand(sql, DbConnection.conn);
            cmd.Parameters.AddWithValue("@maMon", maMon);
            cmd.Parameters.AddWithValue("@hk", maHocKy);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            cbolop.DataSource = dt;
            cbolop.DisplayMember = "ma_lhp";
            cbolop.ValueMember = "ma_lhp";
        }

        private void LoadSiSo(string maLHP)
        {
            string sql = @"
                SELECT COUNT(dk.id_dang_ky) AS da_dang_ky, lhp.so_luong_toi_da
                FROM LopHocPhan lhp
                LEFT JOIN DangKyLopHocPhan dk 
                    ON lhp.ma_lhp = dk.ma_lhp AND dk.trang_thai = N'Đã đăng ký'
                WHERE lhp.ma_lhp = @lhp
                GROUP BY lhp.so_luong_toi_da
            ";

            SqlCommand cmd = new SqlCommand(sql, DbConnection.conn);
            cmd.Parameters.AddWithValue("@lhp", maLHP);

            if (DbConnection.conn.State == ConnectionState.Closed)
                DbConnection.conn.Open();

            SqlDataReader rd = cmd.ExecuteReader();

            if (rd.Read())
            {
                int da = Convert.ToInt32(rd["da_dang_ky"]);
                int td = Convert.ToInt32(rd["so_luong_toi_da"]);
                txtsiso.Text = da + " / " + td;
            }

            rd.Close();
            DbConnection.conn.Close();
        }

        private void LoadHocKy()
        {
            string sql = @"
                SELECT ma_hoc_ky, ten_hoc_ky + N' - ' + nam_hoc AS hien_thi
                FROM HocKy
                WHERE trang_thai = 1
            ";

            SqlDataAdapter da = new SqlDataAdapter(sql, DbConnection.conn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            cbohocky.DataSource = dt;
            cbohocky.DisplayMember = "hien_thi";
            cbohocky.ValueMember = "ma_hoc_ky";
        }

        private bool CheckTrungLichKhiSua(string thu, string caHoc, string maLHPcu)
        {
            string sql = @"
                SELECT COUNT(*)
                FROM DangKyLopHocPhan dk
                JOIN LopHocPhan lhp ON dk.ma_lhp = lhp.ma_lhp
                WHERE dk.ma_sv = @sv
                AND dk.trang_thai = N'Đã đăng ký'
                AND lhp.thu = @thu
                AND lhp.ca_hoc = @ca
                AND dk.ma_lhp <> @lhpCu
            ";

            SqlCommand cmd = new SqlCommand(sql, DbConnection.conn);
            cmd.Parameters.AddWithValue("@sv", maSv);
            cmd.Parameters.AddWithValue("@thu", thu);
            cmd.Parameters.AddWithValue("@ca", caHoc);
            cmd.Parameters.AddWithValue("@lhpCu", maLHPcu);

            if (DbConnection.conn.State == ConnectionState.Closed)
                DbConnection.conn.Open();

            int count = (int)cmd.ExecuteScalar();
            DbConnection.conn.Close();

            return count > 0;
        }
        private bool KiemTrasiso(string maLHP)
        {
            string sql = @"
                SELECT COUNT(dk.id_dang_ky) AS da_dang_ky, lhp.so_luong_toi_da
                FROM LopHocPhan lhp
                LEFT JOIN DangKyLopHocPhan dk 
                    ON lhp.ma_lhp = dk.ma_lhp AND dk.trang_thai = N'Đã đăng ký'
                WHERE lhp.ma_lhp = @lhp
                GROUP BY lhp.so_luong_toi_da
            ";

            SqlCommand cmd = new SqlCommand(sql, DbConnection.conn);
            cmd.Parameters.AddWithValue("@lhp", maLHP);

            if (DbConnection.conn.State == ConnectionState.Closed)
                DbConnection.conn.Open();

            SqlDataReader rd = cmd.ExecuteReader();

            if (rd.Read())
            {
                int da = Convert.ToInt32(rd["da_dang_ky"]);
                int td = Convert.ToInt32(rd["so_luong_toi_da"]);
                rd.Close();
                DbConnection.conn.Close();
                return da < td;
            }

            rd.Close();
            DbConnection.conn.Close();
            return false;
        }

        
        private void dgvdanhsach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvdanhsach.Rows[e.RowIndex];

            txtmamon.Text = row.Cells[0].Value.ToString();
            txttenmon.Text = row.Cells[1].Value.ToString();
            txtsotinchi.Text = row.Cells[2].Value.ToString();
            cbohocky.Text = row.Cells[3].Value.ToString();
            cbolop.Text = row.Cells[4].Value.ToString();
            cbophonghoc.Text = row.Cells[5].Value.ToString();
            cbolichhoc.Text = row.Cells[6].Value.ToString();

            string maLHP = row.Cells[4].Value.ToString();
            LoadLopHocPhanDangMo(txtmamon.Text, GetMaHocKy());
            LoadSiSo(maLHP);
        }
        private string GetMaHocKy()
        {
            return cbohocky.SelectedValue?.ToString();
        }

        private void btnhuy_Click(object sender, EventArgs e)
        {
            if (dgvdanhsach.CurrentRow == null)
            {
                MessageBox.Show("Chọn môn cần huỷ!");
                return;
            }

            string maLHP = dgvdanhsach.CurrentRow.Cells[4].Value.ToString();

            string sql = @"
        UPDATE DangKyLopHocPhan 
        SET trang_thai = N'Đã huỷ'
        WHERE ma_sv = @sv AND ma_lhp = @lhp
    ";

            SqlCommand cmd = new SqlCommand(sql, DbConnection.conn);
            cmd.Parameters.AddWithValue("@sv", maSv);
            cmd.Parameters.AddWithValue("@lhp", maLHP);

            if (DbConnection.conn.State == ConnectionState.Closed)
                DbConnection.conn.Open();

            cmd.ExecuteNonQuery();
            DbConnection.conn.Close();

            MessageBox.Show("Đã huỷ môn học!");
            LoadDanhSachDaDangKy();
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            if (dgvdanhsach.CurrentRow == null)
            {
                MessageBox.Show("Chọn môn cần đổi lớp!");
                return;
            }

            if (cbolop.SelectedIndex < 0)
            {
                MessageBox.Show("Chọn lớp mới!");
                return;
            }

            string maLHPcu = dgvdanhsach.CurrentRow.Cells[4].Value.ToString();
            DataRowView row = (DataRowView)cbolop.SelectedItem;

            string maLHPmoi = row["ma_lhp"].ToString();
            string thuMoi = row["thu"].ToString();
            string caMoi = row["ca_hoc"].ToString();

            if (maLHPcu == maLHPmoi)
            {
                MessageBox.Show("Bạn đang chọn lại chính lớp cũ!");
                return;
            }

            if (CheckTrungLichKhiSua(thuMoi, caMoi, maLHPcu))
            {
                MessageBox.Show("Trùng lịch với môn khác!");
                return;
            }

            if (!KiemTrasiso(maLHPmoi))
            {
                MessageBox.Show("Lớp mới đã đủ sĩ số!");
                return;
            }

            string sql = @"
                UPDATE DangKyLopHocPhan 
                SET ma_lhp = @lhpMoi
                WHERE ma_sv = @sv AND ma_lhp = @lhpCu
            ";

            SqlCommand cmd = new SqlCommand(sql, DbConnection.conn);
            cmd.Parameters.AddWithValue("@sv", maSv);
            cmd.Parameters.AddWithValue("@lhpCu", maLHPcu);
            cmd.Parameters.AddWithValue("@lhpMoi", maLHPmoi);

            if (DbConnection.conn.State == ConnectionState.Closed)
                DbConnection.conn.Open();

            cmd.ExecuteNonQuery();
            DbConnection.conn.Close();

            MessageBox.Show("Đổi lớp thành công!");
            LoadDanhSachDaDangKy();
            LoadSiSo(maLHPmoi);
        }

        private void cbolop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbolop.SelectedIndex < 0) return;

            DataRowView row = (DataRowView)cbolop.SelectedItem;

            string maLHP = row["ma_lhp"].ToString();
            string thu = row["thu"].ToString();
            string ca = row["ca_hoc"].ToString();
            string phong = row["phong_hoc"].ToString();


            cbophonghoc.Text = phong;


            cbolichhoc.Items.Clear();
            cbolichhoc.Items.Add("Thứ " + thu + " - Ca " + ca);
            cbolichhoc.SelectedIndex = 0;


            LoadSiSo(maLHP);
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            string key = txttimkiem.Text.Trim();

            if (key == "")
            {
                MessageBox.Show("Nhập mã môn hoặc tên môn để tìm!");
                return;
            }

            string sql = @"
                SELECT mh.ma_mon,mh.ten_mon, mh.so_tin_chi, hk.ten_hoc_ky + N' - ' + hk.nam_hoc AS hoc_ky, lhp.ma_lhp, lhp.phong_hoc,
                N'Thứ ' + CAST(lhp.thu AS NVARCHAR) + N' - Ca ' + lhp.ca_hoc AS lich_hoc
                FROM DangKyLopHocPhan dk
                JOIN LopHocPhan lhp ON dk.ma_lhp = lhp.ma_lhp
                JOIN MonHoc mh ON lhp.ma_mon = mh.ma_mon
                JOIN HocKy hk ON lhp.ma_hoc_ky = hk.ma_hoc_ky
                WHERE dk.ma_sv = @sv
                  AND dk.trang_thai = N'Đã đăng ký'
                  AND (mh.ma_mon LIKE @key OR mh.ten_mon LIKE @key)
            ";

            SqlCommand cmd = new SqlCommand(sql, DbConnection.conn);
            cmd.Parameters.AddWithValue("@sv", maSv);
            cmd.Parameters.AddWithValue("@key", "%" + key + "%");

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dgvdanhsach.DataSource = dt;
        }
    }
}
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
using static System.Collections.Specialized.BitVector32;

namespace StudentCourseRegistrationSystem
{
    public partial class FormSV_DKTC : Form
    {
        private string maSv;
        public FormSV_DKTC(string maSv)
        {
            InitializeComponent();
            this.maSv = maSv;
        }

        private void FormSV_DKTC_Load(object sender, EventArgs e)
        {
            loadmonhoc();
            LoadHocKy();
        }
        private void loadmonhoc()
        {
            String sql = "SELECT DISTINCT mh.ma_mon, mh.ten_mon, mh.so_tin_chi FROM MonHoc mh JOIN LopHocPhan lhp ON mh.ma_mon = lhp.ma_mon WHERE lhp.trang_thai =" +
            " N'Đang mở'";
            DbConnection.ketnoi(dgvdsmonhoc, sql);
        }

        private bool CheckTrungLich(string thu, string caHoc)
        {
            string sql = @"
                SELECT COUNT(*)
                FROM DangKyTinChi dk
                JOIN LopHocPhan lhp ON dk.ma_lhp = lhp.ma_lhp
                WHERE dk.ma_sv = @sv
                AND dk.trang_thai = N'Đã đăng ký'
                AND lhp.thu = @thu
                AND lhp.ca_hoc = @ca
            ";

            SqlCommand cmd = new SqlCommand(sql, DbConnection.conn);
            cmd.Parameters.AddWithValue("@sv", maSv);
            cmd.Parameters.AddWithValue("@thu", thu);
            cmd.Parameters.AddWithValue("@ca", caHoc);
            if (DbConnection.conn.State == ConnectionState.Closed)
                DbConnection.conn.Open();
            int count = (int)cmd.ExecuteScalar();
            cmd.Dispose();
            DbConnection.conn.Close();
            return count > 0;

        }

        private void btndangky_Click(object sender, EventArgs e)
        {
            if (cbolop.SelectedIndex < 0)
            {
                MessageBox.Show("Bạn chưa chọn lớp học phần!");
                return;
            }

            DataRowView row = (DataRowView)cbolop.SelectedItem;

            string maLHP = row["ma_lhp"].ToString();
            string thu = row["thu"].ToString();
            string caHoc = row["ca_hoc"].ToString();
            string maMon = txtmamon.Text;

            if (CheckTrungMon(maMon))
            {
                MessageBox.Show("Bạn đã đăng ký môn này rồi!");
                return;
            }

            if (CheckTrungLich(thu, caHoc))
            {
                MessageBox.Show($" Trùng lịch! Bạn đã có môn vào {thu} - {caHoc}");
                return;
            }
            if (!KiemTrasiso(maLHP))
            {
                MessageBox.Show("Lớp đã đủ sĩ số!");
                return;
            }

            DangKy(maLHP);
            CapNhatSiSo(maLHP);
            LoadSiSo(maLHP);
        }
        private bool CheckTrungMon(string maMon)
        {
            string sql = @"
                SELECT COUNT(*)
                FROM DangKyTinChi dk
                JOIN LopHocPhan lhp ON dk.ma_lhp = lhp.ma_lhp
                WHERE dk.ma_sv = @sv
                AND dk.trang_thai = N'Đã đăng ký'
                AND lhp.ma_mon = @maMon
            ";

            SqlCommand cmd = new SqlCommand(sql, DbConnection.conn);
            cmd.Parameters.AddWithValue("@sv", maSv);
            cmd.Parameters.AddWithValue("@maMon", maMon);

            if (DbConnection.conn.State == ConnectionState.Closed)
                DbConnection.conn.Open();

            int count = (int)cmd.ExecuteScalar();
            DbConnection.conn.Close();

            return count > 0;
        }
        private void DangKy(string maLHP)
        {
            string sql = @"INSERT INTO DangKyTinChi(ma_sv, ma_lhp, loai_dang_ky, trang_thai)
                   VALUES(@sv, @lhp, N'Học mới', N'Đã đăng ký')";

            SqlCommand cmd = new SqlCommand(sql, DbConnection.conn);
            cmd.Parameters.AddWithValue("@sv", maSv);
            cmd.Parameters.AddWithValue("@lhp", maLHP);

            if (DbConnection.conn.State == ConnectionState.Closed)
                DbConnection.conn.Open();

            cmd.ExecuteNonQuery();
            DbConnection.conn.Close();

            MessageBox.Show(" Đăng ký thành công!");
        }
        private bool KiemTrasiso(string maLHP)
        {
            string sql = @"
                SELECT so_luong_da_dang_ky, so_luong_toi_da
                FROM LopHocPhan
                WHERE ma_lhp = @lhp
            ";

            SqlCommand cmd = new SqlCommand(sql, DbConnection.conn);
            cmd.Parameters.AddWithValue("@lhp", maLHP);

            if (DbConnection.conn.State == ConnectionState.Closed)
                DbConnection.conn.Open();

            SqlDataReader rd = cmd.ExecuteReader();

            if (rd.Read())
            {
                int daDangKy = Convert.ToInt32(rd["so_luong_da_dang_ky"]);
                int toiDa = Convert.ToInt32(rd["so_luong_toi_da"]);

                rd.Close();
                DbConnection.conn.Close();

                return daDangKy < toiDa;
            }

            rd.Close();
            DbConnection.conn.Close();
            return false;
        }
        private void CapNhatSiSo(string maLHP)
        {
            string sql = @"
                UPDATE LopHocPhan
                SET so_luong_da_dang_ky = so_luong_da_dang_ky + 1
                WHERE ma_lhp = @lhp
            ";

            SqlCommand cmd = new SqlCommand(sql, DbConnection.conn);
            cmd.Parameters.AddWithValue("@lhp", maLHP);

            if (DbConnection.conn.State == ConnectionState.Closed)
                DbConnection.conn.Open();

            cmd.ExecuteNonQuery();
            DbConnection.conn.Close();
        }

        private void LoadSiSo(string maLHP)
        {
            string sql = @"
                SELECT so_luong_da_dang_ky, so_luong_toi_da
                FROM LopHocPhan
                WHERE ma_lhp = @lhp
            ";

            SqlCommand cmd = new SqlCommand(sql, DbConnection.conn);
            cmd.Parameters.AddWithValue("@lhp", maLHP);

            if (DbConnection.conn.State == ConnectionState.Closed)
                DbConnection.conn.Open();

            SqlDataReader rd = cmd.ExecuteReader();

            if (rd.Read())
            {
                int daDangKy = Convert.ToInt32(rd["so_luong_da_dang_ky"]);
                int toiDa = Convert.ToInt32(rd["so_luong_toi_da"]);

                txtsiso.Text = daDangKy + " / " + toiDa;
            }

            rd.Close();
            DbConnection.conn.Close();
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
                SELECT DISTINCT mh.ma_mon, mh.ten_mon, mh.so_tin_chi
                FROM MonHoc mh
                JOIN LopHocPhan lhp ON mh.ma_mon = lhp.ma_mon
                WHERE lhp.trang_thai = N'Đang mở'
                AND (mh.ma_mon LIKE @key OR mh.ten_mon LIKE @key)
               ";

            SqlCommand cmd = new SqlCommand(sql, DbConnection.conn);
            cmd.Parameters.AddWithValue("@key", "%" + key + "%");

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dgvdsmonhoc.DataSource = dt;
        }

        private void cbolop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbolop.SelectedIndex < 0) return;

            DataRowView row = (DataRowView)cbolop.SelectedItem;

            string maLHP = row["ma_lhp"].ToString();
            string thu = row["thu"].ToString();
            string ca = row["ca_hoc"].ToString();

            LoadSiSo(maLHP);
            cbolichhoc.Items.Clear();
            cbolichhoc.Items.Add("Thứ " + thu + " - Ca " + ca);
            cbolichhoc.SelectedIndex = 0;
        }
        private void cbohocky_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadLopHocPhan();
        }

        private void dgvdsmonhoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvdsmonhoc.Rows[e.RowIndex];

                txtmamon.Text = row.Cells[0].Value.ToString();
                txttenmon.Text = row.Cells[1].Value.ToString();
                txtsotinchi.Text = row.Cells[2].Value.ToString();

                // Sau khi chọn môn → load lớp học phần
                LoadLopHocPhan();
            }

        }
        private void LoadLopHocPhan()
        {
            if (txtmamon.Text.Trim() == "" || cbohocky.SelectedIndex < 0)
                return;

            string sql = @"
                SELECT ma_lhp, phong_hoc, thu, ca_hoc, so_luong_da_dang_ky, so_luong_toi_da
                FROM LopHocPhan
                WHERE ma_mon = @maMon
                AND ma_hoc_ky = @hk
                AND trang_thai = N'Đang mở'
            ";

            SqlCommand cmd = new SqlCommand(sql, DbConnection.conn);
            cmd.Parameters.AddWithValue("@maMon", txtmamon.Text);
            cmd.Parameters.AddWithValue("@hk", cbohocky.SelectedValue);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            cbolop.DataSource = dt;
            cbolop.DisplayMember = "phong_hoc";
            cbolop.ValueMember = "ma_lhp";
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


    }
}
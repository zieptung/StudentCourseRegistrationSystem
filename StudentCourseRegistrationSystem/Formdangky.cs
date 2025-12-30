using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace StudentCourseRegistrationSystem
{
    public partial class Formdangky : Form
    {
        private readonly string Malienket;
        public Formdangky(string malienket)
        {
            InitializeComponent();
            this.Malienket = malienket;
        }

       

        public void load_Formdangky()
        {
            String sql = @"SELECT lhp.ma_lhp,mh.ten_mon,mh.so_tin_chi,lhp.so_luong_toi_da,lhp.so_luong_da_dang_ky
                    FROM LopHocPhan lhp 
                    JOIN MonHoc mh ON lhp.ma_mon=mh.ma_mon 
                    WHERE lhp.trang_thai = N'mở' AND lhp.so_luong_da_dang_ky < lhp.so_luong_toi_da;";
            DbConnection.ketnoi_dulieu(DRVdangky, sql);
        }
        

        
        private void Formdangky_Load(object sender, EventArgs e)
        {
            LoadHocKy();
            LoadLopHocPhanTheoHocKy();
            load_Formdangky();
            LoadMonDaDangKy();
        }
        private void LoadLopHocPhanTheoHocKy()
        {
            string sql = @"
                SELECT ma_lhp
                FROM LopHocPhan
                WHERE trang_thai = N'mở'
                AND ma_hoc_ky = @hk
                AND so_luong_da_dang_ky < so_luong_toi_da";

            using (var conn = DbConnection.GetConnection())
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@hk", cbohocky.SelectedValue.ToString());

                var dt = new DataTable();
                new SqlDataAdapter(cmd).Fill(dt);

                cbolop.DataSource = dt;
                cbolop.DisplayMember = "ma_lhp";
                cbolop.ValueMember = "ma_lhp";
                cbolop.SelectedIndex = dt.Rows.Count > 0 ? 0 : -1;

                if (dt.Rows.Count > 0)
                    LoadLichHoc(cbolop.SelectedValue.ToString());
                else
                    cbolichhoc.DataSource = null;
            }
        }
        private void btndangky_Click(object sender, EventArgs e)
        {
            if (cbohocky.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn học kỳ!");
                return;
            }

            if (cbolop.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn lớp học phần!");
                return;
            }

            
            if (cbolichhoc.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn lịch học!");
                return;
            }

            string maLHP = cbolop.SelectedValue.ToString();
            int maTKB = Convert.ToInt32(cbolichhoc.SelectedValue);
            string maHocKy = cbohocky.SelectedValue.ToString();
            DbConnection.conn.Open();
            SqlTransaction tran = DbConnection.conn.BeginTransaction();

            try
            {
               
                string checkDay = @" SELECT 1 FROM LopHocPhan WHERE ma_lhp = @lhp AND so_luong_da_dang_ky >= so_luong_toi_da";

                SqlCommand cmdCheckDay = new SqlCommand(checkDay, DbConnection.conn, tran);
                cmdCheckDay.Parameters.AddWithValue("@lhp", maLHP);

                if (cmdCheckDay.ExecuteScalar() != null)
                {
                    MessageBox.Show("Lớp học phần đã đầy!");
                    tran.Rollback();
                    DbConnection.conn.Close();
                    return;
                }

                if (TrungMaMon(Malienket, maLHP, maHocKy, tran))
                {
                    MessageBox.Show("Bạn đã đăng ký môn học này trong học kỳ rồi!");
                    tran.Rollback();
                    DbConnection.conn.Close();
                    return;
                }

                string checkTrung = @" SELECT 1 FROM DangKyHocPhan dk JOIN ThoiKhoaBieu tkb1 ON dk.ma_tkb = tkb1.ma_tkb JOIN ThoiKhoaBieu tkb2 ON tkb2.ma_tkb = @tkb WHERE dk.ma_sv = @sv AND tkb1.thu = tkb2.thu AND ( tkb1.tiet_bat_dau <= tkb2.tiet_bat_dau + tkb2.so_tiet - 1 AND tkb1.tiet_bat_dau +    tkb1.so_tiet - 1 >= tkb2.tiet_bat_dau )";

                SqlCommand cmdTrung = new SqlCommand(checkTrung, DbConnection.conn, tran);
                cmdTrung.Parameters.AddWithValue("@sv", Malienket);
                cmdTrung.Parameters.AddWithValue("@tkb", maTKB);

                if (cmdTrung.ExecuteScalar() != null)
                {
                    MessageBox.Show("Trùng lịch học với môn đã đăng ký!");
                    tran.Rollback();
                    DbConnection.conn.Close();
                    return;
                }

                string insert = @" INSERT INTO DangKyHocPhan (ma_sv, ma_lhp, ma_tkb, ma_hoc_ky, ngay_dang_ky, trang_thai) VALUES (@sv, @lhp, @tkb, @hk, GETDATE(), N'đăng ký')";

                SqlCommand cmdInsert = new SqlCommand(insert, DbConnection.conn, tran);
                cmdInsert.Parameters.AddWithValue("@sv", Malienket);
                cmdInsert.Parameters.AddWithValue("@lhp", maLHP);
                cmdInsert.Parameters.AddWithValue("@tkb", maTKB);
                cmdInsert.Parameters.AddWithValue("@hk", maHocKy);
                cmdInsert.ExecuteNonQuery();

                string update = @"UPDATE LopHocPhan SET so_luong_da_dang_ky = so_luong_da_dang_ky + 1 WHERE ma_lhp = @lhp";

                SqlCommand cmdUpdate = new SqlCommand(update, DbConnection.conn, tran);
                cmdUpdate.Parameters.AddWithValue("@lhp", maLHP);
                cmdUpdate.ExecuteNonQuery();

                tran.Commit();
                MessageBox.Show("Đăng ký môn học thành công!");

                LoadMonDaDangKy(); // refresh grid
            }
            catch (Exception ex)
            {
                tran.Rollback();
                MessageBox.Show("Đăng ký thất bại!\n" + ex.Message);
            }
            DbConnection.conn.Close();

        }

        private void txtmamon_Leave(object sender, EventArgs e)
        {
            if (txtmamon.Text.Trim() == "") return;

            string sql = "SELECT ten_mon, so_tin_chi FROM MonHoc WHERE ma_mon = @ma_mon";
            SqlCommand cmd = new SqlCommand(sql, DbConnection.conn);
            cmd.Parameters.AddWithValue("@ma_mon", txtmamon.Text.Trim());

            DbConnection.conn.Open();
            SqlDataReader rd = cmd.ExecuteReader();

            if (rd.Read())
            {
                txttenmon.Text = rd["ten_mon"].ToString();
                txttinchi.Text = rd["so_tin_chi"].ToString(); 
                rd.Close();
                DbConnection.conn.Close();

                LoadLopHocPhan();
            }
            else
            {
                rd.Close();
                DbConnection.conn.Close();

                MessageBox.Show("Không tìm thấy mã môn!");
                txttenmon.Clear();
                txttinchi.Clear();
            }
        }

        private void txttenmon_Leave(object sender, EventArgs e)
        {
            if (txtmamon.Text.Trim() != "") return;
            if (txttenmon.Text.Trim() == "") return;

            string sql = @"SELECT TOP 1 ma_mon, ten_mon, so_tin_chi FROM MonHoc WHERE ten_mon LIKE @tenmon";

            SqlCommand cmd = new SqlCommand(sql, DbConnection.conn);
            cmd.Parameters.AddWithValue("@tenmon", "%" + txttenmon.Text.Trim() + "%");

            DbConnection.conn.Open();
            SqlDataReader rd = cmd.ExecuteReader();

            if (rd.Read())
            {
                txtmamon.Text = rd["ma_mon"].ToString();
                txttenmon.Text = rd["ten_mon"].ToString();
                lable1.Text = rd["so_tin_chi"].ToString();
                rd.Close();
                DbConnection.conn.Close();
                LoadLopHocPhan();
            }
            else
            {
                rd.Close();
                DbConnection.conn.Close();
                MessageBox.Show("Không tìm thấy môn!");
            }
        }
        private void LoadLopHocPhan()
        {
            string sql = @"SELECT ma_lhp FROM LopHocPhan WHERE ma_mon = @ma_mon AND trang_thai = N'mở'";

            SqlCommand cmd = new SqlCommand(sql, DbConnection.conn);
            cmd.Parameters.AddWithValue("@ma_mon", txtmamon.Text.Trim());

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            cbolop.DataSource = dt;
            cbolop.DisplayMember = "ma_lhp";
            cbolop.ValueMember = "ma_lhp";
            cbolop.SelectedIndex = -1;
        }

        private void cbolop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbolop.SelectedValue == null) return;

            string maLHP = cbolop.SelectedValue.ToString();

            if (LopDaDay(maLHP))
            {
                MessageBox.Show("Lớp học phần đã đầy!");
                cbolop.SelectedIndex = -1;
                return;
            }

            
            LoadLichHoc(maLHP);
        }
        private void LoadLichHoc(string maLHP)
        {
            string sql = @"
                SELECT ma_tkb,
               CONCAT(N'Thứ ', thu, N' | Tiết ', tiet_bat_dau, '-', (tiet_bat_dau + so_tiet - 1)) AS lich_hoc
                FROM ThoiKhoaBieu
                WHERE ma_lhp = @ma_lhp";

            using (var conn = DbConnection.GetConnection())
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@ma_lhp", maLHP);

                var dt = new DataTable();
                new SqlDataAdapter(cmd).Fill(dt);

                cbolichhoc.DataSource = dt;
                cbolichhoc.DisplayMember = "lich_hoc";
                cbolichhoc.ValueMember = "ma_tkb";
                cbolichhoc.SelectedIndex = dt.Rows.Count > 0 ? 0 : -1;
            }
        }

        private bool LopDaDay(string maLHP)
        {
            string sql = @"SELECT 1 FROM LopHocPhan WHERE ma_lhp=@ma_lhp AND so_luong_da_dang_ky >= so_luong_toi_da";

            SqlCommand cmd = new SqlCommand(sql, DbConnection.conn);
            cmd.Parameters.AddWithValue("@ma_lhp", maLHP);

            DbConnection.conn.Open();
            bool day = cmd.ExecuteScalar() != null;
            DbConnection.conn.Close();

            return day;
        }
        private bool TrungLichTheoBuoi(int maTKB)
        {
            string sql = @" SELECT 1 FROM DangKyHocPhan dk JOIN ThoiKhoaBieu tkb1 ON dk.ma_tkb = tkb1.ma_tkb JOIN ThoiKhoaBieu tkb2 ON tkb2.ma_tkb = @tkb WHERE dk.ma_sv = @sv AND tkb1.thu = tkb2.thu AND ( tkb1.tiet_bat_dau <= tkb2.tiet_bat_dau + tkb2.so_tiet - 1 AND tkb1.tiet_bat_dau + tkb1.so_tiet - 1 >= tkb2.tiet_bat_dau )";

            SqlCommand cmd = new SqlCommand(sql, DbConnection.conn);
            cmd.Parameters.AddWithValue("@sv", Malienket);
            cmd.Parameters.AddWithValue("@tkb", maTKB);

            DbConnection.conn.Open();
            bool trung = cmd.ExecuteScalar() != null;
            DbConnection.conn.Close();

            return trung;
        }
        private bool TrungMaMon(string maSV, string maLHP, string maHocKy,SqlTransaction tran)
        {
            string sql = @" SELECT 1 FROM DangKyHocPhan dk JOIN LopHocPhan lhp ON dk.ma_lhp = lhp.ma_lhp WHERE dk.ma_sv = @sv AND dk.ma_hoc_ky = @hk 
                AND lhp.ma_mon = ( SELECT ma_mon FROM LopHocPhan WHERE ma_lhp = @lhp)";

            SqlCommand cmd = new SqlCommand(sql, DbConnection.conn,tran);
            cmd.Parameters.AddWithValue("@sv", maSV);
            cmd.Parameters.AddWithValue("@hk", maHocKy);
            cmd.Parameters.AddWithValue("@lhp", maLHP);

            bool trung = cmd.ExecuteScalar() != null;
            return trung;
        }


        private void LoadMonDaDangKy()
        {
            string sql = @"SELECT dk.ma_dk,mh.ma_mon,mh.ten_mon,mh.so_tin_chi,dk.ma_lhp,dk.ma_hoc_ky,hk.ten_hoc_ky,hk.nam_hoc,CONCAT(RTRIM(hk.ten_hoc_ky),N' (',RTRIM(hk.nam_hoc),N')') AS hoc_ky,CONCAT(N'Thứ ', tkb.thu,N' | Tiết ',tkb.tiet_bat_dau, '-', (tkb.tiet_bat_dau + tkb.so_tiet - 1)) AS lich_hoc FROM DangKyHocPhan dk JOIN LopHocPhan lhp ON dk.ma_lhp = lhp.ma_lhp JOIN MonHoc mh ON lhp.ma_mon = mh.ma_mon JOIN ThoiKhoaBieu tkb ON dk.ma_tkb = tkb.ma_tkb JOIN HocKy hk ON dk.ma_hoc_ky = hk.ma_hoc_ky WHERE dk.ma_sv = @sv ORDER BY hk.ngay_bat_dau DESC, mh.ma_mon";

            using (var conn = DbConnection.GetConnection())
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@sv", SqlDbType.NVarChar, 50).Value = Malienket;

                var dt = new DataTable();
                using (var da = new SqlDataAdapter(cmd))
                    da.Fill(dt);

                DRVdangky.DataSource = dt;
            }
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
            cmd.Parameters.AddWithValue("@sv", Malienket);
            cmd.Parameters.AddWithValue("@key", "%" + key + "%");

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            DRVdangky.AutoGenerateColumns = false;
            DRVdangky.DataSource = dt;

        }

        private void btnhuy_Click(object sender, EventArgs e)
        {

            if (DRVdangky.CurrentRow == null || DRVdangky.CurrentRow.IsNewRow)
            {
                MessageBox.Show("Vui lòng chọn môn cần hủy!");
                return;
            }

            
            int maDK = Convert.ToInt32(DRVdangky.CurrentRow.Cells["ma_dk"].Value);

            string maLHP = DRVdangky.CurrentRow.Cells["ma_lhp"].Value.ToString();

            DialogResult dr = MessageBox.Show(
                "Bạn có chắc chắn muốn hủy đăng ký môn học này?",
                "Xác nhận hủy",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (dr != DialogResult.Yes) return;

            string delete = @"DELETE FROM DangKyHocPhan WHERE ma_dk = @ma_dk";

            string update = @" UPDATE LopHocPhan SET so_luong_da_dang_ky = so_luong_da_dang_ky - 1 WHERE ma_lhp = @lhp AND so_luong_da_dang_ky > 0";

            DbConnection.conn.Open();
            SqlTransaction tran = DbConnection.conn.BeginTransaction();

            try
            {
                
                SqlCommand cmdDel = new SqlCommand(delete, DbConnection.conn, tran);
                cmdDel.Parameters.AddWithValue("@ma_dk", maDK);

                int rows = cmdDel.ExecuteNonQuery();
                if (rows == 0)
                    throw new Exception("Không tìm thấy bản ghi để xóa!");

                
                SqlCommand cmdUpd = new SqlCommand(update, DbConnection.conn, tran);
                cmdUpd.Parameters.AddWithValue("@lhp", maLHP);
                cmdUpd.ExecuteNonQuery();

                tran.Commit();
                MessageBox.Show("Hủy đăng ký thành công!");

                LoadMonDaDangKy(); 
            }
            catch (Exception ex)
            {
                tran.Rollback();
                MessageBox.Show("Hủy thất bại!\n" + ex.Message);
            }
                DbConnection.conn.Close();
            }
        private void LoadHocKy()
        {
            string sql = @"SELECT ma_hoc_ky,
                          ten_hoc_ky + N' (' + nam_hoc + N')' AS hocky_hienthi
                          FROM HocKy
                          ORDER BY ngay_bat_dau DESC";

            using (var conn = DbConnection.GetConnection())
            using (var da = new SqlDataAdapter(sql, conn))
            {
                var dt = new DataTable();
                da.Fill(dt);

                cbohocky.DataSource = dt;
                cbohocky.DisplayMember = "hocky_hienthi";
                cbohocky.ValueMember = "ma_hoc_ky";

                cbohocky.SelectedIndex = dt.Rows.Count > 0 ? 0 : -1;
            }
        }

        private void cbolop_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbolop.SelectedValue == null) return;
            LoadLichHoc(cbolop.SelectedValue.ToString());
        }

        private void cbohocky_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadLopHocPhanTheoHocKy();
        }

        private void DRVdangky_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
 
       

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
        public string MaSV = "SV001";
        public Formdangky()
        {
            InitializeComponent();
           
        }

       

        public void load_Formdangky()
        {
            String sql = "SELECT lhp.ma_lhp,mh.ten_mon,mh.so_tin_chi,lhp.so_luong_toi_da,lhp.so_luong_da_dang_ky FROM LopHocPhan lhp JOIN MonHoc mh ON lhp.ma_mon=mh.ma_mon WHERE lhp.trang_thai = N'mở'AND lhp.so_luong_da_dang_ky < lhp.so_luong_toi_da;";
            ketnoi.ketnoi_dulieu(DRVdangky, sql);
        }
        

        
        private void Formdangky_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLTCDataSet.LopHocPhan' table. You can move, or remove it, as needed.
            this.lopHocPhanTableAdapter.Fill(this.qLTCDataSet.LopHocPhan);
            // TODO: This line of code loads data into the 'qLTCDataSet.ThoiKhoaBieu' table. You can move, or remove it, as needed.


        }



        private void btndangky_Click(object sender, EventArgs e)
        {
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

            ketnoi.conn.Open();
            SqlTransaction tran = ketnoi.conn.BeginTransaction();

            try
            {
               
                string checkDay = @" SELECT 1 FROM LopHocPhan WHERE ma_lhp = @lhp AND so_luong_da_dang_ky >= so_luong_toi_da";

                SqlCommand cmdCheckDay = new SqlCommand(checkDay, ketnoi.conn, tran);
                cmdCheckDay.Parameters.AddWithValue("@lhp", maLHP);

                if (cmdCheckDay.ExecuteScalar() != null)
                {
                    MessageBox.Show("Lớp học phần đã đầy!");
                    tran.Rollback();
                    ketnoi.conn.Close();
                    return;
                }

                string checkTrung = @" SELECT 1 FROM DangKyHocPhan dk JOIN ThoiKhoaBieu tkb1 ON dk.ma_tkb = tkb1.ma_tkb JOIN ThoiKhoaBieu tkb2 ON tkb2.ma_tkb = @tkb WHERE dk.ma_sv = @sv AND tkb1.thu = tkb2.thu AND ( tkb1.tiet_bat_dau <= tkb2.tiet_bat_dau + tkb2.so_tiet - 1 AND tkb1.tiet_bat_dau +    tkb1.so_tiet - 1 >= tkb2.tiet_bat_dau )";

                SqlCommand cmdTrung = new SqlCommand(checkTrung, ketnoi.conn, tran);
                cmdTrung.Parameters.AddWithValue("@sv", MaSV);
                cmdTrung.Parameters.AddWithValue("@tkb", maTKB);

                if (cmdTrung.ExecuteScalar() != null)
                {
                    MessageBox.Show("Trùng lịch học với môn đã đăng ký!");
                    tran.Rollback();
                    ketnoi.conn.Close();
                    return;
                }

                string insert = @"INSERT INTO DangKyHocPhan (ma_sv, ma_lhp, ma_tkb, ngay_dang_ky, trang_thai) VALUES (@sv, @lhp, @tkb, GETDATE(), N'đăng ký')";

                SqlCommand cmdInsert = new SqlCommand(insert, ketnoi.conn, tran);
                cmdInsert.Parameters.AddWithValue("@sv", MaSV);
                cmdInsert.Parameters.AddWithValue("@lhp", maLHP);
                cmdInsert.Parameters.AddWithValue("@tkb", maTKB);
                cmdInsert.ExecuteNonQuery();

                string update = @"UPDATE LopHocPhan SET so_luong_da_dang_ky = so_luong_da_dang_ky + 1 WHERE ma_lhp = @lhp";

                SqlCommand cmdUpdate = new SqlCommand(update, ketnoi.conn, tran);
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
                ketnoi.conn.Close();

        }

        private void txtmamon_Leave(object sender, EventArgs e)
        {
            if (txtmamon.Text.Trim() == "") return;

            string sql = "SELECT ten_mon FROM MonHoc WHERE ma_mon = @ma_mon";
            SqlCommand cmd = new SqlCommand(sql, ketnoi.conn);
            cmd.Parameters.AddWithValue("@ma_mon", txtmamon.Text.Trim());

            ketnoi.conn.Open();
            object rs = cmd.ExecuteScalar();
            ketnoi.conn.Close();

            if (rs != null)
            {
                txttenmon.Text = rs.ToString();
                LoadLopHocPhan();
            }
            else
            {
                MessageBox.Show("Không tìm thấy mã môn!");
                txttenmon.Clear();
            }
        }

        private void txttenmon_Leave(object sender, EventArgs e)
        {
            if (txtmamon.Text.Trim() != "") return;
            if (txttenmon.Text.Trim() == "") return;

            string sql = @"SELECT TOP 1 ma_mon, ten_mon FROM MonHoc WHERE ten_mon LIKE @tenmon";

            SqlCommand cmd = new SqlCommand(sql, ketnoi.conn);
            cmd.Parameters.AddWithValue("@tenmon", "%" + txttenmon.Text.Trim() + "%");

            ketnoi.conn.Open();
            SqlDataReader rd = cmd.ExecuteReader();

            if (rd.Read())
            {
                txtmamon.Text = rd["ma_mon"].ToString();
                txttenmon.Text = rd["ten_mon"].ToString();
                rd.Close();
                ketnoi.conn.Close();
                LoadLopHocPhan();
            }
            else
            {
                rd.Close();
                ketnoi.conn.Close();
                MessageBox.Show("Không tìm thấy môn!");
            }
        }
        private void LoadLopHocPhan()
        {
            string sql = @"SELECT ma_lhp FROM LopHocPhan WHERE ma_mon = @ma_mon AND trang_thai = N'mở'";

            SqlCommand cmd = new SqlCommand(sql, ketnoi.conn);
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
            string sql = @" SELECT ma_tkb, CONCAT( N'Thứ ', thu, N' | Tiết ', tiet_bat_dau, '-', (tiet_bat_dau + so_tiet - 1)) AS lich_hoc FROM ThoiKhoaBieu WHERE ma_lhp = @ma_lhp";

            SqlCommand cmd = new SqlCommand(sql, ketnoi.conn);
            cmd.Parameters.AddWithValue("@ma_lhp", maLHP);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            cbolichhoc.DataSource = dt;
            cbolichhoc.DisplayMember = "lich_hoc"; 
            cbolichhoc.ValueMember = "ma_tkb";     
            cbolichhoc.SelectedIndex = -1;
        }

        private bool LopDaDay(string maLHP)
        {
            string sql = @"SELECT 1 FROM LopHocPhan WHERE ma_lhp=@ma_lhp AND so_luong_da_dang_ky >= so_luong_toi_da";

            SqlCommand cmd = new SqlCommand(sql, ketnoi.conn);
            cmd.Parameters.AddWithValue("@ma_lhp", maLHP);

            ketnoi.conn.Open();
            bool day = cmd.ExecuteScalar() != null;
            ketnoi.conn.Close();

            return day;
        }
        private bool TrungLichTheoBuoi(int maTKB)
        {
            string sql = @" SELECT 1 FROM DangKyHocPhan dk JOIN ThoiKhoaBieu tkb1 ON dk.ma_tkb = tkb1.ma_tkb JOIN ThoiKhoaBieu tkb2 ON tkb2.ma_tkb = @tkb WHERE dk.ma_sv = @sv AND tkb1.thu = tkb2.thu AND ( tkb1.tiet_bat_dau <= tkb2.tiet_bat_dau + tkb2.so_tiet - 1 AND tkb1.tiet_bat_dau + tkb1.so_tiet - 1 >= tkb2.tiet_bat_dau )";

            SqlCommand cmd = new SqlCommand(sql, ketnoi.conn);
            cmd.Parameters.AddWithValue("@sv", MaSV);
            cmd.Parameters.AddWithValue("@tkb", maTKB);

            ketnoi.conn.Open();
            bool trung = cmd.ExecuteScalar() != null;
            ketnoi.conn.Close();

            return trung;
        }


        private void LoadMonDaDangKy()
        {
            string sql = @" SELECT mh.ma_mon, mh.ten_mon,dk.ma_lhp, CONCAT( N'Thứ ', tkb.thu, N' | Tiết ', tkb.tiet_bat_dau, '-', (tkb.tiet_bat_dau + tkb.so_tiet - 1)) AS lich_hoc FROM DangKyHocPhan dk JOIN LopHocPhan lhp ON dk.ma_lhp = lhp.ma_lhp JOIN MonHoc mh ON lhp.ma_mon = mh.ma_mon JOIN ThoiKhoaBieu tkb ON dk.ma_tkb = tkb.ma_tkb WHERE dk.ma_sv = @sv AND dk.trang_thai = N'đăng ký' ORDER BY mh.ma_mon, dk.ma_lhp";

            SqlCommand cmd = new SqlCommand(sql, ketnoi.conn);
            cmd.Parameters.AddWithValue("@sv", MaSV);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            DRVdangky.AutoGenerateColumns = false;
            DRVdangky.DataSource = dt;
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

            string sql = @"SELECT mh.ma_mon,mh.ten_mon,dk.ma_lhp, CONCAT( N'Thứ ', tkb.thu, N' | Tiết ',tkb.tiet_bat_dau, '-', (tkb.tiet_bat_dau + tkb.so_tiet - 1)) AS lich_hoc FROM DangKyHocPhan dk JOIN LopHocPhan lhp ON dk.ma_lhp = lhp.ma_lhp JOIN MonHoc mh ON lhp.ma_mon = mh.ma_mon JOIN ThoiKhoaBieu tkb ON dk.ma_tkb = tkb.ma_tkb WHERE dk.ma_sv = @sv AND (mh.ma_mon LIKE @key OR mh.ten_mon LIKE @key)";

            SqlCommand cmd = new SqlCommand(sql, ketnoi.conn);
            cmd.Parameters.AddWithValue("@sv", MaSV);
            cmd.Parameters.AddWithValue("@key", "%" + key + "%");

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            DRVdangky.DataSource = dt;
        }

        private void btnhuy_Click(object sender, EventArgs e)
        {

            if (DRVdangky.CurrentRow == null || DRVdangky.CurrentRow.IsNewRow)
            {
                MessageBox.Show("Vui lòng chọn môn cần hủy!");
                return;
            }

            
            string maLHP = DRVdangky.CurrentRow.Cells[2].Value.ToString();

            DialogResult dr = MessageBox.Show(
                "Bạn có chắc chắn muốn hủy đăng ký môn học này?",
                "Xác nhận hủy",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (dr != DialogResult.Yes) return;

            string delete = @"DELETE FROM DangKyHocPhan WHERE ma_sv = @sv AND ma_lhp = @lhp";

            string update = @"UPDATE LopHocPhan SET so_luong_da_dang_ky = so_luong_da_dang_ky - 1  WHERE ma_lhp = @lhp AND so_luong_da_dang_ky > 0";

            ketnoi.conn.Open();
            SqlTransaction tran = ketnoi.conn.BeginTransaction();

            try
            {
                SqlCommand cmd1 = new SqlCommand(delete, ketnoi.conn, tran);
                cmd1.Parameters.AddWithValue("@sv", MaSV);
                cmd1.Parameters.AddWithValue("@lhp", maLHP);   
                cmd1.ExecuteNonQuery();

                SqlCommand cmd2 = new SqlCommand(update, ketnoi.conn, tran);
                cmd2.Parameters.AddWithValue("@lhp", maLHP);  
                cmd2.ExecuteNonQuery();

                tran.Commit();
                MessageBox.Show("Hủy đăng ký thành công!");
                LoadMonDaDangKy();
            }
            catch (Exception ex)
            {
                tran.Rollback();
                MessageBox.Show("Hủy thất bại!\n" + ex.Message);
            }
                ketnoi.conn.Close();
        }

    }
}
 
       

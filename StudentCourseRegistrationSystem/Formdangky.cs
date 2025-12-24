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

namespace StudentCourseRegistrationSystem
{
    public partial class Formdangky : Form
    {
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
            load_Formdangky();

        }
        private void AddCheckBoxColumn()
        {
            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            chk.HeaderText = "Chọn";
            chk.Name = "chkChon";
            DRVdangky.Columns.Insert(0, chk);
        }


        private void btndangky_Click(object sender, EventArgs e)
        {
            string maSV = txtmasv.Text;
            ketnoi.conn.Open();

            foreach (DataGridViewRow row in DRVdangky.Rows)
            {
                bool chon = Convert.ToBoolean(row.Cells["chkChon"].Value);
                if (!chon) continue;

                string maLHP = row.Cells["ma_lhp"].Value.ToString();

                // 1. Kiểm tra đã đăng ký chưa
                string checkSql = @" SELECT COUNT(*) FROM DangKyHocPhan WHERE ma_sv = @ma_sv AND ma_lhp = @ma_lhp";

                SqlCommand checkCmd = new SqlCommand(checkSql, ketnoi.conn);
                checkCmd.Parameters.AddWithValue("@ma_sv", maSV);
                checkCmd.Parameters.AddWithValue("@ma_lhp", maLHP);

                int exists = (int)checkCmd.ExecuteScalar();
                if (exists > 0) continue;

                // 2. Insert đăng ký
                string insertSql = @"INSERT INTO DangKyHocPhan(ma_sv, ma_lhp, ngay_dang_ky, trang_thai)VALUES (@ma_sv, @ma_lhp, GETDATE(), N'đăng ký')";

                SqlCommand insertCmd = new SqlCommand(insertSql, ketnoi.conn);
                insertCmd.Parameters.AddWithValue("@ma_sv", maSV);
                insertCmd.Parameters.AddWithValue("@ma_lhp", maLHP);
                insertCmd.ExecuteNonQuery();

                // 3. Cập nhật số lượng
                string updateSql = @"UPDATE LopHocPhan SET so_luong_da_dang_ky = so_luong_da_dang_ky + 1 WHERE ma_lhp = @ma_lhp";

                SqlCommand updateCmd = new SqlCommand(updateSql, ketnoi.conn);
                updateCmd.Parameters.AddWithValue("@ma_lhp", maLHP);
                updateCmd.ExecuteNonQuery();
            }

            ketnoi.conn.Close();
            MessageBox.Show("Đăng ký thành công!");
            load_Formdangky();
        }
      }
 }
       

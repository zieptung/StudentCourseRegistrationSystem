using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentCourseRegistrationSystem
{
    public partial class FormSV : Form
    {
        public string AvatarPath = @"avatar.jpg";
        private readonly string maSV;
        private readonly string Malienket;
        public FormSV(string maSV)
        {
            InitializeComponent();
            LoadThongTinSinhVien();
            this.maSV = maSV;
        }

        private void LoadThongTinSinhVien()
        {

            Image img;

            if (!string.IsNullOrEmpty(AvatarPath) && File.Exists(AvatarPath))
            {
                img = Image.FromFile(AvatarPath);
            }
            else
            {
               
                img = Properties.Resources.default_avatar;
            }

            avatar.Image = img;
            MakeAvatarCircle(avatar);
        }
        private void MakeAvatarCircle(PictureBox pic)
        {
            GraphicsPath gp = new GraphicsPath();
            gp.AddEllipse(0, 0, pic.Width - 1, pic.Height - 1);
            pic.Region = new Region(gp);
        }

        private void avatar_Click(object sender, EventArgs e)
        {

        }

        private void FormSV_Load(object sender, EventArgs e)
        {
            LoadDanhSachMonHoc();
            txtSV.Text = maSV;

            txtSV.ReadOnly = true;
            txtSV.Enabled = false;
        }

        private void btnDangxuat_Click_1(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (rs == DialogResult.Yes)
            {
                new FormLog().Show();
                this.Close();
            }
        }

        private void btnDkhp_Click(object sender, EventArgs e)
        {
            new Formdangky(Malienket).Show();
        }

        private void btnDsdk_Click(object sender, EventArgs e)
        {
            new FormDSmondangky(Malienket).Show();
        }

        private void btntkb_Click(object sender, EventArgs e)
        {
            new FormXemtkb(Malienket).Show();
        }

        private void LoadDanhSachMonHoc()
        {
            string sql = @"
            SELECT 
            mh.ma_mon   AS N'Mã môn',
            mh.ten_mon  AS N'Tên môn',
            mh.so_tin_chi AS N'Tín chỉ'
            FROM MonHoc mh";

            using (SqlConnection conn = DbConnection.GetConnection())
            using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvhocphan.DataSource = dt;
                dgvhocphan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void dgvhocphan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

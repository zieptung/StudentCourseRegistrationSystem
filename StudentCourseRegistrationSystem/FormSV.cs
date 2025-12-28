using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        public string tensv = "Nguyễn Văn A";
        public string AvatarPath = @"avatar.jpg";

        public FormSV()
        {
            InitializeComponent();
            LoadThongTinSinhVien();
        }

        private void LoadThongTinSinhVien()
        {
            lbltensv.Text = tensv;

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
        private void OpenForm(Form f)
        {
            panelMain.Controls.Clear();   
            f.TopLevel = false;           
            f.FormBorderStyle = FormBorderStyle.None;
            f.Dock = DockStyle.Fill;
            panelMain.Controls.Add(f);
            f.Show();
        }

        private void đăngKýMônHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm(new Formdangky());
        }

        private void danhSáchMônHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm(new FormDSmonhoc());
        }

        private void danhSáchMônĐãĐăngKýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm(new FormDSmondangky());
        }

        
    }
}

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
    public partial class FormAdmin : Form
    {
        public FormAdmin()
        {
            InitializeComponent();
        }

        private void FormAdmin_Load(object sender, EventArgs e)
        {

        }

        private void OpenFormInPanel(Form f)
        {
            pnlMain.Controls.Clear();

            f.TopLevel = false;
            f.FormBorderStyle = FormBorderStyle.None;
            f.Dock = DockStyle.Fill;

            pnlMain.Controls.Add(f);
            f.Show();
        }

        private void btnQLMH_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new FormQLMH());
        }

        private void btnQLLHP_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new FormQLLHP());
        }

        private void btnQLSV_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new FormQLSV());
        }

        private void btnQLGV_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new FormQLGV());
        }

        private void btnTK_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new FormTK());
        }

        private void btnHP_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new FormHP());
        }

        private void btnQLND_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new FormQLND());
        }

        private void btnDX_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (rs == DialogResult.No)
                return;

            FormLog f = new FormLog();
            f.Show();
            this.Close();
        }
    }
}

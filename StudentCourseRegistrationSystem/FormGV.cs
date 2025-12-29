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
    public partial class FormGV : Form
    {
        private readonly string maGV;

        public FormGV(string maGV)
        {
            InitializeComponent();
            this.maGV = maGV;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnQLMonHoc_Click(object sender, EventArgs e)
        {
            GV_QLMonHoc f = new GV_QLMonHoc();
            f.Owner = this;   
            f.Show();
            this.Hide();     
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?","Đăng xuất",MessageBoxButtons.YesNo,MessageBoxIcon.Question);

            if (rs == DialogResult.Yes)
            {
                new FormLog().Show();
                this.Close();
            }
        }

        private void FormGV_Load(object sender, EventArgs e)
        {
            txtGV.Text = maGV;
            txtGV.ReadOnly = true;
            txtGV.Enabled = false;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnXemttcn_Click(object sender, EventArgs e)
        {

        }

        private void dgvtkb_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

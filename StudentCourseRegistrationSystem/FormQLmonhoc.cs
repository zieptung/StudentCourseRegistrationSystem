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
    public partial class FormQLmonhoc : Form
    {
        public FormQLmonhoc()
        {
            InitializeComponent();
        }

        private void OpenForm(Form f)
        {
            panelMain.Controls.Clear();   // Xóa form cũ
            f.TopLevel = false;           // Form con
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
    }
}

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
    public partial class FormSV : Form
    {

        private readonly string maSv;
        public FormSV(string maSv)
        {
            InitializeComponent();
            this.maSv = maSv;
        }

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LoadThongTinSinhVien()
        {
            lblSV.Text = maSv;

            using (SqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                string sql =
                    "SELECT ho_ten FROM SinhVien WHERE ma_sv = '" + maSv + "'";

                SqlCommand cmd = new SqlCommand(sql, conn);
                object ten = cmd.ExecuteScalar();

                if (ten != null)
                    lblSV.Text = ten.ToString();
            }
        }

        private void OpenFormInPanel(Form f)
        {
            pnlMain.Controls.Clear();

            f.TopLevel = false;
            f.FormBorderStyle = FormBorderStyle.None;
            f.Dock = DockStyle.Fill;

            pnlMain.Controls.Add(f);
            pnlMain.Tag = f;

            f.BringToFront();
            f.Show();
        }

        private void FormSV_Load(object sender, EventArgs e)
        {
            LoadThongTinSinhVien();
        }

        private void btnDKTC_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new FormSV_DKTC(maSv));
        }
        private void btnDSTCDK_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new FormSV_DSTCDK(maSv));
        }
    }
}
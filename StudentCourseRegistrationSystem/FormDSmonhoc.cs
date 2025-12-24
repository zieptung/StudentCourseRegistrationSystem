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
    public partial class FormDSmonhoc : Form
    {
        public FormDSmonhoc()
        {
            InitializeComponent();
        }

        private void FormDSmonhoc_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLTCDataSet.MonHoc' table. You can move, or remove it, as needed.
            this.monHocTableAdapter.Fill(this.qLTCDataSet.MonHoc);

        }
        public void load_Formdanhsachmonhoc()
        {
            String sql = "select * from MonHoc";
            ketnoi.ketnoi_dulieu(DRVdanhsach, sql);
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            String tukhoa = txttimkiem.Text;
            String sql = "select * from MonHoc where ma_mon like N'%" + tukhoa + "%' or ten_mon like N'%" + tukhoa + "%'";
            ketnoi.ketnoi_dulieu(DRVdanhsach, sql);
        }
    }
}

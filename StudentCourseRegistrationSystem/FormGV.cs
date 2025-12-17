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
        private string Malienket;

        public FormGV(string Malienket)
        {
            InitializeComponent();
            this.Malienket = Malienket;
        }

        private void FormGV_Load(object sender, EventArgs e)
        {

        }
    }
}

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
    public partial class FormSV : Form
    {
        private string Malienket;

        public FormSV(string Malienket)
        {
            InitializeComponent();
            this.Malienket = Malienket;
        }

        private void FormSV_Load(object sender, EventArgs e)
        {

        }
    }
}

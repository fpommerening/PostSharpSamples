using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FP.PostSharpSamples.UI.Controls
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void tsmiOpen_Click(object sender, EventArgs e)
        {
            UserForm frm = new UserForm();
            frm.MdiParent = this;
            frm.Show();
        }


       
    }
}

using FP.PostSharpSamples.UI.Business;
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
    [IncludeErrorProviderAspect]
    public partial class TestForm : Form
    {
        private TestController _controller;

        
        public TestForm()
        {
            InitializeComponent();
            _controller = new TestController {DataSource = testViewModelBindingSource};
        }

        private void TestForm_Load(object sender, EventArgs e)
        {
            _controller.LoadData();
        }
    }
}

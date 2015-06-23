using FP.PostSharpSamples.UI.Business;
using System.Windows.Forms;

namespace FP.PostSharpSamples.UI.Controls
{
    public partial class TestForm : Form
    {
        TestController Controller;
        public TestForm()
        {
            InitializeComponent();
            Controller = new TestController { BindingSource = testModelViewBindingSource };
        }

        private void TestForm_Load(object sender, System.EventArgs e)
        {
            Controller.LoadData();
        }

        private void btnDataUpdate_Click(object sender, System.EventArgs e)
        {
            Controller.UpdateData();
        }
    }
}

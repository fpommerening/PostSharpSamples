using FP.PostSharpSamples.DAL;
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
            Controller = new TestController();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            var uow = new UnitOfWork();
            
        }
    }
}

using System.Windows.Forms;

namespace FP.PostSharpSamples.UI.Business
{
    public class TestController
    {
        public BindingSource DataSource { get; set; }


        public void LoadData()
        {
            var vm = new TestViewModel();
            DataSource.DataSource = vm;
        }
    }
}

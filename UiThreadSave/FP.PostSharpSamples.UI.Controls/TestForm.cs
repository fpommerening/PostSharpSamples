using FP.PostSharpSamples.UI.Business;
using System;
using System.ComponentModel;
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
            Controller.MessageSended += Controller_MessageSended;
        }

        [DispatchToUiThreadAspect]
        private void Controller_MessageSended(string obj)
        {
            label1.Text = obj;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Controller.StartLongProcess();
        }
    }
}

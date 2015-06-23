using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FP.PostSharpSamples.BL;

namespace FP.PostSharpSamples.UI.Controls
{
    public partial class DocumentControl : UserControl
    {
        public DocumentController Controller { get; private set; }

        public DocumentControl()
        {
            InitializeComponent();
            Controller = new DocumentController();
            Controller.DataSourceInitialized += Controller_DataSourceInitialized;
        }

        private void Controller_DataSourceInitialized(object sender, System.EventArgs e)
        {
            labObjectId.Text = string.Format("zu Objekt {0} geladen", Controller.ObjectId);
        }
    }
}

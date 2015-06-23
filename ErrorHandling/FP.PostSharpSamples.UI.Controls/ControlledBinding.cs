using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FP.PostSharpSamples.UI.Controls
{
    public class ControlledBinding
    {
        public System.ComponentModel.IDataErrorInfo DataSource { get; set; }

        public System.Windows.Forms.BindingSource BindingSource { get; set; }

        public String Property { get; set; }

        public System.Windows.Forms.Control TargetControl { get; set; }
    }
}

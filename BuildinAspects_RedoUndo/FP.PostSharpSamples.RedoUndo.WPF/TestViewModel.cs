using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PostSharp.Patterns.Model;
using PostSharp.Patterns.Recording;

namespace FP.PostSharpSamples.RedoUndo.WPF
{
    [NotifyPropertyChanged]
    [Recordable]
    public class TestViewModel
    {
        public string Field1 { get; set; }
        public string Field2 { get; set; }
        public Int32 Field3 { get; set; }
    }
}

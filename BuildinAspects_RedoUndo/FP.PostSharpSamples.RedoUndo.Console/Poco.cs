using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PostSharp.Patterns.Recording;

namespace FP.PostSharpSamples.RedoUndo.Console
{
    [Recordable]
    public class Poco
    {
        public string Name { get; set; }
        public string FirstName { get; set; }
        public DateTime LastLogin { get; set; }
    }
}

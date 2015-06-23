using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PostSharp.Patterns.Model;

namespace BuildinAspects
{
    [NotifyPropertyChanged]
    public class TestViewModel
    {
        public string Property1 { get; set; }
        public string Property2 { get; set; }
        public string Property3 { get; set; }
    }
}

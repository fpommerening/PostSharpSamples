using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FP.PostSharpSamples.UI.Business
{
    interface IPropertyChangeTracking : INotifyPropertyChanged, INotifyPropertyChanging
    {
        void OnPropertyChanging(string property, object oldValue, object newValue);
        void OnPropertyChanged(string property, object oldValue, object newValue);
    }
}

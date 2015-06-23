using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace BuildinAspects
{
    class Program
    {
        static void Main(string[] args)
        {
            var vm = new TestViewModel();
            ((INotifyPropertyChanged) vm).PropertyChanged += (sender, eventArgs) => Console.WriteLine(eventArgs.PropertyName);

            vm.Property1 = "Hallo";
            vm.Property2 = "Welt";


            Console.ReadLine();
        }
    }
}

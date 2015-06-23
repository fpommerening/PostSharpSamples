using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BuildinAspects
{
    class Program
    {
        static void Main(string[] args)
        {
            TestProcessor p = new TestProcessor();
            p.Method1("Hallo Welt", 42);
            Console.ReadLine();
        }
    }
}

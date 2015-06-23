using FP.PostSharpSamples.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCache
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Programm started");
                var ts = new TestService();

                List<DTOTest> result = ts.GetDataByGroup("GroupA");
                Console.WriteLine("ServiceCall for Group A Result {0} Items", result.Count);

                result = ts.GetDataByGroup("GroupA");
                Console.WriteLine("ServiceCall for Group A Result {0} Items", result.Count);

                result = ts.GetDataByGroup("GroupB");
                Console.WriteLine("ServiceCall for Group B Result {0} Items", result.Count);

                Console.WriteLine("Let's wait....");
                System.Threading.Thread.Sleep(5000);
                Console.WriteLine("Start new Call");
                result = ts.GetDataByGroup("GroupA");
                Console.WriteLine("ServiceCall for Group A Result {0} Items", result.Count);

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            Console.ReadLine();
        }
    }
}

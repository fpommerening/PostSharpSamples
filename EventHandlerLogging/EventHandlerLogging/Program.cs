using FP.PostSharpSamples.UI.Business;
using System;

namespace EventHandlerLogging
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var controller = new TestController();
                controller.LoadData();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            Console.ReadLine();
        }
    }
}

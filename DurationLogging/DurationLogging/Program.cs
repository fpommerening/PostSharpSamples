using FP.PostSharpSamples.DAL;
using System;

namespace DurationLogging
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var uow = new UnitOfWork();
                var models = uow.GetTestModels();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            Console.ReadLine();
        }
    }
}

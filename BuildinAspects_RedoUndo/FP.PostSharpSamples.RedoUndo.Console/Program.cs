using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PostSharp.Patterns.Recording;

namespace FP.PostSharpSamples.RedoUndo.Console
{
    class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Poco c = new Poco();
                c.Name = "Pommerening";
                c.FirstName = "Frank";
                c.LastLogin = DateTime.Now.AddDays(-2);
                c.LastLogin = DateTime.Now;

                System.Console.WriteLine(c.LastLogin);
                RecordingServices.DefaultRecorder.Undo();
                System.Console.WriteLine(c.LastLogin);
                RecordingServices.DefaultRecorder.Redo();
                System.Console.WriteLine(c.LastLogin);
            }
            catch(Exception ex)
            {
                System.Console.WriteLine(ex);
            }
            System.Console.ReadLine();
        }
    }
}

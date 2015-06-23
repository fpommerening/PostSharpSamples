using FP.PostSharpSamples.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FP.PostSharpSamples.BL;

namespace WrapException
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                log4net.Config.XmlConfigurator.Configure();

                UserMappings mappings = new UserMappings();
                mappings.CreateMapping();

                var bl = new BusinessLayer(new UserRepository());

                for (int i = 1; i < 4; i++)
                {
                    var user = bl.GetUserById(i);
                    if (user == null)
                    {
                        Console.WriteLine("Benutzer mit ID {0} wurde nicht gefunden", i);
                    }
                    else
                    {
                        Console.WriteLine("Benutzer mit ID {0} gefunden ({1} {2})", i, user.FirstName, user.Name);
                    }
                }

                bl.CreateUser(null);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception-Type: {0}", ex.GetType().Name);
                Console.WriteLine("Message:  {0}", ex.Message);
            }
            Console.ReadLine();
        }
    }
}

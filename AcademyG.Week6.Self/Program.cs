using AcademyG.Week6.WCF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AcademyG.Week6.Self
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(ClienteService)))
            {
                host.Open();

                Console.WriteLine("=== WCF Running ===");
                Console.WriteLine("Premi un tasto per uscire");
                Console.ReadKey();
            }
        }
    }
}

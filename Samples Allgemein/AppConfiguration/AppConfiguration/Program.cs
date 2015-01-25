using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppConfiguration
{
    class Program
    {
        static void Main(string[] args)
        {

            var appsettings = AppConfigurationSection.Settings;

            Console.WriteLine(appsettings.Name);
            Console.WriteLine(appsettings.SingleItem.Value1);

            foreach (ServerElement server in appsettings.Servers)
            {
                Console.WriteLine(server.Name);
            }

            var server1 = (from ServerElement s in appsettings.Servers where s.Name.Equals("Server1")  select s).FirstOrDefault();

            if (server1 != null)
                Console.WriteLine(server1.Position);

            


            Console.Write("Drücke <enter> um die Anwendung zu beenden");
            Console.ReadLine();
        }
    }
}

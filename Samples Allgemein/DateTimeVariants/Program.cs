using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateTimeVariants
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTimeOffset dtNow = DateTimeOffset.Now;

            Console.WriteLine(String.Format("Aktuell: {0}", dtNow.ToString()));

            DateTimeOffset dtUtcNow = dtNow.ToUniversalTime();

            Console.WriteLine(String.Format("Aktuell (als UTC): {0}", dtUtcNow.ToString()));

            string strUtcNow = dtUtcNow.ToString();

            Console.WriteLine(String.Format("Aktuell (als String): {0}", strUtcNow));

            DateTimeOffset dtReadUtcNow = DateTimeOffset.Parse(strUtcNow);

            Console.WriteLine(String.Format("Konvertiert aus einem String: {0}", dtReadUtcNow));

            DateTimeOffset dtReadNow = dtReadUtcNow.ToLocalTime();

            Console.WriteLine(String.Format("Lokale Zeit, konvertiert: {0}", dtReadNow.ToString()));

            
            Console.Write("Drücke <enter> um die Anwendung zu beenden");
            Console.ReadLine();
        }
    }
}

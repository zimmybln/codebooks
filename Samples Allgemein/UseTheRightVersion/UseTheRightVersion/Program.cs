using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseTheRightVersion.Components;

namespace UseTheRightVersion
{
    class Program
    {
        static void Main(string[] args)
        {
            // Für die Klasse MyComponent liegt eine einzelne alternative Implementierung vor
            
            var component = Factory.Create<MyComponent>();

            Console.WriteLine($"Der Name ist: {component.GetName()}");


            // ToDo: Es gibt einen Verbund von Klassen, die aktualisiert werden?


            Console.Write("Drücke <enter> um die Anwendung zu beenden");
            Console.ReadLine();
        }
    }
}

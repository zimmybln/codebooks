using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MutableObject
{
    class Program
    {
        static void Main(string[] args)
        {
            // MutableClass mc = new MutableClass
            // mc.Value = new ObjectOrValue(10)
            // mc.Value = 10
            // mc.Value = new Func<int>(() => 30);
            // mc.Value = new Func<ObjectOrValue>(() => new ObjectOrValue(40))


            // Der Status einer StateMachine wird beschrieben durch
            // Status ist gesetzt, wenn ein bestimmter Zustand zutrifft
            // IsStateSet: a = 10
            // IsStateSet: a > 10 && a < 20


            // Der Status wird neu berechnet, wenn sich eine oder mehrere Eigenschaften geändert haben
            // statemachine.AddState("10", conditionexpression)

            
            ObjectOrValue item2 = new ObjectOrValue(20);

            ObjectOrValue item1 = 10;

            ObjectOrValue item3 = new Func<int>(() => 30);

            
            Console.WriteLine(item1.Value);
            Console.WriteLine(item2.Value);
            Console.WriteLine(item3);
            

            Console.Write("Drücke <enter>");
            Console.ReadLine();
        }
    }
}

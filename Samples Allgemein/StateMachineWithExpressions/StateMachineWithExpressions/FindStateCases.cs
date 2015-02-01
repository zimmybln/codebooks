using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace StateMachineWithExpressions
{
    [TestFixture]
    public class FindStateCases
    {
        [Test]
        public void InvokeStateChangeByTrigger()
        {
            /*
             *      Ein Guard ist ein Mechanismus, der eine bestimmte Eigenschaft überprüft und bei deren
             *      Änderung das Finden eines neuen Status auslöst.
             *      
             *      Variante 1: Das Finden des Status wird ausgelöst, durch die Änderung einer Eigenschaft
             *      
             *      var machine = new StateMachine...
             *      
             *      machine.Data.Add("name", referenz)
             *      
             *      Wenn Referenz vom Typ INotifyPropertyChanged ist, werden deren Änderungen überwacht 
             *      
             *      machine.Guards.Add("name", "name der Eigenschaft")
             *      
             *      -> Problem hierbei ist, dass sich der Name überschneiden kann
             * 
             *      Variante 2: Das Finden wird intern ausgel
             * 
             * 
             */

            var data = new MyDataWithNotifier();

            var machine = new StateMachine<ItemStates>(ItemStates.Zero)
                .WithTriggers("i");
            
            machine.Data.Add("MyData", data);

            machine.AddStateDescriptor(ItemStates.Between10And19)
                .WithEnterCondition(sm => ((IMyData)sm.Data["MyData"]).i >= 10)
                .WithEnterCondition(sm => ((IMyData)sm.Data["MyData"]).i <= 19);
            
            data.i = 10;

            Assert.IsTrue(machine.Current == ItemStates.Between10And19, "Es wurde nicht der erwartete Status geliefert");

        }

        [Test]
        public void InvokeStateChangeByTriggerWithDelay()
        {
            var data = new MyDataWithNotifier();

            var machine = new StateMachine<ItemStates>(ItemStates.Zero)
                .WithTriggers("i");

            machine.Data.Add("MyData", data);

            machine.AddStateDescriptor(ItemStates.Between10And19)
                .WithEnterCondition(sm => ((IMyData)sm.Data["MyData"]).i >= 10)
                .WithEnterCondition(sm => ((IMyData)sm.Data["MyData"]).i <= 19);
            
            using (var defer = machine.DeferRefresh())
            {
                data.i = 10;    

                Assert.IsTrue(machine.Current == ItemStates.Zero, "Der Status wurde schon gewechselt");
            }
            
            Assert.IsTrue(machine.Current == ItemStates.Between10And19, "Es wurde nicht der erwartete Status geliefert");
        }

    }
}

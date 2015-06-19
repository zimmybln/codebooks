using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using StateMachineWithExpressions.Exceptions;

namespace StateMachineWithExpressions
{
    [TestFixture]
    public class BaseTestsForStateMachine
    {
        /*
         *  Aufgaben der StateMachine:
         *  - Möglichkeit zum Überprüfen eines Zustandes
         *  - Ereignisse, wenn sich Eigenschaften ändern
         * 
         * 
         */
        
        
        [Test]
        public void CheckStateChangeWithData()
        {
            var data = new MyData();

            var machine = new StateMachine<ItemStates, MyData>(ItemStates.Zero);
            
            // Hinzufügen eines Status
            machine.States.Add(new StateDescriptorWithExpressions<ItemStates, MyData>(ItemStates.Between10And19)
                    .WithEnterCondition(d => d.i >= 10)
                    .WithEnterCondition(d => d.i <= 19));

            machine.States.Add(new StateDescriptorWithExpressions<ItemStates, MyData>(ItemStates.Between20And29)
                    .WithEnterCondition(d => d.i >= 20)
                    .WithEnterCondition(d => d.i <= 29));
            
            Assert.IsTrue(machine.Current == ItemStates.Zero, "Der Status hat nicht den erwarteten Wert");
            
            data.i = 15;

            Assert.IsTrue(machine.TryToEnterState(ItemStates.Between10And19, data) == InvalidStateChangeReasons.Ok, "Der Statuswechsel konnte nicht erfolgen");
            Assert.IsTrue(machine.Current == ItemStates.Between10And19, "Der Status hat nicht den erwarteten Wert");

            Assert.IsTrue(machine.TryToEnterState(ItemStates.Between20And29, data) == InvalidStateChangeReasons.DataDoesntMatch, "Der Statuswechsel konnte nicht erfolgen");
            Assert.IsTrue(machine.Current == ItemStates.Between10And19, "Der Status hat nicht den erwarteten Wert");
            
        }

        [Test]
        public void CheckStateChange()
        {
            //var machine = new StateMachine<ItemStates>(ItemStates.Between20And29);

            //machine.AddStateDescriptor(ItemStates.Between10And19)
            //    .WithPredecessorStates(ItemStates.Zero);

            //machine.AddStateDescriptor(ItemStates.Between20And29);
            
            //// Aktuellen Status sicherstellen
            //Assert.IsTrue(machine.Current == ItemStates.Between20And29, "Ungültiger Status");

            //// Wechsel von Zero in Between20And21 ist nicht erlaubt
            //Assert.IsFalse(machine.TryToEnterState(ItemStates.Between10And19) == InvalidStateChangeReasons.Ok,
            //    "Beim Wechsel in einen Status ist kein Fehler ausgelöst worden.");
        }

        [Test]
        public void CheckStateChangeWithEmptyStates()
        {
            //var machine = new StateMachine<ItemStates>(ItemStates.Between20And29);

            //Assert.IsTrue(machine.Current == ItemStates.Between20And29);
            //Assert.IsTrue(machine.TryToEnterState(ItemStates.Between10And19) == InvalidStateChangeReasons.Ok);
            //Assert.IsTrue(machine.Current == ItemStates.Between10And19);
        }

        [Test]
        public void CheckStateChangedEvent()
        {
            //bool changed = false;

            //var machine = new StateMachine<ItemStates>(ItemStates.Zero);
            //machine.StateChanged += delegate(object sender, StateMachine<ItemStates>.StateChangedArgs args)
            //{
            //    changed = true;
            //};

            //Assert.IsFalse(changed);

            //machine.EnterState(ItemStates.Between10And19);

            //Assert.IsTrue(changed);

            


        }

    }
}

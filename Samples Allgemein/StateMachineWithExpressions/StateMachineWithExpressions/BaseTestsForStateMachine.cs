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
        public void CheckState()
        {
            var data = new MyData();

            var machine = new StateMachine<ItemStates>(ItemStates.Zero);
            machine.Data.Add("MyData", data);
            
            // Hinzufügen eines Status
            var stateBetween10And19 = machine.AddStateDescriptor(ItemStates.Between10And19)
                .WithEnterCondition(sm => ((MyData)sm.Data["MyData"]).i >= 10)
                .WithEnterCondition(sm => ((MyData)sm.Data["MyData"]).i <= 19);

            data.i = 10;
            
            Assert.IsTrue(stateBetween10And19.IsState());

            data.i = 20;

            Assert.IsFalse(stateBetween10And19.IsState());
            
            data.i = 5;

            Assert.IsFalse(stateBetween10And19.IsState());
        }

        [Test]
        public void CheckStateChangeWithData()
        {
            var data = new MyData();

            var machine = new StateMachine<ItemStates>(ItemStates.Zero);
            machine.Data.Add("MyData", data);

            // Hinzufügen eines Status
            machine.AddStateDescriptor(ItemStates.Between10And19)
                .WithEnterCondition(sm => ((MyData)sm.Data["MyData"]).i >= 10)
                .WithEnterCondition(sm => ((MyData)sm.Data["MyData"]).i <= 19);

            machine.AddStateDescriptor(ItemStates.Between20And29)
                .WithEnterCondition(sm => ((MyData) sm.Data["MyData"]).i >= 20)
                .WithEnterCondition(sm => ((MyData) sm.Data["MyData"]).i <= 29);

            data.i = 15;

            Assert.IsTrue(machine.TryToEnterState(ItemStates.Between10And19) == InvalidStateChangeReasons.Ok, "Der Statuswechsel konnte nicht erfolgen");
            Assert.IsTrue(machine.Current == ItemStates.Between10And19, "Der Status hat nicht den erwarteten Wert");

            Assert.IsTrue(machine.TryToEnterState(ItemStates.Between20And29) == InvalidStateChangeReasons.DataDoesntMatch, "Der Statuswechsel konnte nicht erfolgen");
            Assert.IsTrue(machine.Current == ItemStates.Between10And19, "Der Status hat nicht den erwarteten Wert");
            
        }

        [Test]
        public void CheckStateChange()
        {
            var machine = new StateMachine<ItemStates>(ItemStates.Between20And29);

            machine.AddStateDescriptor(ItemStates.Between10And19)
                .WithPredecessorStates(ItemStates.Zero);

            machine.AddStateDescriptor(ItemStates.Between20And29);
            
            // Aktuellen Status sicherstellen
            Assert.IsTrue(machine.Current == ItemStates.Between20And29, "Ungültiger Status");

            // Wechsel von Zero in Between20And21 ist nicht erlaubt
            Assert.IsFalse(machine.TryToEnterState(ItemStates.Between10And19) == InvalidStateChangeReasons.Ok,
                "Beim Wechsel in einen Status ist kein Fehler ausgelöst worden.");
        }

        [Test]
        public void CheckStateChangeWithEmptyStates()
        {
            var machine = new StateMachine<ItemStates>(ItemStates.Between20And29);

            Assert.IsTrue(machine.Current == ItemStates.Between20And29);
            Assert.IsTrue(machine.TryToEnterState(ItemStates.Between10And19) == InvalidStateChangeReasons.Ok);
            Assert.IsTrue(machine.Current == ItemStates.Between10And19);
        }



    }
}

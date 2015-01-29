using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

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
        public void CheckStateChange()
        {
            var data = new MyData();

            var machine = new StateMachine<ItemStates>(ItemStates.Zero);
            machine.Data.Add("MyData", data);

            // Hinzufügen eines Status
            machine.AddStateDescriptor(ItemStates.Between10And19)
                .WithEnterCondition(sm => ((MyData)sm.Data["MyData"]).i >= 10)
                .WithEnterCondition(sm => ((MyData)sm.Data["MyData"]).i <= 19);

            machine.AddStateDescriptor(ItemStates.Between20And21)
                .WithEnterCondition(sm => ((MyData) sm.Data["MyData"]).i >= 20)
                .WithEnterCondition(sm => ((MyData) sm.Data["MyData"]).i <= 29);

            data.i = 15;

            Assert.IsTrue(machine.TryToEnterState(ItemStates.Between10And19), "Der Statuswechsel konnte nicht erfolgen");
            Assert.IsTrue(machine.Current == ItemStates.Between10And19, "Der Status hat nicht den erwarteten Wert");

            Assert.IsFalse(machine.TryToEnterState(ItemStates.Between20And21), "Der Statuswechsel konnte nicht erfolgen");
            Assert.IsTrue(machine.Current == ItemStates.Between10And19, "Der Status hat nicht den erwarteten Wert");
            
        }

    }
}

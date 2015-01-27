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
        public void IsExpressionTest()
        {
            var data = new MyData();

            var machine = new StateMachine<ItemStates>(ItemStates.Empty);
            machine.Data.Add("MyData", data);

            
            // Hinzufügen eines Status
            var stateEmpty = machine.AddStateDescriptor(ItemStates.Empty)
                .WithEnterCondition<MyData>(d => d.i == 10)
                .WithEnterCondition<MyData>(d => d.j == 25);

            // Hinzufügen einer automatisierten Statusänderung


            data.i = 10;
            data.j = 25;
            
            Assert.IsTrue(stateEmpty.IsState(data));

            data.j = 20;

            Assert.IsFalse(stateEmpty.IsState(data));
            
            data.i = 5;

            Assert.IsFalse(stateEmpty.IsState(data));
        }



    }
}

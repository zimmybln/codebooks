using System;
using System.Collections.Generic;
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

            var machine = new StateMachine<IMyData>(data);
            
            // Hinzufügen eines Status
            var state = machine.AddState("Erster Status")
                .WithCondition(myData => myData.i == 10)
                .WithCondition(myData => myData.j == 25);

            // Hinzufügen einer automatisierten Statusänderung


            // Das ist eine Änderung, die auf TORSTEN-Desktop durchgeführt wurde

            data.i = 10;
            data.j = 25;
            
            Assert.IsTrue(state.IsState());
            
            data.i = 5;
            data.j = 30;

            Assert.IsFalse(state.IsState());
        }



    }
}

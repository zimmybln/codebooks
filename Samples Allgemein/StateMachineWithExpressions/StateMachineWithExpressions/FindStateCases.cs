using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime;
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
            var data = new MyDataWithNotifier();

            var machine = new StateMachine<ItemStates>(ItemStates.Zero)
                .WithTriggers("i");
            
            machine.Data.Add("MyData", data);

            machine.AddStateDescriptor(ItemStates.Between10And19)
                .WithEnterCondition(sm => ((IMyData)sm.Data["MyData"]).i >= 10)
                .WithEnterCondition(sm => ((IMyData)sm.Data["MyData"]).i <= 19);
            
            data.i = 10;

            Assert.IsTrue(machine.Current == ItemStates.Between10And19, "Es wurde nicht der erwartete Status geliefert");

            data.i = 29;

            Assert.IsTrue(machine.Current == ItemStates.Zero, "Es wurde nicht der Ausgangszustand wiederhergestellt");

        }

        [Test]
        public void InvokeStateChangeByTriggerWithDelay()
        {
            bool eventTriggered = false;

            var data = new MyDataWithNotifier();

            var machine = new StateMachine<ItemStates>(ItemStates.Zero)
                .WithTriggers("i");

            machine.Data.Add("MyData", data);
            machine.StateChanged += delegate(object sender, StateMachine<ItemStates>.StateChangedArgs args)
            {
                eventTriggered = true;

                Assert.IsTrue(args.FormerState == ItemStates.Zero, "Nicht erwarteter Ausgangszustand");
                Assert.IsTrue(args.NewState == ItemStates.Between10And19, "Nicht erwarteter Zielstand");
                
            };

            machine.AddStateDescriptor(ItemStates.Between10And19)
                .WithEnterCondition(sm => ((IMyData)sm.Data["MyData"]).i >= 10)
                .WithEnterCondition(sm => ((IMyData)sm.Data["MyData"]).i <= 19);
            
            using (var defer = machine.DeferRefresh())
            {
                data.i = 10;    

                Assert.IsTrue(machine.Current == ItemStates.Zero, "Der Status wurde schon gewechselt");

                Assert.IsFalse(eventTriggered, "Das Ereignis wurde bereits ausgelöst");
            }
            
            Assert.IsTrue(eventTriggered, "Das Ereignis wurde noch nicht ausgelöst");
            Assert.IsTrue(machine.Current == ItemStates.Between10And19, "Es wurde nicht der erwartete Status geliefert");
        }

    }
}

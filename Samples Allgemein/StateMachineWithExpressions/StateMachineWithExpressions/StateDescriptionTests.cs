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
    public class StateDescriptionTests
    {
        [Test]
        public void AddAndVerifyState()
        {
            var state = new StateDescriptorWithData<ItemStates, IMyData>(ItemStates.Between10And19);

            var machine = new StateMachine<ItemStates, IMyData>(ItemStates.Zero);

            machine.States.Add(state);

            Assert.IsTrue(machine[ItemStates.Between10And19] != null, "Der Status konnte nicht gefunden werden");
        }

        [Test]
        public void AddDuplicateState()
        {
            // Ausgangszustand herstellen
            var machine = new StateMachine<ItemStates, IMyData>(ItemStates.Zero);

            machine.States.Add(new StateDescriptorWithData<ItemStates, IMyData>(ItemStates.Between10And19));

            // Doppelten Status definieren
            var state = new StateDescriptorWithData<ItemStates, IMyData>(ItemStates.Between10And19);

            Assert.Throws<DuplicateNameException>(() => machine.States.Add(state));
        }

        [Test]
        public void AddDuplicateStateWithMixedDescriptors()
        {
            // Ausgangszustand herstellen
            var machine = new StateMachine<ItemStates, IMyData>(ItemStates.Zero);

            machine.States.Add(new StateDescriptorWithData<ItemStates, IMyData>(ItemStates.Between10And19));

            // Doppelten Status definieren
            var state = new StateDescriptorWithExpressions<ItemStates, IMyData>(ItemStates.Between10And19);

            Assert.Throws<DuplicateNameException>(() => machine.States.Add(state));
            
        }

        [Test]
        public void CheckState()
        {
            var data = new MyData();

            // Hinzufügen eines Status
            var stateBetween10And19 = new StateDescriptorWithExpressions<ItemStates, MyData>(ItemStates.Between10And19)
                .WithEnterCondition(d => d.i >= 10)
                .WithEnterCondition(d => d.i <= 19);

            data.i = 10;

            Assert.IsTrue(stateBetween10And19.IsState(data));

            data.i = 20;

            Assert.IsFalse(stateBetween10And19.IsState(data));

            data.i = 5;

            Assert.IsFalse(stateBetween10And19.IsState(data));
        }
    }
}

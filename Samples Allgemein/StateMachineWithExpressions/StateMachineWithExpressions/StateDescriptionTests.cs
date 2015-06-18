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
        public void CreateSimpleTest()
        {
            var state = new StateDescriptorWithData<ItemStates, IMyData>(ItemStates.Between10And19);

            var machine = new StateMachine<ItemStates, IMyData>(ItemStates.Between10And19);

            machine.AddStateDescriptor(state);
        }

        [Test]
        public void AddDuplicateState()
        {
            // Ausgangszustand herstellen
            var machine = new StateMachine<ItemStates, IMyData>(ItemStates.Zero);

            machine.AddStateDescriptor(new StateDescriptorWithData<ItemStates, IMyData>(ItemStates.Between10And19));

            // Doppelten Status definieren
            var state = new StateDescriptorWithData<ItemStates, IMyData>(ItemStates.Between10And19);

            Assert.Throws<DuplicateNameException>(() => machine.AddStateDescriptor(state));

        }
    }
}

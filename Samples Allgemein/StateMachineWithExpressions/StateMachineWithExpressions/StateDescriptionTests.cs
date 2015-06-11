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
            var state = new StateDescriptor<ItemStates>(ItemStates.Between10And19);

            var machine = new StateMachine<ItemStates>(ItemStates.Between10And19);

            machine.AddStateDescriptor(state);
        }

        [Test]
        public void AddDuplicateState()
        {
            var machine = new StateMachine<ItemStates>(ItemStates.Zero);

            machine.AddStateDescriptor(ItemStates.Between10And19);

            var state = new StateDescriptor<ItemStates>(ItemStates.Between10And19);

            Assert.Throws<DuplicateNameException>(() => machine.AddStateDescriptor(state));

        }
    }
}

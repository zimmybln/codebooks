using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateMachineWithExpressions
{
    public class StateDescriptorWithExpressions<TState> : StateDescriptor<TState>
    {
        public StateDescriptorWithExpressions(TState state) : base(state)
        {
        }
    }
}

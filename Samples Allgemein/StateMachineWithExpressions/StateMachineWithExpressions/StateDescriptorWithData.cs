using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateMachineWithExpressions
{
    public class StateDescriptorWithData<TState, TData> : StateDescriptor<TState, TData>
    {

        public StateDescriptorWithData(TState state) : base(state)
        {
            
        }
    }
}

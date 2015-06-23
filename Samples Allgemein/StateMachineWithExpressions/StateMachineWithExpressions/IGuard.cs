using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateMachineWithExpressions
{
    public interface IGuard<TStates, TData>
    {
        void Initialize(StateMachine<TStates, TData> stateMachine, TData propertyHost);
    }

    public interface IStateMachine
    {
        bool FindState();
    }
}

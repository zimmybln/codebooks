using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateMachineWithExpressions
{
    public interface IGuard
    {
        void Initialize(IStateMachine hostMachine);
    }

    public interface IStateMachine
    {
        void FindState();
    }
}

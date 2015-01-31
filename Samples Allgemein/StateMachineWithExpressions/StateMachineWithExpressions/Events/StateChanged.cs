using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateMachineWithExpressions.Events
{

    public delegate void StateChangedHandler(object sender, EventArgs args);

    public class StateChangedArgs : EventArgs
    {

    }
}

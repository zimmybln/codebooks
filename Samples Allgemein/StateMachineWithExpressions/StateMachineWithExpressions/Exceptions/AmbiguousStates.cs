using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateMachineWithExpressions.Exceptions
{
    /// <summary>
    /// Diese Ausnahme signalisiert, dass ein mehrdeutiger Zustand vorliegt. Das ist dann der Fall,
    /// wenn mehr als ein Status gültig ist.
    /// </summary>
    public class AmbiguousStatesException : Exception
    {
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateMachineWithExpressions.Exceptions
{
    public enum InvalidStateChangeReasons
    {
        Ok = 0,

        InvalidPredecessor = 1,

        DataDoesntMatch = 2
    }
    
    public class InvalidStateChangeException : Exception
    {
        public InvalidStateChangeException(InvalidStateChangeReasons reason)
        {
            Reason = reason;
        }

        public InvalidStateChangeReasons Reason { get; private set; }
    }
}

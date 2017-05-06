using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MutableObject
{
    [DefaultProperty("Value")]
    public class ObjectOrValue
    {
        private readonly int _myvalue = 0;
        private readonly Func<int> _getmyvalueasint = null;
        private readonly Func<ObjectOrValue> _getmyvalueasobject = null;


        public ObjectOrValue(int value)
        {
            _myvalue = value;
        }

        private ObjectOrValue(Func<int> queryValue)
        {
            _getmyvalueasint  = queryValue;
        }

        private ObjectOrValue(Func<ObjectOrValue> queryValue)
        {
            _getmyvalueasobject = queryValue;
        }

        public static implicit operator ObjectOrValue(int value)
        {
            return new ObjectOrValue(value);
        }

        public static implicit operator ObjectOrValue(Func<int> queryValue)
        {
            return new ObjectOrValue(queryValue);
        }

        public static implicit operator ObjectOrValue(Func<ObjectOrValue> queryValue)
        {
            return new ObjectOrValue(queryValue);
        }
        
        
        public int Value
        {
            get
            {
                if (_getmyvalueasobject != null)

                if (_getmyvalueasint != null)
                {
                    return _getmyvalueasint();
                }

                return _myvalue;
            }
        }





    }
}

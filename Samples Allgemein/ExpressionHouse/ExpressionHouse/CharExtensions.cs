using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionHouse
{
    public static class CharExtensions
    {
        private static string[] _operators = new []
        {
            "+",
            "-",
            "/",
            "\\",
            "%"
        };

        public static bool IsOperator(this int item)
        {
            return _operators.FirstOrDefault(o => o.StartsWith(((char) item).ToString())) != null;
        }


    }
}

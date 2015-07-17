using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ExpressionHouse
{
    [TestFixture]
    public class StringToExpressionTests
    {

        [TestCase("4 + 5")]
        public void SimpleExpression(string expression)
        {
            var analyzer = new AnalyzeExpression();

            analyzer.FindExpression(expression);



        }


    }
}

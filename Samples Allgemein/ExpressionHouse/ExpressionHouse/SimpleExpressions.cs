using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ExpressionHouse
{
    [TestFixture]
    public class SimpleExpressions
    {

        [Test]
        public void ExecuteAnalyze()
        {
            var analyzer = new AnalyzeExpression();


            analyzer.Analyze(() => DateTime.Now.ToString());
            

        }



    }
}

using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
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



                                            // PropertyExpression
                                                // MethodCallExpression
            analyzer.Analyze(() => DateTime.Now.ToString());

            
            // Erstellen eines Zugriffs auf die Eigenschaft Now des Typs DateTime
            //  Ein Verweis auf diese Eigenschaft wird per Reflection ermittelt. Der erste Parameter
            //  der folgenden Methode ist null, da es sich um eine statische Eigenschaft handelt. Der
            //  Typ (DateTime) ist bereits im Rückgabewert der Methode GetProperty enthalten.
            var propertyNow = Expression.Property(null, typeof (DateTime).GetProperty("Now"));
            

            // Erstellen des Methodenaufrufes ToString an der Eigenschaft Now
            //  Die Methode wird wieder mit Reflection ermittelt, Ausgangspunkt ist der Ausdruck mit
            //  der Eigenschaft Now
            var methodCall = Expression.Call(propertyNow, 
                                typeof(DateTime).GetMethod("ToString", Type.EmptyTypes), 
                                null);

            // Erstellen eines Lambda-Ausdrucks aus dem Methodenaufruf
            var lambda = Expression.Lambda<Func<object>>(methodCall);

            // Kompilieren des Ausdrucks
            var compiled = lambda.Compile();

            // Und ausführen des kompilierten Ausdrucks
            Trace.WriteLine(compiled());
        }



    }
}

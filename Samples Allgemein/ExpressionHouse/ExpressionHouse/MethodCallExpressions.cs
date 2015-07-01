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

    /// <summary>
    /// In dieser Testklasse werden Methodenaufrufe erstellt.
    /// </summary>
    /// <remarks>
    /// Es wird unterschieden zwischen Methodenaufrufen mit Parametern und ohne Parametern. 
    /// Ausgangspunkte können folgende Konstellationen sein:
    /// - Aufruf einer Methode an einer statischen Eigenschaft (DateTime.Now.ToString())
    /// - Aufruf einer Methode an einem konstanten Wert ("Beispiel".ToLower())
    /// - Aufruf einer Methode an einem Parameter (Param1.ToUpper())    
    /// 
    /// </remarks>
    [TestFixture]
    public class MethodCallExpressions
    {

        [Test]
        public void CreateMethodCallForStaticProperty()
        {
            var analyzer = new AnalyzeExpression();


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

        [Test]
        public void CreateMethodCallForConstant()
        {
            var analyzer = new AnalyzeExpression();

            analyzer.Analyze(() => "Das ist ein Beispiel".ToLower());

            var constantValue = Expression.Constant("Das ist ein Beispiel");

            var methodToLower = Expression.Call(constantValue, typeof (String).GetMethod("ToLower", Type.EmptyTypes),
                null);

            var lambda = Expression.Lambda<Func<object>>(methodToLower);

            var compiled = lambda.Compile();

            Trace.WriteLine(compiled());
        }

        [TestCase("Berlin ist eine große Stadt")]
        [TestCase("Am Montag früh geht es los")]
        public void CreateMethodCallForVariable(string parameterValue)
        {
            var analyzer = new AnalyzeExpression();

            analyzer.Analyze(() => parameterValue.ToUpper());


            var parameterExpression = Expression.Parameter(typeof(String), "Param1");

            var methodToLower = Expression.Call(parameterExpression, typeof(String).GetMethod("ToUpper", Type.EmptyTypes));

            var lambda = Expression.Lambda<Func<string, object>>(methodToLower, parameterExpression);

            var compiled = lambda.Compile();

            Trace.WriteLine(compiled(parameterValue));
        }



    }
}

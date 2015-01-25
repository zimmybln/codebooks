using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace LambdaTest
{
    class Program
    {

        // http://www.codeproject.com/Articles/24255/Exploring-Lambda-Expression-in-C

        static void Main(string[] args)
        {
            //int i = Test1(() => 10);

            //Console.WriteLine(i.ToString());

            var t = new Test1();
            t.RunTest();

            Console.Write("Drücke <enter> um die Anwendung zu beenden.");
            Console.ReadLine();

        }

        static int Test1(Expression<Func<int>> expression)
        {
            var fn = expression.Compile();

            return fn() * 2;
        }
    }

    public class Test1
    {
        public void RunTest()
        {
            GetInfo(O => O.Equals("asdf"));
        }


        public string Name { get; set; }

        private void GetInfo(Expression<Action<object>> expression)
        {
            
        }



    }

}

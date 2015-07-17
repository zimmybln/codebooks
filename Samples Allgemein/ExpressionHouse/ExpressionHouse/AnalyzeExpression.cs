﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionHouse
{
    public class AnalyzeExpression
    {

        // https://msdn.microsoft.com/en-us/library/system.linq.expressions.expression%28v=vs.110%29.aspx


        public void Analyze(Expression<Func<object>> expression)
        {
            WriteLine("{0} / {1}: {2}", expression.Body.NodeType, expression.Body.Type.Name, expression.ToString());

            if (expression.Body.NodeType == ExpressionType.Call)
            {
                AnalyzeCall(expression.Body);
            }


            var compiled = expression.Compile();

            WriteLine("{0}", compiled()); 
        }


        public void Analyze(string expression)
        {

            var reader = new StringReader(expression);
            




        }

        private void AnalyzeCall(Expression callExpression)
        {
            var methodCallExpression = (MethodCallExpression) callExpression;

            if (methodCallExpression.Object != null)
            {
                var propertyExpression = methodCallExpression.Object as MemberExpression;


                WriteLine("\tObjekt: {0} : {1}", methodCallExpression.Object.NodeType, methodCallExpression.Object.GetType().Name);

                //if (propertyExpression != null)
                //{
                //    //
                //    WriteLine("\t{0}", propertyExpression.NodeType);
                //}
            }
            
            WriteLine("\t {0} {1} {2}", methodCallExpression.Object.NodeType, methodCallExpression.Type.Name, methodCallExpression.Method.Name);
        }


        public void FindExpression(string expression)
        {
            int nChar;
            var reader = new StringReader(expression);

            nChar = reader.Read();
            while (nChar > 0)
            {
                WriteLine(String.Format("{0}", (char)nChar));
                

                nChar = reader.Read();
            }
        }


        protected void WriteLine(string format, params object[] args)
        {
            Debug.WriteLine(String.Format(format, args));
        }
    }
}

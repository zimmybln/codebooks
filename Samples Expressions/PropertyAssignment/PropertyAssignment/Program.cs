using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PropertyAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            var f = new Foo();

            f.SetPropertyValue(c => c.TestValue, 5);

            Console.WriteLine(f.TestValue);

            f.RaisePropertyChanged(() => f.TestValue, 5);

            Console.WriteLine(f.TestValue);
            
            Console.Write("Drücke <enter> um die Anwendung zu beenden.");

            Console.ReadLine();

        }

        
    }

    public class Foo
    {
        public int TestValue { get; set; }
    }


    public static class AssignmentExtensions
    {
        public static void SetPropertyValue<T>(this T target, Expression<Func<T, object>> memberLamda, object value)
        {
            var memberSelectorExpression = memberLamda.Body as MemberExpression;
            if (memberSelectorExpression != null)
            {
                var property = memberSelectorExpression.Member as PropertyInfo;
                if (property != null)
                {
                    property.SetValue(target, value, null);
                }
            }
        }

        public static void RaisePropertyChanged<T, TProperty>(this T target, Expression<Func<TProperty>> exp, object value)
        {
            var body = (MemberExpression)exp.Body;
            var propertyInfo = (PropertyInfo)body.Member;

            if (propertyInfo != null)
            {
                propertyInfo.SetValue(target, value, null);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp; 
using Microsoft.CodeAnalysis.CSharp.Symbols;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;

namespace FirstAnalyzer
{
    // https://joshvarty.wordpress.com/2014/07/06/learn-roslyn-now-part-2-analyzing-syntax-trees-with-linq/
    // http://www.filipekberg.se/2011/10/20/using-roslyn-to-parse-c-code-files/


    class Program
    {
        static void Main(string[] args)
        {


            var code = @"
    public class MyClass
    {
        public void MyMethod()
        {
        }
    }";

            var tree = CSharpSyntaxTree.ParseText(code);

            var root = tree.GetRoot();

            var item = root.DescendantNodes().OfType<ClassDeclarationSyntax>().First();


            Console.WriteLine(item.Identifier.ToString());

            Console.Write("Please press <enter> to close the application");
            Console.ReadLine();
        }
    }
}

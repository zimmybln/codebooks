using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Symbols;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System.IO;

namespace AnalyzingUseCases
{

    [TestClass()]
    public class AnalyzeFile : TestBase
    {
        [TestMethod]
        public void FindAllClasses()
        {
            string code = LoadCodeFromSamples("SampleClasses");
            
            var tree = CSharpSyntaxTree.ParseText(code);

            var root = tree.GetRoot();

            var classes = root.DescendantNodes().OfType<ClassDeclarationSyntax>();

            foreach(ClassDeclarationSyntax classDeclaration in classes)
            {
                Debug.WriteLine(classDeclaration.Identifier.ToString());

                // Auflisten der Eigenschaften
                foreach(var node in classDeclaration.Members.OfType<PropertyDeclarationSyntax>())
                {
                    Debug.WriteLine(node.Identifier.ToFullString());
                }

                foreach(var method in classDeclaration.Members.OfType<MethodDeclarationSyntax>())
                {
                    Debug.Write($"Methode: {method.Identifier.ToFullString()}(");

                    foreach(var parameter in method.ParameterList.Parameters)
                    {
                        Debug.Write(parameter.Identifier.ToFullString() + " ");
                    }

                    Debug.WriteLine(")");
                }
                
            }

        }

        [TestMethod]
        public void FindAllEnumerations()
        {
            string code = LoadCodeFromSamples("SampleClasses");

            var tree = CSharpSyntaxTree.ParseText(code);

            var root = tree.GetRoot();

            foreach(EnumDeclarationSyntax enumDeclaration in root.DescendantNodes().OfType<EnumDeclarationSyntax>())
            {
                Debug.WriteLine(enumDeclaration.Identifier.ToString());
            }
        }

    }

}

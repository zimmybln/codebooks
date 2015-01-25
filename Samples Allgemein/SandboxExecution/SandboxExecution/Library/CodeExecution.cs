using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows;
using Microsoft.CSharp;

namespace SandboxExecution.Library
{

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// http://msdn.microsoft.com/de-de/library/saf5ce06%28v=VS.100%29.aspx
    /// http://msdn.microsoft.com/en-us/library/ms173139%28v=VS.100%29.aspx
    /// </remarks>
    public class CodeExecution
    {


        public void ExecuteCode(string CodeToExecute)
        {

            var loCompiler = new CSharpCodeProvider();

            CompilerParameters loParameters = new CompilerParameters();

            var app = AppDomain.CreateDomain("Executer");

            app.DomainManager.





//            // *** Start by adding any referenced assemblies

//            loParameters.ReferencedAssemblies.Add("System.dll");

//            loParameters.ReferencedAssemblies.Add("System.Windows.Forms.dll");



//            // *** Must create a fully functional assembly as a string

//            CodeToExecute = @"using System;
//
//using System.IO;
//
//using System.Windows.Forms;
//
// 
//
//namespace MyNamespace {
//
//public class MyClass {
//
// 
//
//public object DynamicCode(params object[] Parameters) {
//
//" + CodeToExecute +

//         "}   }    }";



//            // *** Load the resulting assembly into memory

//            loParameters.GenerateInMemory = false;



//            // *** Now compile the whole thing

//            CompilerResults loCompiled =

//                    loCompiler.CompileAssemblyFromSource(loParameters, CodeToExecute);



//            if (loCompiled.Errors.HasErrors)
//            {

//                string lcErrorMsg = "";



//                lcErrorMsg = loCompiled.Errors.Count.ToString() + " Errors:";

//                for (int x = 0; x < loCompiled.Errors.Count; x++)

//                    lcErrorMsg = lcErrorMsg + "\r\nLine: " +

//                                 loCompiled.Errors[x].Line.ToString() + " - " +

//                                 loCompiled.Errors[x].ErrorText;



//                MessageBox.Show(lcErrorMsg + "\r\n\r\n" + CodeToExecute,

//                                "Compiler Demo");

//                return;

//            }

//            Assembly loAssembly = loCompiled.CompiledAssembly;


//            // Erstellen der neuen Anwendungsdomäne
//            AppDomain appDomainExecuting = AppDomain.CreateDomain("SampleExecuting");

//            appDomainExecuting.DefineDynamicAssembly()



//            // *** Retrieve an obj ref – generic type only

//            object loObject = loAssembly.CreateInstance("MyNamespace.MyClass");

//            if (loObject == null)
//            {

//                MessageBox.Show("Couldn't load class.");

//                return;

//            }



//            object[] loCodeParms = new object[1];

//            loCodeParms[0] = "West Wind Technologies";



//            try
//            {

//                object loResult = loObject.GetType().InvokeMember(

//                                 "DynamicCode", BindingFlags.InvokeMethod,

//                                 null, loObject, loCodeParms);



//                DateTime ltNow = (DateTime)loResult;

//                MessageBox.Show("Method Call Result:\r\n\r\n" +

//                                loResult.ToString(), "Compiler Demo");

//            }

//            catch (Exception loError)
//            {

//                MessageBox.Show(loError.Message, "Compiler Demo");
//            }
        }



    }
}

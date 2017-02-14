using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClassLibrary1
{

    [TestClass]
    public class Class1
    {

        [TestMethod]
        public void DoSomething()
        {
            var i = 1;

            i++;

            Assert.IsTrue(i == 2);
        }


        //[TestInitialize]
        //public void OnSetup()
        //{
        //    Debug.WriteLine(@"OnSetup");
        //}
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Various.DataTypes
{
    [TestFixture]
    public class TestDate
    {

        [Test]
        public void Test1()
        {
            DateTime dt = new DateTime(2000, 12, 18);

            DateTime dtResult = dt.AddDays(1);

            Debug.WriteLine("Das errechnete Datum ist: {0}", dtResult.ToString());

        }



    }
}

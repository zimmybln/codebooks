using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ObjectPooling
{
    // http://msdn.microsoft.com/en-us/library/ff458671(v=vs.110).aspx

    [TestFixture]
    public class PoolingTestClass
    {
        [Test]
        public void FirstTest()
        {
            var pool = new ObjectPool<MyClass>(() => new MyClass());
            
            Parallel.For(0, 1000, (i, loopState) =>
            {
                MyClass mc =  pool.GetObject();

                double dblValue = mc.GetValue(i);

                Debug.WriteLine(String.Format("{0}: {1}", i, dblValue));

                pool.PutObject(mc);
            });
           

            Debug.WriteLine(String.Format("Anzahl erstellter Objekte: {0}, {1}", MyClass.Number, pool.Number));
        }



    }
}

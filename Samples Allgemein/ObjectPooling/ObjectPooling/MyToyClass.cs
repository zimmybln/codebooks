using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ObjectPooling
{
    class MyClass : IDisposable
    {
        private static int _number;

        public int[] Nums { get; set; }

        public double GetValue(long i)
        {
            return Math.Sqrt(Nums[i]);
        }
        public MyClass()
        {
            Interlocked.Increment(ref _number);
            
            Nums = new int[1000000];
            Random rand = new Random();
            for (int i = 0; i < Nums.Length; i++)
                Nums[i] = rand.Next();
        }

        public static int Number
        {
            get { return _number; }
        }

        public void Dispose()
        {
            
        }
    } 
}

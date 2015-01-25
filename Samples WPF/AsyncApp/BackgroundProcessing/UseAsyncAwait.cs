using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncApp.BackgroundProcessing
{
    class UseAsyncAwait : IBackgroundProcessing
    {
        public async Task<int> ProcessAsync()
        {
            int nValue = 0;

            nValue = await Task.Run(() => Process());

            return nValue;
        }

        public int Process()
        {
            int number = 0;

            for (var i = 0; i < 10; i++)
                number += number;

            return number;
        }
    }
}

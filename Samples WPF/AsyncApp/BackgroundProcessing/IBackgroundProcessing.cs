using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncApp
{
    public interface IBackgroundProcessing
    {
        Task<int> ProcessAsync();
    }
}

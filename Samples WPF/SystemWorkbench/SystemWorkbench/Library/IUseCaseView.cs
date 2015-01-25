using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemWorkbench
{
    interface IUseCaseView
    {
        string Title { get; }

        object View { get; }
    }
}

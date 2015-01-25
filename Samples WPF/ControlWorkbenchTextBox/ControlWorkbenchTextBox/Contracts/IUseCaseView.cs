using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlWorkbenchTextBox
{
    public interface IUseCaseView
    {
        string Title { get; }

        string Description { get; }

        object View { get; }
    }
}

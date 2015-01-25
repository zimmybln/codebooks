using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControlWorkbenchTabControl
{
    interface IUseCaseView
    {
        string Title { get; }

        object View { get; }
    }
}

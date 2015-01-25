using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControlWorkbenchPopup
{
    interface IUseCaseView
    {
        string Title { get; }

        object View { get; }
    }
}

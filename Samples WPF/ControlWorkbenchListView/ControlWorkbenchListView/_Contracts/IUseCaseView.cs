using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControlWorkbenchListView
{
    interface IUseCaseView
    {
        string Title { get; }

        string Description { get; }

        object View { get; }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControlWorkbenchListBox
{
    interface IUseCaseView
    {
        string Title { get; }

        object View { get; }
    }


}

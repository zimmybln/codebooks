using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFArchitectureModel.Library.Behaviors;

namespace ControlWorkbenchButton.Contracts
{

    public interface IMainWindowModel
    {
        ObservableCollection<IApplicationItemFactory> Modules { get; }

        IApplicationItemFactory SelectedModule { get; set; }

        ObservableCollection<string> Messages { get; }

        LoadedAdapter LoadedAdapter { get; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFArchitectureModel.Library.Services;

namespace ControlWorkbenchButton.Contracts
{
    public interface IViewSelectorNotification : INotification
    {

    }

    public interface IViewSelectorNotificationService : INotificationService<IViewSelectorNotification>
    {

    }
}

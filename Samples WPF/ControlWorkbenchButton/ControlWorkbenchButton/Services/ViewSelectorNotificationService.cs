using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlWorkbenchButton.Contracts;
using WPFArchitectureModel.Library.Services;

namespace ControlWorkbenchButton.Services
{
    public class ViewSelectorNotificationBase : IViewSelectorNotification
    {

    }

    /// <summary>
    /// Diese Benachrichtigung informiert darüber, dass ein Modul angezeigt worden ist.
    /// </summary>
    public class ModuleShowedNotification : ViewSelectorNotificationBase
    {
        public ModuleShowedNotification(string Name)
        {
            ModuleName = Name;
        }

        public string ModuleName { get; private set; }
    }

    /// <summary>
    /// Diese Benachrichtigung informiert darüber, dass ein Modul verborgen wurde.
    /// </summary>
    public class ModuleHiddenNotification : ViewSelectorNotificationBase
    {
        public ModuleHiddenNotification(string Name)
        {
            ModuleName = Name;
        }

        public string ModuleName { get; private set; }
    }

    [Export(typeof(IViewSelectorNotificationService))]
    public class ViewSelectorNotificationService : NotificationService<IViewSelectorNotification>, IViewSelectorNotificationService
    {

    }
}

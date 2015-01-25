// Type: System.Waf.Applications.Controller
// Assembly: WpfApplicationFramework, Version=1.0.0.90, Culture=neutral
// Assembly location: D:\Dokumente\Mesh\Mehp\Codebooks\Samples Allgemein\ImageExplorer\Lib\WpfApplicationFramework.dll

using System.Collections.Specialized;
using System.ComponentModel;

namespace System.Waf.Applications
{
    public abstract class Controller
    {
        protected void AddWeakEventListener(INotifyPropertyChanged source, PropertyChangedEventHandler handler);
        protected void RemoveWeakEventListener(INotifyPropertyChanged source, PropertyChangedEventHandler handler);
        protected void AddWeakEventListener(INotifyCollectionChanged source, NotifyCollectionChangedEventHandler handler);

        protected void RemoveWeakEventListener(INotifyCollectionChanged source,
                                               NotifyCollectionChangedEventHandler handler);
    }
}

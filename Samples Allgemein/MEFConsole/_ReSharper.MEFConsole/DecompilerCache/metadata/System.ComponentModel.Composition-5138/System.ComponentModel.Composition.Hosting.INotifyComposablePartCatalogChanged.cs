// Type: System.ComponentModel.Composition.Hosting.INotifyComposablePartCatalogChanged
// Assembly: System.ComponentModel.Composition, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// Assembly location: C:\Programme\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.0\System.ComponentModel.Composition.dll

using System;

namespace System.ComponentModel.Composition.Hosting
{
    public interface INotifyComposablePartCatalogChanged
    {
        event EventHandler<ComposablePartCatalogChangeEventArgs> Changed;
        event EventHandler<ComposablePartCatalogChangeEventArgs> Changing;
    }
}

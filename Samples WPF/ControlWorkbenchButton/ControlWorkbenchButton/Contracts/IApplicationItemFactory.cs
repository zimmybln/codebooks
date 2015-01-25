using System.ComponentModel.Composition;
using System.Windows.Media;

namespace ControlWorkbenchButton.Contracts
{
    [InheritedExport]
    public interface IApplicationItemFactory
    {
        string Name { get; }

        ImageSource Image { get; }

        object Item { get; }
    }
}

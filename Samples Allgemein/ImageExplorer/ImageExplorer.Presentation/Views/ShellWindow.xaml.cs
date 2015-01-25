using System.ComponentModel.Composition;
using System.Windows;
using ImageExplorer.Base;

namespace ImageExplorer.Presentation.Views
{
    /// <summary>
    /// Interaction logic for ShellWindow.xaml
    /// </summary>
    [Export(typeof(IShellView))]
    public partial class ShellWindow : Window, IShellView
    {
        public ShellWindow()
        {
            InitializeComponent();
        }

    }
}

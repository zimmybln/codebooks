using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ControlWorkbenchTextBox.Pages
{
    /// <summary>
    /// Interaktionslogik für GhostStyle.xaml
    /// </summary>
    [Export(typeof(IUseCaseView))]
    public partial class GhostStyle : Page, IUseCaseView
    {
        public GhostStyle()
        {
            InitializeComponent();
        }


        public string Description
        {
            get { return "Ein Text mit einem verborgenen Text"; }
        }

        public object View
        {
            get { return this; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace SystemWorkbench.UseCases
{
    /// <summary>
    /// Interaktionslogik für ShowFont.xaml
    /// </summary>
    [Export(typeof(IUseCaseView))]
    public partial class ShowFont : Page, IUseCaseView
    {
        public ShowFont()
        {
            InitializeComponent();

            Symbols = new ObservableCollection<SymbolInfo>();

            for (int i = 33; i <= 248; i++ )
                Symbols.Add(new SymbolInfo() { Value = ((char)i).ToString(), FontFamily = "Wingdings", CharIndex = i});
            
            this.DataContext = this;
        }


        public ObservableCollection<SymbolInfo> Symbols { get; private set; }



        public object View
        {
            get { return this; }
        }
    }

    public class SymbolInfo
    {
        public string Value { get; set; }

        public string FontFamily { get; set; }

        public int CharIndex { get; set; }
    }
}

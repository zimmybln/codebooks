using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CommandSample
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private int mv_nCallCounter = 0;
        
        public Window1()
        {
            InitializeComponent();
        }

        public DateTime ParameterValue
        {
            get { return DateTime.Now; }
        }

        private void OnExecuteSimpleCommand(object sender, ExecutedRoutedEventArgs e)
        {
            string strResult = null;
            
            if (e.Parameter != null)
            {
                strResult = String.Format("{0} ({1})", e.Parameter.ToString(), e.Parameter.GetType().Name);

                if (e.Parameter is MyTestClass)
                    strResult += "[testobject]";
            }
            else
                strResult = "es wurde kein Parameter übergeben";

            if (!String.IsNullOrEmpty(strResult))
            {
                mv_nCallCounter++;
                int nIndex = lstCommandResults.Items.Add(String.Format("{0:00}: {1}", mv_nCallCounter, strResult));
                lstCommandResults.SelectedIndex = nIndex;
            }
        }
    }
}

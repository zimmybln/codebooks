using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WPFArchitectureModel.Library;

namespace ControlWorkbenchButton
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            ApplicationServices.BeginRegister();
            ApplicationServices.RegisterModule(this.GetType().Assembly);
            ApplicationServices.EndRegister();

            ApplicationServices.Regions.RegisterRegion("MainContent", true);

            this.MainWindow = new MainWindow();
            MainWindow.Show();
        }
    }
}

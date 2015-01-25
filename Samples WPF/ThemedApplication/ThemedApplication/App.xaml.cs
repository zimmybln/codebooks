using System;
using System.Reflection;
using System.Windows;

namespace ThemedApplication
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            
            ApplyDesign("Blue.xaml");
        }

        public void ApplyDefaultDesign()
        {
            AssemblyName amsName = new AssemblyName(this.GetType().Assembly.FullName);

            // Bereinigen der Ressourcen
            Resources.MergedDictionaries.Clear();

            ResourceDictionary rdColors = new ResourceDictionary();
            rdColors.Source = new Uri(String.Format("/{0};component/Resources/DefaultColor.xaml", amsName.Name), UriKind.RelativeOrAbsolute);

            ResourceDictionary rdStyles = new ResourceDictionary();
            rdStyles.Source = new Uri(String.Format("/{0};component/Resources/Styles.xaml", amsName.Name), UriKind.RelativeOrAbsolute);

            Resources.MergedDictionaries.Add(rdColors);
            Resources.MergedDictionaries.Add(rdStyles);
        }

        public void ApplyDesign(string Theme)
        {
            if (String.IsNullOrEmpty(Theme))
                return;

            AssemblyName amsName = new AssemblyName(this.GetType().Assembly.FullName);

            Uri uriPath = new Uri(this.GetType().Assembly.CodeBase);
            string strPath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(uriPath.LocalPath), "Themes");

            strPath += String.Format("\\{0}", Theme);

            // Bereinigen der Ressourcen
            Resources.MergedDictionaries.Clear();

            ResourceDictionary rdColors = new ResourceDictionary();
            rdColors.Source = new Uri(strPath);

            ResourceDictionary rdStyles = new ResourceDictionary();
            rdStyles.Source = new Uri(String.Format("/{0};component/Resources/Styles.xaml", amsName.Name), UriKind.RelativeOrAbsolute);

            Resources.MergedDictionaries.Add(rdColors);
            Resources.MergedDictionaries.Add(rdStyles);
        }


    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CustomControlLibrary
{
    /// <summary>
    /// Führen Sie die Schritte 1a oder 1b und anschließend Schritt 2 aus, um dieses benutzerdefinierte Steuerelement in einer XAML-Datei zu verwenden.
    ///
    /// Schritt 1a) Verwenden des benutzerdefinierten Steuerelements in einer XAML-Datei, die im aktuellen Projekt vorhanden ist.
    /// Fügen Sie dieses XmlNamespace-Attribut dem Stammelement der Markupdatei 
    /// an der Stelle hinzu, an der es verwendet werden soll:
    ///
    ///     xmlns:MyNamespace="clr-namespace:CustomControlLibrary"
    ///
    ///
    /// Schritt 1b) Verwenden des benutzerdefinierten Steuerelements in einer XAML-Datei, die in einem anderen Projekt vorhanden ist.
    /// Fügen Sie dieses XmlNamespace-Attribut dem Stammelement der Markupdatei 
    /// an der Stelle hinzu, an der es verwendet werden soll:
    ///
    ///     xmlns:MyNamespace="clr-namespace:CustomControlLibrary;assembly=CustomControlLibrary"
    ///
    /// Darüber hinaus müssen Sie von dem Projekt, das die XAML-Datei enthält, einen Projektverweis
    /// zu diesem Projekt hinzufügen und das Projekt neu erstellen, um Kompilierungsfehler zu vermeiden:
    ///
    ///     Klicken Sie im Projektmappen-Explorer mit der rechten Maustaste auf das Zielprojekt und anschließend auf
    ///     "Verweis hinzufügen"->"Projekte"->[Dieses Projekt auswählen]
    ///
    ///
    /// Schritt 2)
    /// Fahren Sie fort, und verwenden Sie das Steuerelement in der XAML-Datei.
    ///
    ///     <MyNamespace:CustomControl1/>
    ///
    /// </summary>
    [TemplatePart(Name = "PART_ExecuteButton", Type = typeof(Button))]
    public class ExtendedItemList : Control
    {
        public static readonly DependencyProperty DescriptionProperty = DependencyProperty.Register("Description",
                                                                                              typeof (string),
                                                                                              typeof (ExtendedItemList),
                                                                                              new PropertyMetadata("Standardwert"));

        // http://www.codeproject.com/KB/WPF/CustomListBoxLayoutInWPF.aspx

        static ExtendedItemList()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ExtendedItemList), new FrameworkPropertyMetadata(typeof(ExtendedItemList)));
            
            EventManager.RegisterClassHandler(typeof (ExtendedItemList), ButtonBase.ClickEvent,
                                              new RoutedEventHandler(OnButtonClick));
        }

        public string Description
        {
            get { return (string) this.GetValue(DescriptionProperty); }
            set { this.SetValue(DescriptionProperty, value);}
        }

        private static void OnButtonClick(object sender, RoutedEventArgs e)
        {
            var btt = e.OriginalSource as Button;

            if (btt != null)
            {
                string strButtonName = btt.Name;

                Trace.WriteLine(String.Format("Der Button wurde geklickt: {0}", strButtonName));
            }
        }

        private void OnButtonClickByTemplate(object sender, RoutedEventArgs e)
        {
            Trace.WriteLine("Click auch über das Template angekommen");
        }

        private static void OnMouseDown(object sender, RoutedEventArgs e)
        {
            var obj = e.OriginalSource as DependencyObject;

            Trace.WriteLine(String.Format("Statische Methode OnMouseDown"));
        }

        protected override void OnPreviewMouseDown(MouseButtonEventArgs e)
        {
            Trace.WriteLine(String.Format("Methode OnMouseDown"));

            base.OnPreviewMouseDown(e);
        }

        protected override void OnMouseDoubleClick(MouseButtonEventArgs e)
        {
            base.OnMouseDoubleClick(e);

            Debug.WriteLine("Doppelcklick");
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            Button btt = base.GetTemplateChild("PART_ExecuteButton") as Button;

            if (btt != null)
                btt.Click += new RoutedEventHandler(OnButtonClickByTemplate);

        }
    }

    public class ExtendedItem
    {
        
    }

}

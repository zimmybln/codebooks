﻿#pragma checksum "..\..\Window1.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "D0157EE37A640DE2375C400FE3A25283"
//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.235
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

using ControlsWorkbench;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace ControlsWorkbench {
    
    
    /// <summary>
    /// Window1
    /// </summary>
    public partial class Window1 : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 172 "..\..\Window1.xaml"
        internal System.Windows.Controls.Grid grdTest;
        
        #line default
        #line hidden
        
        
        #line 173 "..\..\Window1.xaml"
        internal System.Windows.Controls.ListBox lstControls;
        
        #line default
        #line hidden
        
        
        #line 175 "..\..\Window1.xaml"
        internal System.Windows.Controls.ListBoxItem lbiButton;
        
        #line default
        #line hidden
        
        
        #line 176 "..\..\Window1.xaml"
        internal System.Windows.Controls.ListBoxItem lbiComboBox;
        
        #line default
        #line hidden
        
        
        #line 177 "..\..\Window1.xaml"
        internal System.Windows.Controls.ListBoxItem lbiTextBox;
        
        #line default
        #line hidden
        
        
        #line 178 "..\..\Window1.xaml"
        internal System.Windows.Controls.ListBoxItem lbiCheckBox;
        
        #line default
        #line hidden
        
        
        #line 179 "..\..\Window1.xaml"
        internal System.Windows.Controls.ListBoxItem lbiListBox;
        
        #line default
        #line hidden
        
        
        #line 180 "..\..\Window1.xaml"
        internal System.Windows.Controls.ListBoxItem lbiPopup;
        
        #line default
        #line hidden
        
        
        #line 181 "..\..\Window1.xaml"
        internal System.Windows.Controls.ListBoxItem lbiStatusBar;
        
        #line default
        #line hidden
        
        
        #line 182 "..\..\Window1.xaml"
        internal System.Windows.Controls.ListBoxItem lbiResources;
        
        #line default
        #line hidden
        
        
        #line 183 "..\..\Window1.xaml"
        internal System.Windows.Controls.ListBoxItem lbiDrawing1;
        
        #line default
        #line hidden
        
        
        #line 184 "..\..\Window1.xaml"
        internal System.Windows.Controls.ListBoxItem lbiRatingControl;
        
        #line default
        #line hidden
        
        
        #line 188 "..\..\Window1.xaml"
        internal System.Windows.Controls.TextBlock tbStatusInfo;
        
        #line default
        #line hidden
        
        
        #line 193 "..\..\Window1.xaml"
        internal System.Windows.Controls.Frame frmControls;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ControlsWorkbench;component/window1.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Window1.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 7 "..\..\Window1.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.OnSetStatusText);
            
            #line default
            #line hidden
            return;
            case 2:
            this.grdTest = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.lstControls = ((System.Windows.Controls.ListBox)(target));
            
            #line 173 "..\..\Window1.xaml"
            this.lstControls.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.OnSelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.lbiButton = ((System.Windows.Controls.ListBoxItem)(target));
            return;
            case 5:
            this.lbiComboBox = ((System.Windows.Controls.ListBoxItem)(target));
            return;
            case 6:
            this.lbiTextBox = ((System.Windows.Controls.ListBoxItem)(target));
            return;
            case 7:
            this.lbiCheckBox = ((System.Windows.Controls.ListBoxItem)(target));
            return;
            case 8:
            this.lbiListBox = ((System.Windows.Controls.ListBoxItem)(target));
            return;
            case 9:
            this.lbiPopup = ((System.Windows.Controls.ListBoxItem)(target));
            return;
            case 10:
            this.lbiStatusBar = ((System.Windows.Controls.ListBoxItem)(target));
            return;
            case 11:
            this.lbiResources = ((System.Windows.Controls.ListBoxItem)(target));
            return;
            case 12:
            this.lbiDrawing1 = ((System.Windows.Controls.ListBoxItem)(target));
            return;
            case 13:
            this.lbiRatingControl = ((System.Windows.Controls.ListBoxItem)(target));
            return;
            case 14:
            this.tbStatusInfo = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 15:
            this.frmControls = ((System.Windows.Controls.Frame)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}


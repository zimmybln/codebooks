﻿#pragma checksum "D:\Dokumente\GitHub\codebooks\codebooks\Samples UWP\DataAccessWithEFSqlite\DataAccessWithEFSqlite\Pages\ShowDataPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "210F0C606FEBE63CCC759ED5B156840E"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccessWithEFSqlite.Pages
{
    partial class ShowDataPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    this.ShowPersons = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 20 "..\..\..\Pages\ShowDataPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.ShowPersons).Click += this.ShowPersons_OnClick;
                    #line default
                }
                break;
            case 2:
                {
                    this.lstPersons = (global::Windows.UI.Xaml.Controls.GridView)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}


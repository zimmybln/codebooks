using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace UseCase_02_Dialog.ViaConstructor
{
    /// <summary>
    /// Die Codebehind Klasse exportiert den Typen
    /// </summary>
    [Export(typeof(IInputDialogView))]
    public partial class InputDialogViaConstructor : Window, IInputDialogView
    {
        public InputDialogViaConstructor()
        {
            InitializeComponent();
        }
    }
}

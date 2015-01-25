using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace UseCase_02_Dialog.ViaComposition
{

    /// <summary>
    /// Ein Model für einen einfachen Eingabedialog.
    /// </summary>
    public class InputDialogViaCompositionModel : DialogViaCompositionModelBase
    {
        private string mv_strInputValue;

        public string InputValue
        {
            get { return mv_strInputValue; }
            set
            {
                if (String.Compare(mv_strInputValue, value) != 0)
                {
                    mv_strInputValue = value;
                    RaisePropertyChanged("InputValue");
                }
            }
        }

        /// <summary>
        /// Überprüfung der Gültigkeit der Werte
        /// </summary>
        protected override bool ArePropertiesValid()
        {
            if (String.IsNullOrEmpty(this.InputValue))
                return false;

            return base.ArePropertiesValid();
        }
    }
}

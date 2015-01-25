using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;

namespace UseCase_02_Dialog.ViaConstructor
{
    [Export(typeof(UseCase_02_Dialog.ViaConstructor.InputDialogViaConstructorModel))]
    public class InputDialogViaConstructorModel : DialogViaConstructorModelBase
    {
        private string mv_strInputValue;

        [ImportingConstructor()]
        public InputDialogViaConstructorModel(IInputDialogView View)
            : base(View)
        {
            
        }

        public string InputValue
        {
            get { return mv_strInputValue; }    
            set
            {
                if (String.Compare(mv_strInputValue, value) == 0) return;

                mv_strInputValue = value;
                RaisePropertyChanged("InputValue");
            }
        }

    }
}

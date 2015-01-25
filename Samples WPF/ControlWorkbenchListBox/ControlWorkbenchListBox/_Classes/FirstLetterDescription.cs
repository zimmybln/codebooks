using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace ControlWorkbenchListBox
{
    public class FirstLetterDescription : PropertyGroupDescription 
    {
        public override object GroupNameFromItem(object item, int level, System.Globalization.CultureInfo culture)
        {
            return item is Person
                       ? ((Person) item).FirstName.Substring(0, 1)
                       : base.GroupNameFromItem(item, level, culture);
        }
    }
}

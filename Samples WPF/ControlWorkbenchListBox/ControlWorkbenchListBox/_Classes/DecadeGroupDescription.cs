using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace ControlWorkbenchListBox
{
    public class DecadeGroupDescription : PropertyGroupDescription
    {
        public DecadeGroupDescription()
        {
            
        }

        public override object GroupNameFromItem(object item, int level, System.Globalization.CultureInfo culture)
        {
            if (item is Person)
            {
                uint nAge = ((Person) item).Age;

                uint nDecade = (nAge - (nAge%10));

                return String.Format("Unbekannt {0}", nDecade);
            }
            
            return base.GroupNameFromItem(item, level, culture);
        }

    }
}

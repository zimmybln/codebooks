using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UseCase_02_Dialog.ViaConstructor
{
    /// <summary>
    /// Diese Schnittstelle definiert die Eigenschaften und Methoden,
    /// die für die Kommunikation zwischen Model und View notwendig
    /// sind.
    /// </summary>
    public interface IView
    {
        object DataContext { get; set; }

        bool? ShowDialog();

        bool? DialogResult { get; set; }
    }
}

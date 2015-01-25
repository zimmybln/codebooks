using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControlWorkbenchRichTextBox
{
    public interface ISavingDocumentStrategy
    {
        void Started(int NumberOfPages);

        void FinishedWithError(Exception ex);

        void Finished();

        void Cancelled();

        void Changed(int PagesWriten, int ProgressPercentage);

    }
}

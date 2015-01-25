using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageExplorer.Base
{

    public delegate void Message(string Message);

    public interface IMessageService
    {
        event Message OnMessage;

        void ShowMessage(string Message);
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Waf.Applications;

namespace ImageExplorer.Base
{
    public interface IShellView : IView
    {
        void Show();

        void Close();
    }
}
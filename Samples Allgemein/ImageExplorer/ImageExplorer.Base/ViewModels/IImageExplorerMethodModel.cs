using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageExplorer.Base
{
    public interface IImageExplorerMethodModel
    {
        string[] SelectedFiles { get; set; }
    }
}

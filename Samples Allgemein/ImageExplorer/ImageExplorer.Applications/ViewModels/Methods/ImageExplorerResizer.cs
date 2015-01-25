using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Waf.Applications;
using ImageExplorer.Base;

namespace ImageExplorer.Applications
{
    [Export(typeof(IImageExplorerMethodModel))]
    public class ImageExplorerResizer : ViewModel<IImageMethodeResizerView>, IImageExplorerMethodModel
    {
        private string[] mv_arrSelectedFiles;
        private int mv_nCount = 0;

        [ImportingConstructor]
        public ImageExplorerResizer(IImageMethodeResizerView view) : base(view)
        {

        }

        public string Name
        {
            get { return "Größe anpassen"; }
        }

        public string[] SelectedFiles
        {
            get { return mv_arrSelectedFiles; }
            set
            {
                if (mv_arrSelectedFiles != value)
                {
                    mv_arrSelectedFiles = value;
                    mv_nCount = mv_arrSelectedFiles != null ? mv_arrSelectedFiles.Length : 0;

                    RaisePropertyChanged("SelectedFiles");
                    RaisePropertyChanged("Count");
                }
            }
        }

        public int Count
        {
            get { return mv_nCount; }
        }
    }
}

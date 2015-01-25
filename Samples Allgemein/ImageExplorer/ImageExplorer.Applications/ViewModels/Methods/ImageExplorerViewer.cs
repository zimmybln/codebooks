using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Waf.Applications;
using ImageExplorer.Base;

namespace ImageExplorer.Applications
{
    [Export(typeof(IImageExplorerMethodModel))]
    public class ImageExplorerViewer : ViewModel<IImageMethodViewerView>, IImageExplorerMethodModel
    {
        private string[] mv_arrSelectedFiles;


        [ImportingConstructor]
        public ImageExplorerViewer(IImageMethodViewerView view)
            : base(view)
        {

        }

        public string Name
        {
            get { return "Ansicht"; }
        }

        public string[] SelectedFiles
        {
            get
            {
                List<string> lstFiles = new List<string>();

                if (mv_arrSelectedFiles != null)
                {
                    foreach(string strFile in mv_arrSelectedFiles)
                        lstFiles.Add(System.IO.Path.GetFileName(strFile));
                }

                return lstFiles.ToArray();
            }
            set
            {
                if (mv_arrSelectedFiles != value)
                {
                    mv_arrSelectedFiles = value;
                    RaisePropertyChanged("SelectedFiles");
                }
            }
        }
    }
}

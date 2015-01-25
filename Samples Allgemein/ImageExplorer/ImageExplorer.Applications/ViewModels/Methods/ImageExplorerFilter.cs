using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Waf.Applications;
using ImageExplorer.Base;

namespace ImageExplorer.Applications
{
    [Export(typeof(IImageExplorerMethodModel)), Export()]
    public class ImageExplorerFilterModel : ViewModel<IImageMethodFilterView>, IImageExplorerMethodModel
    {

        private DateTime mv_dtDateFrom;
        private int? mv_nSize;

        [ImportingConstructor]
        public ImageExplorerFilterModel(IImageMethodFilterView view) : base(view)
        {
            mv_dtDateFrom = new DateTime(1999, 10, 19);
            mv_nSize = 1000;
        }
        
        public string Name
        {
            get { return "Filter"; }
        }

        public string[] SelectedFiles
        {
            get { return null; }
            set { }
        }

        public DateTime DateFrom
        {
            get { return mv_dtDateFrom; }
            set
            {
                if (mv_dtDateFrom != value)
                {
                    mv_dtDateFrom = value;
                    RaisePropertyChanged("DateFrom");
                }
            }
        }

        public int? Size
        {
            get { return mv_nSize; }
            set
            {
                if (mv_nSize != value)
                {
                    mv_nSize = value;
                    RaisePropertyChanged("Size");
                }
            }
        }
    }
}

using System.Windows;
using System.Windows.Controls;

namespace ControlWorkbenchListView
{
    public class TileView : ViewBase
    {
        private DataTemplate mv_tplItemTemplate;

        public DataTemplate ItemTemplate
        {
            get { return mv_tplItemTemplate; }
            set { mv_tplItemTemplate = value; }
        }

        protected override object DefaultStyleKey
        {
            get
            {
                return new ComponentResourceKey(GetType(), "TileView");
            }
        }

        protected override object ItemContainerDefaultStyleKey
        {
            get { return new ComponentResourceKey(GetType(), "TileViewItem"); }
        }
    }
}
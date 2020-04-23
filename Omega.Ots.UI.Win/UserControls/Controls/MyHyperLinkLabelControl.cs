using DevExpress.XtraEditors;
using Omega.Ots.UI.Win.Interfaces;
using System.ComponentModel;
using System.Windows.Forms;

namespace Omega.Ots.UI.Win.UserControls.Controls
{
    [ToolboxItem(true)]
    public class MyHyperLinkLabelControl : HyperlinkLabelControl, IStatusBarAciklama
    {
        public MyHyperLinkLabelControl()
        {
            Cursor = Cursors.Hand;
            LinkBehavior = LinkBehavior.NeverUnderline;
        }

        public string StatusBarAciklama { get; set; }
    }
}
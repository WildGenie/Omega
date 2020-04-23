using DevExpress.XtraEditors;
using Omega.Ots.UI.Win.Interfaces;
using System.Drawing;
using System.ComponentModel;

namespace Omega.Ots.UI.Win.UserControls.Controls
{
    [ToolboxItem(true)]
    class MySimpleButton : SimpleButton, IStatusBarAciklama
    {
        public MySimpleButton()
        {
            Appearance.ForeColor = Color.Maroon;
        }

        public string StatusBarAciklama { get; set; }
    }
}
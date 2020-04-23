using DevExpress.XtraEditors;
using Omega.Ots.UI.Yonetim.Interfaces;
using System.ComponentModel;
using System.Drawing;

namespace Omega.Ots.UI.Yonetim.UserControls.Controls
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
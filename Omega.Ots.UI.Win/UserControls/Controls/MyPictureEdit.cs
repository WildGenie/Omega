using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Omega.Ots.UI.Win.Interfaces;
using System.Drawing;
using System.ComponentModel;

namespace Omega.Ots.UI.Win.UserControls.Controls
{
    [ToolboxItem(true)]
    public class MyPictureEdit : PictureEdit, IStatusBarKisayol
    {
        public MyPictureEdit()
        {
            Properties.Appearance.BackColor = Color.LightCyan;
            Properties.Appearance.ForeColor = Color.Maroon;
            Properties.NullText = "Resim Yok";
            Properties.SizeMode = PictureSizeMode.Stretch;
            Properties.ShowMenu = false;
        }
        public override bool EnterMoveNextControl { get; set; } = true;

        public string StatusBarAciklama { get; set; }

        public string StatusBarKisayol { get; set; } = "F4 :";

        public string StatusBarKisayolAciklama { get; set; }
    }
}
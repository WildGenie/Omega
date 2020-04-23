using Omega.Ots.UI.Yonetim.Interfaces;
using DevExpress.XtraEditors;
using System.ComponentModel;

namespace Omega.Ots.UI.Yonetim.UserControls.Controls
{
    [ToolboxItem(true)]
    public class MyFilterControl : FilterControl, IStatusBarAciklama
    {
        public MyFilterControl()
        {
            //Grupladığımızda icon çıkması için
            ShowGroupCommandsIcon = true;
        }

        public string StatusBarAciklama { get; set; } = "Filtre metni giriniz";
    }
}

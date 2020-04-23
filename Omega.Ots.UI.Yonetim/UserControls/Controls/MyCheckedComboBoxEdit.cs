﻿using Omega.Ots.UI.Yonetim.Interfaces;
using DevExpress.XtraEditors;
using System.Drawing;
using System.ComponentModel;

namespace Omega.Ots.UI.Yonetim.UserControls.Controls
{
    [ToolboxItem(true)]
    public class MyCheckedComboBoxEdit : CheckedComboBoxEdit, IStatusBarKisayol
    {
        public MyCheckedComboBoxEdit()
        {
            Properties.AppearanceFocused.BackColor = Color.LightCyan;
        }
        public override bool EnterMoveNextControl { get; set; } = true;

        public string StatusBarAciklama { get; set; }

        public string StatusBarKisayol { get; set; } = "F4 :";

        public string StatusBarKisayolAciklama { get; set; }
    }
}

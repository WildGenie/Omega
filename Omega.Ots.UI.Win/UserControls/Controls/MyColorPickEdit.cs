﻿using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Omega.Ots.UI.Win.Interfaces;
using System.ComponentModel;
using System.Drawing;

namespace Omega.Ots.UI.Win.UserControls.Controls
{
    [ToolboxItem(true)]
    public class MyColorPickEdit : ColorPickEdit, IStatusBarKisayol
    {
        public MyColorPickEdit()
        {
            Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            Properties.AppearanceFocused.BackColor = Color.LightCyan;
        }

        public override bool EnterMoveNextControl { get; set; }
        public string StatusBarKisayol { get; set; }
        public string StatusBarKisayolAciklama { get; set; }
        public string StatusBarAciklama { get; set; }
    }
}
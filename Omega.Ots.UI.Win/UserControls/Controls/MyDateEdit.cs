﻿using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Mask;
using Omega.Ots.UI.Win.Interfaces;
using System.Drawing;
using System.ComponentModel;

namespace Omega.Ots.UI.Win.UserControls.Controls
{
    [ToolboxItem(true)]
    public class MyDateEdit : DateEdit, IStatusBarKisayol
    {
        public MyDateEdit()
        {
            Properties.AppearanceFocused.BackColor = Color.LightCyan;
            //Tarih alanı null geçilmeyek
            Properties.AllowNullInput = DefaultBoolean.False;
            Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
            //Tarih yazıldıkça gün -ay -yıl kısmına otomatik geçiş yapılmasını sağlar
            Properties.Mask.MaskType = MaskType.DateTimeAdvancingCaret;
        }
        public override bool EnterMoveNextControl { get; set; } = true;

        public string StatusBarAciklama { get; set; }

        public string StatusBarKisayol { get; set; } = "F4 :";

        public string StatusBarKisayolAciklama { get; set; } = "Tarih Seç";
    }
}
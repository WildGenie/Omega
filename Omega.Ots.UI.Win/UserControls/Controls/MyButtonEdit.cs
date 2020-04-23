﻿using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Omega.Ots.UI.Win.Interfaces;
using System.Drawing;
using System;
using System.ComponentModel;

namespace Omega.Ots.UI.Win.UserControls.Controls
{
    [ToolboxItem(true)]
    public class MyButtonEdit : ButtonEdit, IStatusBarKisayol
    {
        public MyButtonEdit()
        {
            Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            Properties.AppearanceFocused.BackColor = Color.LightCyan;
        }
        public override bool EnterMoveNextControl { get; set; } = true;
        public string StatusBarAciklama { get; set; }
        public string StatusBarKisayol { get; set; } = "F4 :";
        public string StatusBarKisayolAciklama { get; set; }

        #region Event

        private long? _id;
        //Derlendikten sonra property listesinde göstermez.
        [Browsable(false)]
        public long? Id
        {
            get { return _id; }
            set
            {
                var oldValue = _id;
                var newValue = value;
                if (newValue.HasValue && oldValue.HasValue && newValue == oldValue)
                {
                    return;
                }
                _id = value;

                IdChanged?.Invoke(this, new IdChangedEventArgs(oldValue, newValue));
                EnabledChange(this, EventArgs.Empty);
            }
        }

        public event EventHandler<IdChangedEventArgs> IdChanged = delegate { };
        public event EventHandler EnabledChange = delegate { };
        #endregion

    }

    public class IdChangedEventArgs : EventArgs
    {
        public IdChangedEventArgs(long? oldValue, long? newValue)
        {
            OldValue = oldValue;
            NewValue = newValue;
        }
        public long? OldValue { get; }
        public long? NewValue { get; }
    }
}
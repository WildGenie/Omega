﻿using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using Omega.Ots.Bll.General;
using Omega.Ots.Common.Enums;
using Omega.Ots.Model.Dto;
using Omega.Ots.Model.Entities;
using Omega.Ots.UI.Win.Forms.BaseForms;
using Omega.Ots.UI.Win.Functions;
using System;

namespace Omega.Ots.UI.Win.GeneralForms
{
    public partial class KurumBilgileriEditForm : BaseEditForm
    {
        #region Variables
        private readonly string _kod;
        private readonly string _kurumAdi;
        #endregion
        public KurumBilgileriEditForm(params object[] prm)
        {
            InitializeComponent();

            dataLayoutControl = myDataLayoutControl;
            Bll = new KurumBilgileriBll(myDataLayoutControl);
            HideItems = new BarItem[] { btnYeni, btnSil };
            EventsLoad();

            _kod = prm[0].ToString();
            _kurumAdi = prm[1].ToString();
        }

        protected internal override void Yukle()
        {
            oldEntity = ((KurumBilgileriBll)Bll).Single(null) ?? new KurumBilgileriS();
            BaseIslemTuru = oldEntity.Id == 0 ? IslemTuru.EntityInsert : IslemTuru.EntityUpdate;

            NesneyiKontrollereBagla();
            if (BaseIslemTuru != IslemTuru.EntityInsert) return;
            Id = BaseIslemTuru.IdOlustur(oldEntity);
            txtKod.Text = _kod;
            txtKurumAdi.Text = _kurumAdi;
            txtKurumAdi.Focus();
        }
        
        protected override void NesneyiKontrollereBagla()
        {
            var entity = (KurumBilgileriS)oldEntity;
            Id = entity.Id;

            txtKod.Text = entity.Kod;
            txtKurumAdi.Text = entity.KurumAdi;
            txtVergiDairesi.Text = entity.VergiDairesi;
            txtVergiNo.Text = entity.VergiNo;
            txtIl.Id = entity.IlId;
            txtIl.Text = entity.IlAdi;
            txtIlce.Id = entity.IlceId;
            txtIlce.Text = entity.IlceAdi;

        }

        protected override void GuncelNesneOlustur()
        {
            currentEntity = new KurumBilgileri
            {
                Id = Id,
                Kod = txtKod.Text,
                KurumAdi = txtKurumAdi.Text,
                VergiDairesi = txtVergiDairesi.Text,
                VergiNo = txtVergiNo.Text,
                IlId = Convert.ToInt64(txtIl.Id),
                IlceId = Convert.ToInt64(txtIlce.Id)
            };

            ButonEnabledDurumu();
        }

        protected override void SecimYap(object sender)
        {
            if (!(sender is ButtonEdit)) return;
            using (var sec = new SelectFunctions())
            {
                if (sender == txtIl)
                    sec.Sec(txtIl);
                else if (sender == txtIlce)
                    sec.Sec(txtIlce, txtIl);
            }
        }

        protected override void Control_EnabledChange(object sender, EventArgs e)
        {
            if (sender != txtIl) return;
            txtIl.ControlEnabledChange(txtIlce);
        }
    }
}
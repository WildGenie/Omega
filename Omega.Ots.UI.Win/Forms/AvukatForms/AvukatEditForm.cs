﻿using DevExpress.XtraEditors;
using Omega.Ots.Bll.General;
using Omega.Ots.Common.Enums;
using Omega.Ots.Model.Dto;
using Omega.Ots.Model.Entities;
using Omega.Ots.UI.Win.Forms.BaseForms;
using Omega.Ots.UI.Win.Functions;
using System;

namespace Omega.Ots.UI.Win.Forms.AvukatForms
{
    public partial class AvukatEditForm : BaseEditForm
    {

        public AvukatEditForm()
        {
            InitializeComponent();

            Bll = new AvukatBll(myDataLayoutControl);
            dataLayoutControl = myDataLayoutControl;
            kartTuru = KartTuru.Avukat;
            EventsLoad();
        }

        protected internal override void Yukle()
        {
            oldEntity = BaseIslemTuru == IslemTuru.EntityInsert ? new AvukatS() : ((AvukatBll)Bll).Single(FilterFunctions.Filter<Avukat>(Id));
            NesneyiKontrollereBagla();

            if (BaseIslemTuru != IslemTuru.EntityInsert) return;
            Id = BaseIslemTuru.IdOlustur(oldEntity);
            txtKod.Text = ((AvukatBll)Bll).YeniKodVer();
            txtAdiSoyadi.Focus();
        }
        protected override void NesneyiKontrollereBagla()
        {
            var entity = (AvukatS)oldEntity;

            txtKod.Text = entity.Kod;
            txtAdiSoyadi.Text = entity.AdiSoyadi;
            txtSozlesmeNo.Text = entity.SozlesmeNo;
            txtBaslamaTarihi.EditValue = entity.SozlesmeBaslamaTarihi;
            txtBitisTarihi.EditValue = entity.SozlesmeBitisTarihi;
            txtOzelKod1.Id = entity.OzelKod1Id;
            txtOzelKod1.Text = entity.OzelKod1Adi;
            txtOzelKod2.Id = entity.OzelKod2Id;
            txtOzelKod2.Text = entity.OzelKod2Adi;
            txtAciklama.Text = entity.Aciklama;
            tglDurum.IsOn = entity.Durum;
        }
        protected override void GuncelNesneOlustur()
        {
            currentEntity = new Avukat
            {
                Id = Id,
                Kod = txtKod.Text,
                AdiSoyadi = txtAdiSoyadi.Text,
                SozlesmeNo = txtSozlesmeNo.Text,
                SozlesmeBaslamaTarihi = (DateTime?)txtBaslamaTarihi.EditValue,
                SozlesmeBitisTarihi = (DateTime?)txtBitisTarihi.EditValue,
                OzelKod1Id = txtOzelKod1.Id,
                OzelKod2Id = txtOzelKod2.Id,
                Aciklama = txtAciklama.Text,
                Durum = tglDurum.IsOn
            };
            ButonEnabledDurumu();
        }
        protected override void SecimYap(object sender)
        {
            if (!(sender is ButtonEdit)) return;

            using (var sec = new SelectFunctions())
                if (sender == txtOzelKod1)
                    sec.Sec(txtOzelKod1, KartTuru.Avukat);
                else if (sender == txtOzelKod2)
                    sec.Sec(txtOzelKod2, KartTuru.Avukat);
        }
    }
}
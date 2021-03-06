﻿using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using Omega.Ots.Bll.General;
using Omega.Ots.Common.Enums;
using Omega.Ots.Model.Dto;
using Omega.Ots.Model.Entities;
using Omega.Ots.Model.Entities.Base.Interfaces;
using Omega.Ots.UI.Win.Forms.BaseForms;
using Omega.Ots.UI.Win.Functions;
using Omega.Ots.UI.Win.UserControls.Controls;
using System;
using System.Drawing;

namespace Omega.Ots.UI.Win.GeneralForms
{
    public partial class KullaniciParametreEditForm : BaseEditForm
    {
        private readonly long _kullaniciId;

        public KullaniciParametreEditForm(params object[] prm)
        {
            InitializeComponent();

            _kullaniciId = (long)prm[0];
            dataLayoutControl = myDataLayoutControl;
            Bll = new KullaniciParametreBll();
            HideItems = new BarItem[] { btnYeni, btnSil };
            EventsLoad();
          }

        protected internal override void Yukle()
        {
            oldEntity = ((KullaniciParametreBll)Bll).Single(x => x.KullaniciId == _kullaniciId) ?? new KullaniciParametreS();
            BaseIslemTuru = oldEntity.Id == 0 ? IslemTuru.EntityInsert : IslemTuru.EntityUpdate;
            NesneyiKontrollereBagla();
            if (BaseIslemTuru != IslemTuru.EntityInsert) return;
            Id = BaseIslemTuru.IdOlustur(oldEntity);
         
        }

        protected override void NesneyiKontrollereBagla()
        {
            var entity = (KullaniciParametreS)oldEntity;
            Id = entity.Id;
            txtDefaultAvukatHesap.Id = entity.DefaultAvukatHesapId;
            txtDefaultAvukatHesap.Text = entity.DefaultAvukatHesapAdi;
            txtDefaultBankaHesap.Id = entity.DefaultBankaHesapId;
            txtDefaultBankaHesap.Text = entity.DefaultBankaHesapAdi;
            txtDefaultKasaHesap.Id = entity.DefaultKasaHesapId;
            txtDefaultKasaHesap.Text = entity.DefaultKasaHesapAdi;
            txtRaporlariOnayAlmadanKapat.Checked = entity.RaporlariOnayAlmadanKapat;
            txtTableViewCaptionForeColor.Color = Color.FromArgb(entity.TableViewCaptionForeColor);
            txtTableColumnHeaderForeColor.Color = Color.FromArgb(entity.TableColumnHeaderForeColor);
            txtTableBandPanelForeColor.Color = Color.FromArgb(entity.TableBandPanelForeColor);
            imgArkaPlanResim.EditValue = entity.ArkaPlanResim;
        }

        protected override void GuncelNesneOlustur()
        {
            currentEntity = new KullaniciParametre
            {
                Id = Id,
                Kod = "Param-001",
                KullaniciId = AnaForm.KullaniciId,
                DefaultAvukatHesapId = txtDefaultAvukatHesap.Id,
                DefaultBankaHesapId = txtDefaultBankaHesap.Id,
                DefaultKasaHesapId = txtDefaultKasaHesap.Id,
                RaporlariOnayAlmadanKapat = txtRaporlariOnayAlmadanKapat.Checked,
                TableViewCaptionForeColor = txtTableViewCaptionForeColor.Color.ToArgb(),
                TableColumnHeaderForeColor = txtTableColumnHeaderForeColor.Color.ToArgb(),
                TableBandPanelForeColor = txtTableBandPanelForeColor.Color.ToArgb(),
                ArkaPlanResim = (byte[])imgArkaPlanResim.EditValue,
            };

            ButonEnabledDurumu();
        }

        protected internal override IBaseEntity ReturnEntity()
        {
            var entity = new KullaniciParametreS()
            {
                DefaultAvukatHesapId = txtDefaultAvukatHesap.Id,
                DefaultAvukatHesapAdi = txtDefaultAvukatHesap.Text,
                DefaultBankaHesapId = txtDefaultBankaHesap.Id,
                DefaultBankaHesapAdi = txtDefaultBankaHesap.Text,
                DefaultKasaHesapId = txtDefaultKasaHesap.Id,
                DefaultKasaHesapAdi = txtDefaultKasaHesap.Text,
                RaporlariOnayAlmadanKapat = txtRaporlariOnayAlmadanKapat.Checked,
                TableViewCaptionForeColor = txtTableViewCaptionForeColor.Color.ToArgb(),
                TableColumnHeaderForeColor = txtTableColumnHeaderForeColor.Color.ToArgb(),
                TableBandPanelForeColor = txtTableBandPanelForeColor.ForeColor.ToArgb(),
                ArkaPlanResim = (byte[])imgArkaPlanResim.EditValue
            };

            return entity;
        }

        protected override bool EntityInsert()
        {
            var result = base.EntityInsert();
            if (!result) return false;
            ReturnEntity();
            return true;
        }

        protected override bool EntityUpdate()
        {
            var result = base.EntityUpdate();
            if (!result) return false;
            ReturnEntity();
            return true;
        }

        protected override void Control_Enter(object sender, EventArgs e)
        {
            if (!(sender is MyPictureEdit resim)) return;
            resim.Sec(resimMenu);
        }

        protected override void SecimYap(object sender)
        {
            if (!(sender is ButtonEdit)) return;

            using (var sec = new SelectFunctions())
                if (sender == txtDefaultAvukatHesap)
                    sec.Sec(txtDefaultAvukatHesap);
                else if (sender == txtDefaultBankaHesap)
                    sec.Sec(txtDefaultBankaHesap);
                else if (sender == txtDefaultKasaHesap)
                    sec.Sec(txtDefaultKasaHesap);
        }
    }
}
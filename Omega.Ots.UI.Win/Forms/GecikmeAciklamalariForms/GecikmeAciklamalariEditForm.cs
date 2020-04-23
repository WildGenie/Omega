using Omega.Ots.Bll.General;
using Omega.Ots.Common.Enums;
using Omega.Ots.Model.Dto;
using Omega.Ots.Model.Entities;
using Omega.Ots.UI.Win.Forms.BaseForms;
using Omega.Ots.UI.Win.Functions;
using Omega.Ots.UI.Win.GeneralForms;
using System;

namespace Omega.Ots.UI.Win.Forms.GecikmeAciklamalariForms
{
    public partial class GecikmeAciklamalariEditForm : BaseEditForm
    {
        #region Variables
        private readonly int _portfoyNo;
        #endregion

        public GecikmeAciklamalariEditForm(params object[] prm)
        {
            InitializeComponent();

            _portfoyNo = (int)prm[0];

            dataLayoutControl = myDataLayoutControl;
            Bll = new GecikmeAciklamalariBll(myDataLayoutControl);
            kartTuru = KartTuru.Aciklama;
            EventsLoad();
        }

        protected internal override void Yukle()
        {
            oldEntity = BaseIslemTuru == IslemTuru.EntityInsert ? new GecikmeAciklamalariS() : ((GecikmeAciklamalariBll)Bll).Single(FilterFunctions.Filter<GecikmeAciklamalari>(Id));
            NesneyiKontrollereBagla();

            if (BaseIslemTuru != IslemTuru.EntityInsert) return;
            Id = BaseIslemTuru.IdOlustur(oldEntity);
            txtKod.Text = ((GecikmeAciklamalariBll)Bll).YeniKodVer(x => x.OdemeBilgileriId == _portfoyNo);
            txtAciklama.Focus();
        }
        protected override void NesneyiKontrollereBagla()
        {
            var entity = (GecikmeAciklamalariS)oldEntity;

            txtKod.Text = entity.Kod;
            txtKullaniciAdi.Text = BaseIslemTuru == IslemTuru.EntityInsert ? AnaForm.KullaniciAdi : entity.KullaniciAdi;
            txtTarihSaat.DateTime = BaseIslemTuru == IslemTuru.EntityInsert ? DateTime.Now : entity.TarihSaat;
            txtAciklama.Text = entity.Aciklama;
        }
        protected override void GuncelNesneOlustur()
        {
            currentEntity = new GecikmeAciklamalari
            {
                Id = Id,
                Kod = txtKod.Text,
                OdemeBilgileriId = _portfoyNo,
                KullaniciId = BaseIslemTuru == IslemTuru.EntityInsert ? AnaForm.KullaniciId : 0,
                TarihSaat = txtTarihSaat.DateTime,
                Aciklama = txtAciklama.Text,

            };
            ButonEnabledDurumu();
        }
        protected override bool EntityInsert()
        {
            return ((GecikmeAciklamalariBll)Bll).Insert(currentEntity, x => x.Kod == currentEntity.Kod && x.OdemeBilgileriId == _portfoyNo);
        }
        protected override bool EntityUpdate()
        {
            return ((GecikmeAciklamalariBll)Bll).Update(oldEntity, currentEntity, x => x.Kod == currentEntity.Kod && x.OdemeBilgileriId == _portfoyNo);
        }
    }
}
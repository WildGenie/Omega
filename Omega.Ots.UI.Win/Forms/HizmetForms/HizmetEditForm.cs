using DevExpress.XtraEditors;
using Omega.Ots.Bll.General;
using Omega.Ots.Common.Enums;
using Omega.Ots.Model.Dto;
using Omega.Ots.Model.Entities;
using Omega.Ots.UI.Win.Forms.BaseForms;
using Omega.Ots.UI.Win.Functions;
using Omega.Ots.UI.Win.GeneralForms;
using System;

namespace Omega.Ots.UI.Win.Forms.HizmetForms
{
    public partial class HizmetEditForm : BaseEditForm
    {
        public HizmetEditForm()
        {
            InitializeComponent();

            dataLayoutControl = myDataLayoutControl;
            Bll = new HizmetBll(myDataLayoutControl);
            kartTuru = KartTuru.Hizmet;
            EventsLoad();
        }

        protected internal override void Yukle()
        {
            oldEntity = BaseIslemTuru == IslemTuru.EntityInsert ? new HizmetS() : ((HizmetBll)Bll).Single(FilterFunctions.Filter<Hizmet>(Id));
            NesneyiKontrollereBagla();

            if (BaseIslemTuru != IslemTuru.EntityInsert) return;
            Id = BaseIslemTuru.IdOlustur(oldEntity);
            txtKod.Text = ((HizmetBll)Bll).YeniKodVer(x => x.SubeId == AnaForm.SubeId && x.DonemId == AnaForm.DonemId);
            txtBaslamaTarihi.DateTime = txtBaslamaTarihi.Properties.MinValue;
            txtBitisTarihi.DateTime = txtBitisTarihi.Properties.MaxValue;
            txtHizmetAdi.Focus();
        }
        protected override void NesneyiKontrollereBagla()
        {
            var entity = (HizmetS)oldEntity;

            txtKod.Text = entity.Kod;
            txtHizmetAdi.Text = entity.HizmetAdi;
            txtHizmetTuru.Id = entity.HizmetTuruId;
            txtHizmetTuru.Text = entity.HizmetTuruAdi;
            txtBaslamaTarihi.DateTime = entity.BaslamaTarihi;
            txtBitisTarihi.DateTime = entity.BitisTarihi;
            txtUcret.Value = entity.Ucret;
            txtAciklama.Text = entity.Aciklama;
            tglDurum.IsOn = entity.Durum;
        }
        protected override void GuncelNesneOlustur()
        {
            currentEntity = new Hizmet
            {
                Id = Id,
                Kod = txtKod.Text,
                HizmetAdi = txtHizmetAdi.Text,
                HizmetTuruId = Convert.ToInt64(txtHizmetTuru.Id),
                BaslamaTarihi = txtBaslamaTarihi.DateTime.Date,
                BitisTarihi = txtBitisTarihi.DateTime.Date,
                Ucret = txtUcret.Value,
                Aciklama = txtAciklama.Text,
                DonemId = AnaForm.DonemId,
                SubeId = AnaForm.SubeId,
                Durum = tglDurum.IsOn

            };
            ButonEnabledDurumu();
        }

        protected override bool EntityInsert()
        {
            return ((HizmetBll)Bll).Insert(currentEntity, x => x.Kod == currentEntity.Kod &&
             x.SubeId == AnaForm.SubeId && x.DonemId == AnaForm.DonemId);
        }
        protected override bool EntityUpdate()
        {
            return ((HizmetBll)Bll).Update(oldEntity, currentEntity, x => x.Kod == currentEntity.Kod &&
            x.SubeId == AnaForm.SubeId && x.DonemId == AnaForm.DonemId);
        }
        protected override void SecimYap(object sender)
        {
            if (!(sender is ButtonEdit)) return;

            using (var sec = new SelectFunctions())
                if (sender == txtHizmetTuru)
                    sec.Sec(txtHizmetTuru);
        }
        protected override void Control_EditValueChanged(object sender, EventArgs e)
        {
            base.Control_EditValueChanged(sender, e);

            txtBaslamaTarihi.Properties.MinValue = AnaForm.DonemParametreleri.EgitimBaslamaTarihi;
            txtBaslamaTarihi.Properties.MaxValue = AnaForm.DonemParametreleri.DonemBitisTarihi;
            txtBitisTarihi.Properties.MinValue = txtBaslamaTarihi.DateTime.Date;
            txtBitisTarihi.Properties.MaxValue = AnaForm.DonemParametreleri.DonemBitisTarihi;
        }
    }
}
using Omega.Ots.Bll.General;
using Omega.Ots.Common.Enums;
using Omega.Ots.Model.Entities;
using Omega.Ots.UI.Win.Forms.BaseForms;
using Omega.Ots.UI.Win.Functions;
using Omega.Ots.UI.Win.GeneralForms;

namespace Omega.Ots.UI.Win.Forms.ServisForms
{
    public partial class ServisEditForm : BaseEditForm
    {
        public ServisEditForm()
        {
            InitializeComponent();

            dataLayoutControl = myDataLayoutControl;
            Bll = new ServisBll(myDataLayoutControl);
            kartTuru = KartTuru.Servis;
            EventsLoad();
        }

        protected internal override void Yukle()
        {
            oldEntity = BaseIslemTuru == IslemTuru.EntityInsert ? new Servis() : ((ServisBll)Bll).Single(FilterFunctions.Filter<Servis>(Id));
            NesneyiKontrollereBagla();
            if (BaseIslemTuru != IslemTuru.EntityInsert) return;
            Id = BaseIslemTuru.IdOlustur(oldEntity);
            txtKod.Text = ((ServisBll)Bll).YeniKodVer(x => x.SubeId == AnaForm.SubeId && x.DonemId == AnaForm.DonemId);
            txtServisYeri.Focus();
        }

        protected override void NesneyiKontrollereBagla()
        {
            var entity = (Servis)oldEntity;

            txtKod.Text = entity.Kod;
            txtServisYeri.Text = entity.ServisYeri;
            txtUcret.Value = entity.Ucret;
            txtAciklama.Text = entity.Aciklama;
            tglDurum.IsOn = entity.Durum;
        }

        protected override void GuncelNesneOlustur()
        {
            currentEntity = new Servis
            {
                Id = Id,
                Kod = txtKod.Text,
                ServisYeri = txtServisYeri.Text,
                Aciklama = txtAciklama.Text,
                SubeId = AnaForm.SubeId,
                Ucret = txtUcret.Value,
                DonemId = AnaForm.DonemId,
                Durum = tglDurum.IsOn

            };
            ButonEnabledDurumu();
        }

        protected override bool EntityInsert()
        {
            return ((ServisBll)Bll).Insert(currentEntity, x => x.Kod == currentEntity.Kod &&
             x.SubeId == AnaForm.SubeId && x.DonemId == AnaForm.DonemId);
        }

        protected override bool EntityUpdate()
        {
            return ((ServisBll)Bll).Update(oldEntity, currentEntity, x => x.Kod == currentEntity.Kod &&
            x.SubeId == AnaForm.SubeId && x.DonemId == AnaForm.DonemId);
        }
    }
}
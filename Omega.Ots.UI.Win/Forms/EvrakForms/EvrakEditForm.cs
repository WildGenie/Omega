using Omega.Ots.Bll.General;
using Omega.Ots.Common.Enums;
using Omega.Ots.Model;
using Omega.Ots.UI.Win.Forms.BaseForms;
using Omega.Ots.UI.Win.Functions;
using Omega.Ots.UI.Win.GeneralForms;

namespace Omega.Ots.UI.Win.Forms.EvrakForms
{
    public partial class EvrakEditForm : BaseEditForm
    {
        public EvrakEditForm()
        {
            InitializeComponent();

            dataLayoutControl = myDataLayoutControl;
            Bll = new EvrakBll(myDataLayoutControl);
            kartTuru = KartTuru.Evrak;
            EventsLoad();
        }
        protected internal override void Yukle()
        {
            oldEntity = BaseIslemTuru == IslemTuru.EntityInsert ? new Evrak() : ((EvrakBll)Bll).Single(FilterFunctions.Filter<Evrak>(Id));
            NesneyiKontrollereBagla();
            if (BaseIslemTuru != IslemTuru.EntityInsert) return;
            Id = BaseIslemTuru.IdOlustur(oldEntity);
            txtKod.Text = ((EvrakBll)Bll).YeniKodVer(x => x.SubeId == AnaForm.SubeId && x.DonemId == AnaForm.DonemId);
            txtEvrakAdi.Focus();
        }
        protected override void NesneyiKontrollereBagla()
        {
            var entity = (Evrak)oldEntity;

            txtKod.Text = entity.Kod;
            txtEvrakAdi.Text = entity.EvrakAdi;
            txtAciklama.Text = entity.Aciklama;
            tglDurum.IsOn = entity.Durum;
        }
        protected override void GuncelNesneOlustur()
        {
            currentEntity = new Evrak
            {
                Id = Id,
                Kod = txtKod.Text,
                EvrakAdi = txtEvrakAdi.Text,
                Aciklama = txtAciklama.Text,
                SubeId = AnaForm.SubeId,
                DonemId = AnaForm.DonemId,
                Durum = tglDurum.IsOn

            };
            ButonEnabledDurumu();
        }
        protected override bool EntityInsert()
        {
            return ((EvrakBll)Bll).Insert(currentEntity, x => x.Kod == currentEntity.Kod &&
             x.SubeId == AnaForm.SubeId && x.DonemId == AnaForm.DonemId);
        }
        protected override bool EntityUpdate()
        {
            return ((EvrakBll)Bll).Update(oldEntity, currentEntity, x => x.Kod == currentEntity.Kod &&
            x.SubeId == AnaForm.SubeId && x.DonemId == AnaForm.DonemId);
        }
    }
}
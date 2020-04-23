
using Omega.Ots.Bll.General;
using Omega.Ots.Common.Enums;
using Omega.Ots.Model.Entities;
using Omega.Ots.UI.Win.Forms.BaseForms;
using Omega.Ots.UI.Win.Functions;

namespace Omega.Ots.UI.Win.Forms.SinifGrupForms
{
    public partial class SinifGrupEditForm : BaseEditForm
    {
        public SinifGrupEditForm()
        {
            InitializeComponent();

            dataLayoutControl = myDataLayoutControl;
            Bll = new SinifGrupBll(myDataLayoutControl);
            kartTuru = KartTuru.SinifGrup;
            EventsLoad();
        }

        protected internal override void Yukle()
        {
            oldEntity = BaseIslemTuru == IslemTuru.EntityInsert ? new SinifGrup() : ((SinifGrupBll)Bll).Single(FilterFunctions.Filter<SinifGrup>(Id));
            NesneyiKontrollereBagla();

            if (BaseIslemTuru != IslemTuru.EntityInsert) return;
            Id = BaseIslemTuru.IdOlustur(oldEntity);
            txtKod.Text = ((SinifGrupBll)Bll).YeniKodVer();
            txtGrupAdi.Focus();
        }
        protected override void NesneyiKontrollereBagla()
        {
            var entity = (SinifGrup)oldEntity;
            txtKod.Text = entity.Kod;
            txtGrupAdi.Text = entity.GrupAdi;
            txtAciklama.Text = entity.Aciklama;
            tglDurum.IsOn = entity.Durum;
        }
        protected override void GuncelNesneOlustur()
        {
            currentEntity = new SinifGrup
            {
                Id = Id,
                Kod = txtKod.Text,
                GrupAdi = txtGrupAdi.Text,
                Aciklama = txtAciklama.Text,
                Durum = tglDurum.IsOn
            };

            ButonEnabledDurumu();
        }
    }
}
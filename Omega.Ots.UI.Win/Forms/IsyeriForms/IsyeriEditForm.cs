using Omega.Ots.Bll.General;
using Omega.Ots.Common.Enums;
using Omega.Ots.Model.Entities;
using Omega.Ots.UI.Win.Forms.BaseForms;
using Omega.Ots.UI.Win.Functions;

namespace Omega.Ots.UI.Win.Forms.IsyeriForms
{
    public partial class IsyeriEditForm : BaseEditForm
    {
        public IsyeriEditForm()
        {
            InitializeComponent();

            dataLayoutControl = myDataLayoutControl;
            Bll = new IsyeriBll(myDataLayoutControl);
            kartTuru = KartTuru.Isyeri;
            EventsLoad();
        }

        protected internal override void Yukle()
        {
            oldEntity = BaseIslemTuru == IslemTuru.EntityInsert ? new Isyeri() : ((IsyeriBll)Bll).Single(FilterFunctions.Filter<Isyeri>(Id));
            NesneyiKontrollereBagla();

            if (BaseIslemTuru != IslemTuru.EntityInsert) return;
            Id = BaseIslemTuru.IdOlustur(oldEntity);
            txtKod.Text = ((IsyeriBll)Bll).YeniKodVer();
            txtIsyeriAdi.Focus();
        }

        protected override void NesneyiKontrollereBagla()
        {
            var entity = (Isyeri)oldEntity;
            txtKod.Text = entity.Kod;
            txtIsyeriAdi.Text = entity.IsyeriAdi;
            txtAciklama.Text = entity.Aciklama;
            tglDurum.IsOn = entity.Durum;
        }

        protected override void GuncelNesneOlustur()
        {
            currentEntity = new Isyeri
            {
                Id = Id,
                Kod = txtKod.Text,
                IsyeriAdi = txtIsyeriAdi.Text,
                Aciklama = txtAciklama.Text,
                Durum = tglDurum.IsOn
            };
            ButonEnabledDurumu();
        }
    }
}
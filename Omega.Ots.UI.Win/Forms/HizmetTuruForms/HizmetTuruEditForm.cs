using Omega.Ots.Bll.General;
using Omega.Ots.Common.Enums;
using Omega.Ots.Common.Functions;
using Omega.Ots.Model.Entities;
using Omega.Ots.UI.Win.Forms.BaseForms;
using Omega.Ots.UI.Win.Functions;

namespace Omega.Ots.UI.Win.Forms.HizmetTuruForms
{
    public partial class HizmetTuruEditForm : BaseEditForm
    {
        public HizmetTuruEditForm()
        {
            InitializeComponent();
            dataLayoutControl = myDataLayoutControl;
            Bll = new HizmetTuruBll(myDataLayoutControl);
            txtHizmetTipi.Properties.Items.AddRange(EnumFunctions.GetEnumDescriptionList<HizmetTipi>());
            kartTuru = KartTuru.HizmetTuru;
            EventsLoad();
        }

        protected internal override void Yukle()
        {
            oldEntity = BaseIslemTuru == IslemTuru.EntityInsert ? new HizmetTuru() : ((HizmetTuruBll)Bll).Single(FilterFunctions.Filter<HizmetTuru>(Id));
            NesneyiKontrollereBagla();

            if (BaseIslemTuru != IslemTuru.EntityInsert) return;
            Id = BaseIslemTuru.IdOlustur(oldEntity);
            txtKod.Text = ((HizmetTuruBll)Bll).YeniKodVer();
            txtHizmetTuruAdi.Focus();
        }

       protected override void NesneyiKontrollereBagla()
        {
            var entity = (HizmetTuru)oldEntity;
            txtKod.Text = entity.Kod;
            txtHizmetTuruAdi.Text = entity.HizmetTuruAdi;
            txtHizmetTipi.SelectedItem = entity.HizmetTipi.ToName();
            txtAciklama.Text = entity.Aciklama;
            tglDurum.IsOn = entity.Durum;
        }
        protected override void GuncelNesneOlustur()
        {
            currentEntity = new HizmetTuru
            {
                Id = Id,
                Kod = txtKod.Text,
                HizmetTuruAdi = txtHizmetTuruAdi.Text,
                HizmetTipi = txtHizmetTipi.Text.GetEnum<HizmetTipi>(),
                Aciklama = txtAciklama.Text,
                Durum = tglDurum.IsOn
            };

            ButonEnabledDurumu();
        }
    }
}
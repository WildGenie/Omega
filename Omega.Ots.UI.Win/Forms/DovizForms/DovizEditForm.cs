using Omega.Ots.Bll.General;
using Omega.Ots.Common.Enums;
using Omega.Ots.Common.Functions;
using Omega.Ots.Model.Entities;
using Omega.Ots.UI.Win.Forms.BaseForms;
using Omega.Ots.UI.Win.Functions;

namespace Omega.Ots.UI.Win.Forms.DovizForms
{
    public partial class DovizEditForm : BaseEditForm
    {
        public DovizEditForm()
        {
            InitializeComponent();
            dataLayoutControl = myDataLayoutControl;
            Bll = new DovizBll(myDataLayoutControl);
            txtTcmbDovizKodu.Properties.Items.AddRange(EnumFunctions.GetEnumDescriptionList<TcmbDovizKodu>());
            kartTuru = KartTuru.Doviz;
            EventsLoad();
        }
        protected internal override void Yukle()
        {
            oldEntity = BaseIslemTuru == IslemTuru.EntityInsert ? new Doviz() : ((DovizBll)Bll).Single(FilterFunctions.Filter<Doviz>(Id));
            NesneyiKontrollereBagla();

            if (BaseIslemTuru != IslemTuru.EntityInsert) return;
            Id = BaseIslemTuru.IdOlustur(oldEntity);
            txtKod.Focus();
        }

        protected override void NesneyiKontrollereBagla()
        {
            var entity = (Doviz)oldEntity;
            txtKod.Text = entity.Kod;
            txtDovizAdi.Text = entity.DovizAdi;
            txtTcmbDovizKodu.SelectedItem = entity.TcmbDovizKodu.ToName();
            txtAciklama.Text = entity.Aciklama;
            tglDurum.IsOn = entity.Durum;
        }
        protected override void GuncelNesneOlustur()
        {
            currentEntity = new Doviz
            {
                Id = Id,
                Kod = txtKod.Text,
                DovizAdi = txtDovizAdi.Text,
                TcmbDovizKodu = txtTcmbDovizKodu.Text.GetEnum<TcmbDovizKodu>(),
                Aciklama = txtAciklama.Text,
                Durum = tglDurum.IsOn
            };

            ButonEnabledDurumu();
        }
    }
}
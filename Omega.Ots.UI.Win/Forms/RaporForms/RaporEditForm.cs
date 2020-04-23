using Omega.Ots.Bll.General;
using Omega.Ots.Common.Enums;
using Omega.Ots.Model.Entities;
using Omega.Ots.UI.Win.Forms.BaseForms;
using Omega.Ots.UI.Win.Functions;

namespace Omega.Ots.UI.Win.Forms.RaporForms
{
    public partial class RaporEditForm : BaseEditForm
    {
        #region Variables
        private readonly KartTuru _raporTuru;
        private readonly RaporBolumTuru _raporBolumTuru;
        private readonly byte[] _dosya;
        #endregion

        public RaporEditForm(params object[] prm)
        {
            InitializeComponent();
            dataLayoutControl = myDataLayoutControl;
            Bll = new RaporBll(myDataLayoutControl);
            kartTuru = KartTuru.Rapor;
            EventsLoad();

            _raporTuru = (KartTuru)prm[0];
            _raporBolumTuru = (RaporBolumTuru)prm[1];
            _dosya = (byte[])prm[2];
        }

        protected internal override void Yukle()
        {
            oldEntity = BaseIslemTuru == IslemTuru.EntityInsert ? new Rapor() : ((RaporBll)Bll).Single(FilterFunctions.Filter<Rapor>(Id));
            NesneyiKontrollereBagla();

            if (BaseIslemTuru != IslemTuru.EntityInsert) return;
            Id = BaseIslemTuru.IdOlustur(oldEntity);
            txtKod.Text = ((RaporBll)Bll).YeniKodVer(x => x.RaporBolumTuru == _raporBolumTuru && x.RaporTuru == _raporTuru);
            txtRaporAdi.Focus();
        }

        protected override void NesneyiKontrollereBagla()
        {
            var entity = (Rapor)oldEntity;
            txtKod.Text = entity.Kod;
            txtRaporAdi.Text = entity.RaporAdi;
            txtAciklama.Text = entity.Aciklama;
            tglDurum.IsOn = entity.Durum;
        }
        protected override void GuncelNesneOlustur()
        {
            currentEntity = new Rapor
            {
                Id = Id,
                Kod = txtKod.Text,
                RaporAdi = txtRaporAdi.Text,

                RaporBolumTuru = _raporBolumTuru,
                Dosya = _dosya,
                RaporTuru = _raporTuru,
                Aciklama = txtAciklama.Text,
                Durum = tglDurum.IsOn
            };

            ButonEnabledDurumu();
        }

        protected override bool EntityInsert()
        {
            return ((RaporBll)Bll).Insert(currentEntity, x => x.Kod == currentEntity.Kod && x.RaporBolumTuru == _raporBolumTuru && x.RaporTuru == _raporTuru);
        }

        protected override bool EntityUpdate()
        {
            return ((RaporBll)Bll).Update(oldEntity, currentEntity, x => x.Kod == currentEntity.Kod && x.RaporBolumTuru == _raporBolumTuru && x.RaporTuru == _raporTuru);
        }
    }
}
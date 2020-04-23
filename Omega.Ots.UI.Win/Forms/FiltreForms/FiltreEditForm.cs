using Omega.Ots.UI.Win.Forms.BaseForms;
using Omega.Ots.Common.Enums;
using DevExpress.XtraGrid;
using Omega.Ots.Bll.General;
using DevExpress.XtraBars;
using Omega.Ots.Model.Entities;
using Omega.Ots.UI.Win.Functions;

namespace Omega.Ots.UI.Win.Forms.FiltreForms
{
    public partial class FiltreEditForm : BaseEditForm
    {
        #region Variables
        private readonly KartTuru _filtreKartTuru;
        private readonly GridControl _filtreGrid;
        #endregion

        public FiltreEditForm(params object[] prm)
        {
            InitializeComponent();

            _filtreKartTuru = (KartTuru)prm[0];
            _filtreGrid = (GridControl)prm[1];

            HideItems = new BarItem[] { btnYeni, btnGeriAl };
            ShowItems = new BarItem[] { btnFarkliKaydet, btnUygula };


            dataLayoutControl = myDataLayoutControl;
            Bll = new FiltreBll(myDataLayoutControl);
            kartTuru = KartTuru.Filtre;
            EventsLoad();

        }
        protected internal override void Yukle()
        {
            txtFiltreMetni.SourceControl = _filtreGrid;

            while (true)
            {
                if (BaseIslemTuru == IslemTuru.EntityInsert)
                {
                    oldEntity = new Filtre();
                    Id = BaseIslemTuru.IdOlustur(oldEntity);
                    txtKod.Text = ((FiltreBll)Bll).YeniKodVer(x => x.KartTuru == _filtreKartTuru);

                }
                else
                {
                    oldEntity = ((FiltreBll)Bll).Single(FilterFunctions.Filter<Filtre>(Id));
                    if (oldEntity == null)
                    {
                        BaseIslemTuru = IslemTuru.EntityInsert;
                        continue;
                    }
                    NesneyiKontrollereBagla();
                }
                break;
            }
        }
        protected override void NesneyiKontrollereBagla()
        {
            var entity = (Filtre)oldEntity;

            txtKod.Text = entity.Kod;
            txtFiltreAdi.Text = entity.FiltreAdi;
            txtFiltreMetni.FilterString = entity.FiltreMetni;
        }
        protected override void GuncelNesneOlustur()
        {
            currentEntity = new Filtre
            {
                Id = Id,
                Kod = txtKod.Text,
                FiltreAdi = txtFiltreAdi.Text,
                FiltreMetni = txtFiltreMetni.FilterString,
                KartTuru = _filtreKartTuru
            };
            ButonEnabledDurumu();
        }
        protected override bool EntityInsert()
        {
            return ((FiltreBll)Bll).Insert(currentEntity, x => x.Kod == currentEntity.Kod && x.KartTuru == _filtreKartTuru);
        }
        protected override bool EntityUpdate()
        {
            return ((FiltreBll)Bll).Update(oldEntity, currentEntity, X => X.Kod == currentEntity.Kod && X.KartTuru == _filtreKartTuru);

        }
        protected override void FiltreUygula()
        {
            txtFiltreMetni.Select();
            txtFiltreMetni.ApplyFilter();
        }
        protected internal override void ButonEnabledDurumu()
        {
            if (!IsLoaded) return;
            GeneralFunctions.ButtonEnabledDurumu(btnKaydet, btnFarkliKaydet, btnSil, BaseIslemTuru, oldEntity, currentEntity);

        }
    }
}
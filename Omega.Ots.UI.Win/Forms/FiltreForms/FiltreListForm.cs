using Omega.Ots.UI.Win.Forms.BaseForms;
using Omega.Ots.Bll.General;
using Omega.Ots.Common.Enums;
using Omega.Ots.UI.Win.Show;
using DevExpress.XtraGrid;
using DevExpress.XtraBars;

namespace Omega.Ots.UI.Win.Forms.FiltreForms
{
    public partial class FiltreListForm : BaseListForm
    {
        #region Variables
        private readonly KartTuru _filtreKartTuru;
        private readonly GridControl _filtreGrid;
        #endregion

        public FiltreListForm(params object[] prm)
        {
            InitializeComponent();
            Bll = new FiltreBll();

            _filtreKartTuru = (KartTuru)prm[0];
            _filtreGrid = (GridControl)prm[1];

            HideItems = new BarItem[] { btnFiltrele, btnKolonlar, btnYazdir, btnGonder, barFiltrele, barFiltreleAciklama, barKolonlar, barKolonlarAciklama, barYazdir, barYazdirAciklama, barGonder, barGonderAciklama };

        }
        protected override void DegiskenleriDoldur()
        {
            base.Tablo = tablo;
            BaseKartTuru = KartTuru.Filtre;
            // formShow = new ShowEditForms<IlceEditForm>();
            navigator = longNavigator.Navigator;
        }
        protected override void Listele()
        {
            Tablo.GridControl.DataSource = ((FiltreBll)Bll).List(x => x.KartTuru == _filtreKartTuru);
        }
        protected override void ShowEditForm(long id)
        {
            var result = ShowEditForms<FiltreEditForm>.ShowDialogEditForms(KartTuru.Filtre, id, _filtreKartTuru, _filtreGrid);
            ShowEditFormDefault(result);
        }
    }
}
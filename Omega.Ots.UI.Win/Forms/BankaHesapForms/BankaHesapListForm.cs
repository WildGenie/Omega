using Omega.Ots.Bll.General;
using Omega.Ots.Common.Enums;
using Omega.Ots.Model.Entities;
using Omega.Ots.UI.Win.Forms.BaseForms;
using Omega.Ots.UI.Win.GeneralForms;
using Omega.Ots.UI.Win.Show;
using System;
using System.Linq.Expressions;

namespace Omega.Ots.UI.Win.Forms.BankaHesapForms
{
    public partial class BankaHesapListForm : BaseListForm
    {
        #region Variables
        private readonly Expression<Func<BankaHesap, bool>> _filter;
        private readonly BankaHesapTuru _HesapTuru = BankaHesapTuru.VadesizMevduatHesabi;
        #endregion

        public BankaHesapListForm()
        {
            InitializeComponent();
            Bll = new BankaHesapBll();
            _filter = x => x.Durum == AktifKartlariGoster && x.SubeId == AnaForm.SubeId;
        }


        public BankaHesapListForm(params object[] prm) : this()
        {
            if (prm[0].GetType() == typeof(BankaHesapTuru))
                _HesapTuru = (BankaHesapTuru)prm[0];

            else if (prm[0].GetType() == typeof(OdemeTipi))
            {
                var odemeTipi = (OdemeTipi)prm[0];

                switch (odemeTipi)
                {
                    case OdemeTipi.Epos:
                        _HesapTuru = BankaHesapTuru.EpostBlokeHesabi;
                        break;
                    case OdemeTipi.Ots:
                        _HesapTuru = BankaHesapTuru.OtsBlokeHesabi;
                        break;
                    case OdemeTipi.Pos:
                        _HesapTuru = BankaHesapTuru.PostBlokeHesabi;
                        break;
                }
            }
            _filter = x => x.Durum == AktifKartlariGoster && x.HesapTuru == _HesapTuru && x.SubeId == AnaForm.SubeId;
        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.BankaHesap;
            FormShow = new ShowEditForms<BankaHesapEditForm>();
            navigator = longNavigator.Navigator;
        }
        protected override void Listele()
        {
            Tablo.GridControl.DataSource = ((BankaHesapBll)Bll).List(_filter);
        }
    }
}
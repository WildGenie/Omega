using DevExpress.XtraBars;
using Omega.Ots.Bll.General;
using Omega.Ots.UI.Win.UserControls.UserControl.Base;
using Omega.Ots.UI.Win.Functions;
using Omega.Ots.Model.Dto;
using Omega.Ots.UI.Win.Show;
using Omega.Ots.UI.Win.Forms.TahakkukForms;
using Omega.Ots.Common.Enums;
using Omega.Ots.UI.Win.GeneralForms;

namespace Omega.Ots.UI.Win.UserControls.UserControl.TahakkukEditFormTable
{
    public partial class TahakkukBilgileriTable : BaseTablo
    {
        public TahakkukBilgileriTable()
        {
            InitializeComponent();

            Bll = new TahakkukBll();
            Tablo = tablo;
            EventsLoad();

            insUptNavigator.Navigator.Buttons.Append.Visible = false;
            insUptNavigator.Navigator.Buttons.Remove.Visible = false;
            insUptNavigator.Navigator.Buttons.PrevPage.Visible = true;
            insUptNavigator.Navigator.Buttons.NextPage.Visible = true;

            HideItems = new BarItem[] { btnHareketEkle, btnHareketSil };
            ShowItems = new BarItem[] { btnKartDuzenle };
        }

        protected internal override void Listele()
        {
            tablo.GridControl.DataSource = ((TahakkukBll)Bll).OgrenciTahakkukList(x => x.OgrenciId == OwnerForm.Id);
        }

        protected override void OpenEntity()
        {
            var entity = tablo.GetRow<OgrenciTahakkukL>();
            if (entity == null) return;
            ShowEditForms<TahakkukEditForm>.ShowDialogEditForms(KartTuru.Tahakkuk, entity.TahakkukId, entity.SubeId != AnaForm.SubeId || entity.DonemId != AnaForm.DonemId);
        }
    }
}

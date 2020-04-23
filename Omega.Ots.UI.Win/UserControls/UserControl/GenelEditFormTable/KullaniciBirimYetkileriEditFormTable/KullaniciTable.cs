
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Base;
using Omega.Ots.Bll.General;
using Omega.Ots.Model.Dto;
using Omega.Ots.UI.Win.Forms.KullaniciForms;
using Omega.Ots.UI.Win.Functions;
using Omega.Ots.UI.Win.UserControls.UserControl.Base;

namespace Omega.Ots.UI.Win.UserControls.KullaniciBirimYetkileriEditFormTable
{
    public partial class KullaniciTable : BaseTablo
    {
        public KullaniciTable()
        {
            InitializeComponent();


            Bll = new KullaniciBll();
            Tablo = tablo;
            EventsLoad();
            HideItems = new BarItem[] { btnHareketEkle, btnHareketSil };
            insUptNavigator.Navigator.Buttons.Append.Visible = false;
            insUptNavigator.Navigator.Buttons.Remove.Visible = false;
            insUptNavigator.Navigator.Buttons.PrevPage.Visible = true;
            insUptNavigator.Navigator.Buttons.NextPage.Visible = true;
        }

        protected internal override void Listele()
        {
            tablo.GridControl.DataSource = ((KullaniciBll)Bll).List(null);
        }

        protected override void HareketSil() { }

        protected override void Tablo_FocusedRowObjectChanged(object sender, FocusedRowObjectChangedEventArgs e)
        {
            var entity = tablo.GetRow<KullaniciL>();
            if (entity == null) return;
            OwnerForm.Id = entity.Id;
            ((KullaniciBirimYetkileriEditForm)OwnerForm).Yukle();
        }
    }
}

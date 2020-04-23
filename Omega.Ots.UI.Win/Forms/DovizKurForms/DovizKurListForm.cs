using DevExpress.XtraBars;
using Omega.Ots.Bll.General;
using Omega.Ots.Common.Enums;
using Omega.Ots.UI.Win.Forms.BaseForms;
using Omega.Ots.UI.Win.GeneralForms;
using Omega.Ots.UI.Win.Show;

namespace Omega.Ots.UI.Win.Forms.DovizKurForms
{
    public partial class DovizKurListForm : BaseListForm
    {
        public DovizKurListForm()
        {
            InitializeComponent();
            Bll = new DovizKurBll();
            ShowItems = new BarItem[] { btnOtomatikKurKaydet };           
        }
        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.DovizKur;
            FormShow = new ShowEditForms<DovizKurEditForm>();
            navigator = longNavigator.Navigator;
            btnAktifPasifKartlar.Visibility = BarItemVisibility.Never;
        }
        protected override void Listele()
        {
            Tablo.GridControl.DataSource = ((DovizKurBll)Bll).List(x => x.Tarih >= AnaForm.DonemParametreleri.DonemBaslamaTarihi && x.Tarih <= AnaForm.DonemParametreleri.DonemBitisTarihi);
        }

        protected override void OtomatikKurKaydet()
        {
            var result = ShowEditForms<DovizKurEditForm>.ShowDialogEditForms(KartTuru.DovizKur, -1, "OtomatikKurKaydet");
            ShowEditFormDefault(result);
        }
    }
}
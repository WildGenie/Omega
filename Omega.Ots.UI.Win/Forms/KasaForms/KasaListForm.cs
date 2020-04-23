using Omega.Ots.Bll.General;
using Omega.Ots.Common.Enums;
using Omega.Ots.UI.Win.Forms.BaseForms;
using Omega.Ots.UI.Win.GeneralForms;
using Omega.Ots.UI.Win.Show;

namespace Omega.Ots.UI.Win.Forms.KasaForms
{
    public partial class KasaListForm : BaseListForm
    {
        public KasaListForm()
        {
            InitializeComponent();
            Bll = new KasaBll();
        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.Kasa;
            FormShow = new ShowEditForms<KasaEditForm>();
            navigator = longNavigator.Navigator;
        }

        protected override void Listele()
        {
            Tablo.GridControl.DataSource = ((KasaBll)Bll).List(x => x.Durum == AktifKartlariGoster && x.SubeId == AnaForm.SubeId && x.DonemId == AnaForm.DonemId);
        }
    }
}
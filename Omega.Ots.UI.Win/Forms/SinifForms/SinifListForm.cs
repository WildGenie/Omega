
using Omega.Ots.Bll.General;
using Omega.Ots.Common.Enums;
using Omega.Ots.UI.Win.Forms.BaseForms;
using Omega.Ots.UI.Win.GeneralForms;
using Omega.Ots.UI.Win.Show;

namespace Omega.Ots.UI.Win.Forms.SinifForms
{
    public partial class SinifListForm : BaseListForm
    {
        public SinifListForm()
        {
            InitializeComponent();
            Bll = new SinifBll();
        }
        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.Sinif;
            navigator = longNavigator.Navigator;
            FormShow = new ShowEditForms<SinifEditForm>();
        }
        protected override void Listele()
        {
            Tablo.GridControl.DataSource = ((SinifBll)Bll).List(x => x.Durum == AktifKartlariGoster
            && x.SubeId == AnaForm.SubeId);
        }
    }
}
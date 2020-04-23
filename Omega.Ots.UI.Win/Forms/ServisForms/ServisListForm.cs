using Omega.Ots.Bll.General;
using Omega.Ots.Common.Enums;
using Omega.Ots.UI.Win.Forms.BaseForms;
using Omega.Ots.UI.Win.GeneralForms;
using Omega.Ots.UI.Win.Show;

namespace Omega.Ots.UI.Win.Forms.ServisForms
{
    public partial class ServisListForm : BaseListForm
    {
        public ServisListForm()
        {
            InitializeComponent();
            Bll = new ServisBll();
        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.Servis;
            navigator = longNavigator.Navigator;
            FormShow = new ShowEditForms<ServisEditForm>();
        }

        protected override void Listele()
        {
            Tablo.GridControl.DataSource = ((ServisBll)Bll).List(x => x.Durum == AktifKartlariGoster
            && x.SubeId == AnaForm.SubeId && x.DonemId == AnaForm.DonemId);
        }
    }
}
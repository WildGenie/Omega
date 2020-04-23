using DevExpress.XtraBars;
using Omega.Ots.Bll.General;
using Omega.Ots.Common.Enums;
using Omega.Ots.Model.Entities;
using Omega.Ots.UI.Win.Forms.BaseForms;
using Omega.Ots.UI.Win.Functions;
using Omega.Ots.UI.Win.Show;

namespace Omega.Ots.UI.Win.Forms.IndirimTuruForms
{
    public partial class IndirimTuruListForm : BaseListForm
    {
        public IndirimTuruListForm()
        {
            InitializeComponent();
            Bll = new IndirimTuruBll();
        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.IndirimTuru;
            FormShow = new ShowEditForms<IndirimTuruEditForm>();
            navigator = longNavigator.Navigator;           
        }

        protected override void Listele()
        {
            Tablo.GridControl.DataSource = ((IndirimTuruBll)Bll).List(FilterFunctions.Filter<IndirimTuru>(AktifKartlariGoster));
        }
    }
}
using Omega.Ots.UI.Win.Forms.BaseForms;
using Omega.Ots.Bll.General;
using Omega.Ots.UI.Win.Show;
using Omega.Ots.Common.Enums;
using Omega.Ots.UI.Win.Functions;
using Omega.Ots.Model.Entities;

namespace Omega.Ots.UI.Win.Forms.DovizForms
{
    public partial class DovizListForm : BaseListForm
    {
        public DovizListForm()
        {
            InitializeComponent();
            Bll = new DovizBll();
        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.Doviz;
            FormShow = new ShowEditForms<DovizEditForm>();
            navigator = longNavigator.Navigator;
        }

        protected override void Listele()
        {
            Tablo.GridControl.DataSource = ((DovizBll)Bll).List(FilterFunctions.Filter<Doviz>(AktifKartlariGoster));
        }
    }
}
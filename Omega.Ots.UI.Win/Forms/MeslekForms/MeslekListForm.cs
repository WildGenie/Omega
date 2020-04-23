using Omega.Ots.Bll.General;
using Omega.Ots.Common.Enums;
using Omega.Ots.Model.Entities;
using Omega.Ots.UI.Win.Forms.BaseForms;
using Omega.Ots.UI.Win.Functions;
using Omega.Ots.UI.Win.Show;

namespace Omega.Ots.UI.Win.Forms.MeslekForms
{
    public partial class MeslekListForm : BaseListForm
    {
        public MeslekListForm()
        {
            InitializeComponent();
            Bll = new MeslekBll();
        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.Meslek;
            FormShow = new ShowEditForms<MeslekEditForm>();
            navigator = longNavigator.Navigator;
        }

        protected override void Listele()
        {
            Tablo.GridControl.DataSource = ((MeslekBll)Bll).List(FilterFunctions.Filter<Meslek>(AktifKartlariGoster));
        }
    }
}
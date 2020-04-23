using Omega.Ots.Bll.General;
using Omega.Ots.Common.Enums;
using Omega.Ots.Common.Message;
using Omega.Ots.Model;
using Omega.Ots.UI.Win.Forms.BaseForms;
using Omega.Ots.UI.Win.GeneralForms;
using Omega.Ots.UI.Win.Show;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;

namespace Omega.Ots.UI.Win.Forms.EvrakForms
{
    public partial class EvrakListForm : BaseListForm
    {

        #region Variables
        private readonly Expression<Func<Evrak, bool>> _filter;
        #endregion

        public EvrakListForm()
        {
            InitializeComponent();

            Bll = new EvrakBll();
            _filter = x => x.Durum == AktifKartlariGoster && x.SubeId == AnaForm.SubeId && x.DonemId == AnaForm.DonemId;
        }
        public EvrakListForm(params object[] prm) : this()
        {
            _filter = x => !ListeDisiTutulacakKayitlar.Contains(x.Id) && x.Durum == AktifKartlariGoster && x.SubeId == AnaForm.SubeId && x.DonemId == AnaForm.DonemId;
        }
        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.Evrak;
            navigator = longNavigator.Navigator;
            FormShow = new ShowEditForms<EvrakEditForm>();
        }
        protected override void Listele()
        {
            var list = ((EvrakBll)Bll).List(_filter);
            Tablo.GridControl.DataSource = list;

            if (!MultiSelect) return;
            if (list.Any())
                EklenebilecekEntityVar = true;
            else
                Messages.KartBulunamadiMesaji("Kart");
        }
    }
}
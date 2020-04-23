using Omega.Ots.Bll.General;
using Omega.Ots.Common.Enums;
using Omega.Ots.Common.Message;
using Omega.Ots.Model.Entities;
using Omega.Ots.UI.Win.Forms.BaseForms;
using Omega.Ots.UI.Win.Functions;
using Omega.Ots.UI.Win.Show;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Omega.Ots.UI.Win.Forms.IletisimForms
{
    public partial class IletisimListForm : BaseListForm
    {
        #region Variables
        private readonly Expression<Func<Iletisim, bool>> _filter;
        #endregion

        public IletisimListForm()
        {
            InitializeComponent();
            Bll = new IletisimBll();
            _filter = x => x.Durum == AktifKartlariGoster;
        }

        public IletisimListForm(params object[] prm) : this()
        {
            _filter = x => !ListeDisiTutulacakKayitlar.Contains(x.Id) && x.Durum == AktifKartlariGoster;
        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.Iletisim;
            FormShow = new ShowEditForms<IletisimEditForm>();
            navigator = longNavigator.Navigator;
        }

        protected override void Listele()
        {
            var list = ((IletisimBll)Bll).List(_filter);
            Tablo.GridControl.DataSource = list;

            if (!MultiSelect) return;
            if (list.Any())
                EklenebilecekEntityVar = true;
            else
                Messages.KartBulunamadiMesaji("Kart");
        }
    }
}
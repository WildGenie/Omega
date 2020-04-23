using DevExpress.XtraBars;
using Omega.Ots.Bll.General;
using Omega.Ots.Common.Enums;
using Omega.Ots.Common.Message;
using Omega.Ots.Model.Dto;
using Omega.Ots.Model.Entities;
using Omega.Ots.UI.Win.Forms.BaseForms;
using Omega.Ots.UI.Win.Show;
using System;
using System.Linq;
using System.Linq.Expressions;
using Omega.Ots.UI.Win.Functions;
using Omega.Ots.UI.Win.GeneralForms;

namespace Omega.Ots.UI.Win.Forms.DonemForms
{
    public partial class DonemListForm : BaseListForm
    {
        #region Variables
        private readonly Expression<Func<Donem, bool>> _filter;
        #endregion

        public DonemListForm()
        {
            InitializeComponent();
            Bll = new DonemBll();
            _filter = x => x.Durum == AktifKartlariGoster;
            ShowItems = new BarItem[] { btnParametreler, barF4, barF4Aciklama };
        }

        public DonemListForm(params object[] prm) : this()
        {
            _filter = x => !ListeDisiTutulacakKayitlar.Contains(x.Id) && x.Durum == AktifKartlariGoster;
        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.Donem;
            FormShow = new ShowEditForms<DonemEditForm>();
            navigator = longNavigator.Navigator;

        }

        protected override void Listele()
        {
            var list = ((DonemBll)Bll).List(_filter);
            Tablo.GridControl.DataSource = list;

            if (!MultiSelect) return;
            if (list.Any())
                EklenebilecekEntityVar = true;
            else
                Messages.KartBulunamadiMesaji("Kart");

        }

        protected override void BagliKartAc()
        {
            var entity = Tablo.GetRow<Donem>();
            if (entity == null) return;
            ShowEditForms<DonemParametreEditForm>.ShowDialogEditForms(null, entity.Id);
        }
    }
}
using DevExpress.XtraBars;
using Omega.Ots.Bll.General;
using Omega.Ots.Common.Enums;
using Omega.Ots.UI.Win.Forms.BaseForms;
using Omega.Ots.UI.Win.Show;

namespace Omega.Ots.UI.Win.Forms.GecikmeAciklamalariForms
{
    public partial class GecikmeAciklamalariListForm : BaseListForm
    {
        #region Variables
        private readonly int _portfoyNo;
        #endregion

        public GecikmeAciklamalariListForm(params object[] prm)
        {
            InitializeComponent();
            Bll = new GecikmeAciklamalariBll();
            HideItems = new BarItem[] { btnSec };

            _portfoyNo = (int)prm[0];
        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.Aciklama;
            navigator = longNavigator.Navigator;

        }

        protected override void Listele()
        {
            Tablo.GridControl.DataSource = ((GecikmeAciklamalariBll)Bll).List(x => x.OdemeBilgileriId == _portfoyNo);
        }
        protected override void ShowEditForm(long id)
        {
            var result = ShowEditForms<GecikmeAciklamalariEditForm>.ShowDialogEditForms(KartTuru.Aciklama, id, _portfoyNo);
            ShowEditFormDefault(result);
        }
    }
}

using Omega.Ots.Bll.Functions;
using Omega.Ots.Bll.General;
using Omega.Ots.Common.Enums;
using Omega.Ots.Model.Dto;
using Omega.Ots.Model.Entities;
using Omega.Ots.UI.Win.Forms;
using Omega.Ots.UI.Win.Functions;
using Omega.Ots.UI.Win.Show;
using Omega.Ots.UI.Win.UserControls.UserControl.Base;
using System.Linq;

namespace Omega.Ots.UI.Win.UserControls.UserControl.TahakkukEditFormTable
{
    public partial class AileBilgileriTable : BaseTablo
    {
        public AileBilgileriTable()
        {
            InitializeComponent();
            Bll = new AileBilgileriBll();
            Tablo = tablo;
            EventsLoad();
        }

        protected internal override void Listele()
        {
            tablo.GridControl.DataSource = ((AileBilgileriBll)Bll).List(x => x.TahakkukId == OwnerForm.Id).ToBindingList<AileBilgileriL>();
        }

        protected override void HareketEkle()
        {

            var source = tablo.DataController.ListSource;
            ListeDisiTutulacakKayitlar = source.Cast<AileBilgileriL>().Where(x => !x.Delete).Select(x => x.AileBilgiId).ToList();

            var entities = ShowListForms<AileBilgiListForm>.ShowDialogListForm(KartTuru.AileBilgi, ListeDisiTutulacakKayitlar, true, false).EntityListConvert<AileBilgi>();
            if (entities == null) return;

            foreach (var entity in entities)
            {
                var row = new AileBilgileriL
                {
                    TahakkukId = OwnerForm.Id,
                    AileBilgiId = entity.Id,
                    BilgiAdi = entity.BilgiAdi,
                    Aciklama = null,
                    Insert = true
                };
                source.Add(row);
            }

            tablo.Focus();
            tablo.RefleshDataSource();
            tablo.FocusedRowHandle = tablo.DataRowCount - 1;
            tablo.FocusedColumn = colBilgiAdi;
            ButtonEnabledDurumu(true);

        }
    }
}

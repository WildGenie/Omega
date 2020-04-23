
using DevExpress.XtraBars;
using Omega.Ots.Bll.Functions;
using Omega.Ots.Bll.General;
using Omega.Ots.Common.Enums;
using Omega.Ots.Model.Dto;
using Omega.Ots.UI.Win.Forms.TahakkukForms;
using Omega.Ots.UI.Win.Functions;
using Omega.Ots.UI.Win.GeneralForms;
using Omega.Ots.UI.Win.Show;
using Omega.Ots.UI.Win.UserControls.UserControl.Base;
using System.Linq;

namespace Omega.Ots.UI.Win.UserControls.UserControl.TahakkukEditFormTable
{
    public partial class KardesBilgileriTable : BaseTablo
    {
        public KardesBilgileriTable()
        {
            InitializeComponent();
            Bll = new KardesBilgileriBll();
            Tablo = tablo;
            EventsLoad();
            ShowItems = new BarItem[] { btnKartDuzenle };
        }

        protected internal override void Listele()
        {
            tablo.GridControl.DataSource = ((KardesBilgileriBll)Bll).List(x => x.TahakkukId == OwnerForm.Id).ToBindingList<KardesBilgileriL>();
        }

        protected override void HareketEkle()
        {

            var source = tablo.DataController.ListSource;
            ListeDisiTutulacakKayitlar = source.Cast<KardesBilgileriL>().Where(x => !x.Delete).Select(x => x.KardesTahakkukId).ToList();
            ListeDisiTutulacakKayitlar.Add(OwnerForm.Id);

            var entities = ShowListForms<TahakkukListForm>.ShowDialogListForm(KartTuru.Tahakkuk, ListeDisiTutulacakKayitlar, true, false).EntityListConvert<TahakkukL>();
            if (entities == null) return;

            foreach (var entity in entities)
            {
                var row = new KardesBilgileriL
                {
                    TahakkukId = OwnerForm.Id,
                    KardesTahakkukId = entity.Id,
                    Adi = entity.Adi,
                    Soyadi = entity.Soyadi,
                    SinifAdi = entity.SinifAdi,
                    SubeAdi = entity.SubeAdi,
                    KayitSekli = entity.KayitSekli,
                    KayitDurumu = entity.KayitDurumu,
                    IptalDurumu = entity.Durum ? IptalDurumu.DevamEdiyor : IptalDurumu.IptalEdildi,
                    Insert = true
                };
                source.Add(row);
            }

            tablo.Focus();
            tablo.RefleshDataSource();
            tablo.FocusedRowHandle = tablo.DataRowCount - 1;
            tablo.FocusedColumn = colAdi;
            ButtonEnabledDurumu(true);

        }
        protected override void OpenEntity()
        {
            var entity = tablo.GetRow<KardesBilgileriL>();
            if (entity == null) return;
            ShowEditForms<TahakkukEditForm>.ShowDialogEditForms(KartTuru.Tahakkuk, entity.KardesTahakkukId, entity.SubeId != AnaForm.SubeId || entity.DonemId != AnaForm.DonemId);
        }
    }
}

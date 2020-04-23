using Omega.Ots.Bll.General;
using Omega.Ots.Common.Enums;
using Omega.Ots.Common.Functions;
using Omega.Ots.Model.Dto;
using Omega.Ots.UI.Win.Forms.TahakkukForms;
using Omega.Ots.UI.Win.Functions;
using Omega.Ots.UI.Win.GeneralForms;
using Omega.Ots.UI.Win.Reports.FormReports.Base;
using Omega.Ots.UI.Win.Show;
using System.Linq;

namespace Omega.Ots.UI.Win.Reports.FormReports
{
    public partial class HizmetAlimRaporu : BaseRapor
    {
        public HizmetAlimRaporu()
        {
            InitializeComponent();
        }

        protected override void DegiskenleriDoldur()
        {
            DataLayoutControl = myDataLayoutControl;
            Tablo = tablo;
            Navigator = longNavigator.Navigator;
            Subeler = txtSubeler;
            Hizmetler = txtHizmetler;
            HizmetAlimTuru = txtHizmetAlimTuru;
            KayitSekilleri = txtKayitSekli;
            KayitDurumlari = txtKayitDurumu;

            SubeKartlariYukle();
            KayitSekliYukle();
            KayitDurumuYukle();
            HizmetKartlariYukle();
            txtHizmetAlimTuru.Properties.Items.AddRange(EnumFunctions.GetEnumDescriptionList<HizmetAlimDurumu>());
            txtHizmetAlimTuru.SelectedItem = HizmetAlimDurumu.HizmetiAlanlar.ToName();
            RaporTuru = KartTuru.HizmetAlimRaporu;
        }

        protected override void Listele()
        {
            var subeler = txtSubeler.CheckedComboBoxList<long>();
            var hizmetler = txtHizmetler.CheckedComboBoxList<long>();
            var kayitSekli = txtKayitSekli.CheckedComboBoxList<KayitSekli>();
            var kayitDurumu = txtKayitDurumu.CheckedComboBoxList<KayitDurumu>();


            using (var bll = new HizmetAlimRaporuBll())
            {
                tablo.GridControl.DataSource = bll.List(x =>
                    subeler.Contains(x.SubeId) &&
                    kayitSekli.Contains(x.KayitSekli) &&
                    kayitDurumu.Contains(x.KayitDurumu) &&
                    x.DonemId == AnaForm.DonemId, hizmetler, txtHizmetAlimTuru.Text.GetEnum<HizmetAlimDurumu>());
                base.Listele();
            }

        }

        protected override void ShowEditForm()
        {
            var entity = tablo.GetRow<HizmetAlimRaporuL>();
            if (entity == null) return;
            ShowEditForms<TahakkukEditForm>.ShowDialogEditForms(KartTuru.Tahakkuk, entity.TahakkukId, entity.SubeId != AnaForm.SubeId || entity.DonemId != AnaForm.DonemId);
        }
    }
}
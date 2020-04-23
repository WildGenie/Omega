﻿using DevExpress.Data;
using DevExpress.XtraBars;
using DevExpress.XtraGrid;
using Omega.Ots.Bll.General;
using Omega.Ots.Common.Enums;
using Omega.Ots.UI.Win.Functions;
using Omega.Ots.UI.Win.GeneralForms;
using Omega.Ots.UI.Win.Reports.FormReports.Base;
using System;
using System.Linq;

namespace Omega.Ots.UI.Win.Reports.FormReports
{
    public partial class AylikKayitRaporu : BaseRapor
    {
        public AylikKayitRaporu()
        {
            InitializeComponent();
            HideItems = new BarItem[] { btnKartAc };
        }

        protected override void DegiskenleriDoldur()
        {
            DataLayoutControl = myDataLayoutControl;
            Tablo = tablo;
            Navigator = longNavigator.Navigator;
            Subeler = txtSubeler;
            KayitSekilleri = txtKayitSekli;
            KayitDurumlari = txtKayitDurumu;
            IptalDurumlari = txtIptalDurumu;
            SubeKartlariYukle();
            KayitSekliYukle();
            KayitDurumuYukle();
            IptalDurumuYukle();
            RaporTuru = KartTuru.AylikKayitRaporu;
        }

        protected override void Listele()
        {
            var subeler = txtSubeler.CheckedComboBoxList<long>();
            var kayitSekli = txtKayitSekli.CheckedComboBoxList<KayitSekli>();
            var kayitDurumu = txtKayitDurumu.CheckedComboBoxList<KayitDurumu>();
            var iptalDurumu = txtIptalDurumu.CheckedComboBoxList<IptalDurumu>();

            using (var bll = new AylikKayitRaporuBll())
            {
                tablo.GridControl.DataSource = bll.List(x =>
                    subeler.Contains(x.SubeId) &&
                    kayitSekli.Contains(x.KayitSekli) &&
                    kayitDurumu.Contains(x.KayitDurumu) &&
                    iptalDurumu.Contains(x.Durum ? IptalDurumu.DevamEdiyor : IptalDurumu.IptalEdildi) &&
                    x.DonemId == AnaForm.DonemId);
                base.Listele();
            }

        }

        protected override void Tablo_CustomSummaryCalculate(object sender, CustomSummaryEventArgs e)
        {
            if (e.SummaryProcess != CustomSummaryProcess.Finalize) return;

            var item = (GridSummaryItem)e.Item;
            if (item.FieldName == "colIndirimOrani")
            {
                if (e.IsGroupSummary)
                {
                    var hizmetlerToplami = Convert.ToDecimal(Tablo.GetGroupSummaryValue(e.GroupRowHandle, (GridGroupSummaryItem)Tablo.GroupSummary["NetHizmet"]));
                    var indirimlerToplami = Convert.ToDecimal(Tablo.GetGroupSummaryValue(e.GroupRowHandle, (GridGroupSummaryItem)Tablo.GroupSummary["NetIndirim"]));

                    e.TotalValue = hizmetlerToplami == 0 ? 0 : indirimlerToplami / hizmetlerToplami * 100;
                }

                else if (e.IsTotalSummary)
                {
                    var hizmetlerToplami = Convert.ToDecimal(colNetHizmet.SummaryItem.SummaryValue);
                    var indirimlerToplami = Convert.ToDecimal(colNetIndirim.SummaryItem.SummaryValue);


                    e.TotalValue = hizmetlerToplami == 0 ? 0 : indirimlerToplami / hizmetlerToplami * 100;
                }
            }

            if (item.FieldName != "colOrtalama") return;

            if (e.IsGroupSummary)
            {
                var toplamKayit = Convert.ToDecimal(Tablo.GetGroupSummaryValue(e.GroupRowHandle, (GridGroupSummaryItem)Tablo.GroupSummary["ToplamKayit"]));
                var netUcret = Convert.ToDecimal(Tablo.GetGroupSummaryValue(e.GroupRowHandle, (GridGroupSummaryItem)Tablo.GroupSummary["NetUcret"]));

                e.TotalValue = toplamKayit == 0 ? 0 : netUcret / toplamKayit;
            }

            else if (e.IsTotalSummary)
            {
                var toplamKayit = Convert.ToDecimal(colToplamKayit.SummaryItem.SummaryValue);
                var netUcret = Convert.ToDecimal(colNetUcret.SummaryItem.SummaryValue);

                e.TotalValue = toplamKayit == 0 ? 0 : netUcret / toplamKayit;
            }
        }
    }
}
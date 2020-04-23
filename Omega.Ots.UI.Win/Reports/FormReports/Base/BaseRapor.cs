﻿using System;
using System.IO;
using System.Windows.Forms;
using DevExpress.Utils.Extensions;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;
using Omega.Ots.Bll.General;
using Omega.Ots.Common.Enums;
using Omega.Ots.Common.Functions;
using Omega.Ots.Common.Message;
using Omega.Ots.Model.Dto;
using Omega.Ots.Model.Entities;
using Omega.Ots.UI.Win.Forms.FiltreForms;
using Omega.Ots.UI.Win.Forms.RaporForms;
using Omega.Ots.UI.Win.Functions;
using Omega.Ots.UI.Win.GeneralForms;
using Omega.Ots.UI.Win.Show;
using Omega.Ots.UI.Win.UserControls.Controls;

namespace Omega.Ots.UI.Win.Reports.FormReports.Base
{
    public partial class BaseRapor : RibbonForm
    {
        private long _filtreId;
        private long _raporSablonId;
        private RaporBolumTuru _raporBolumTuru = RaporBolumTuru.GenelRaporlar;
        protected KartTuru RaporTuru;
        protected ControlNavigator Navigator;
        protected GridView Tablo;
        protected BarItem[] ShowItems;
        protected BarItem[] HideItems;
        protected MyCheckedComboBoxEdit Subeler;
        protected MyCheckedComboBoxEdit Hizmetler;
        protected MyCheckedComboBoxEdit Indirimler;
        protected MyCheckedComboBoxEdit Odemeler;
        protected MyCheckedComboBoxEdit BelgeDurumlari;
        protected MyCheckedComboBoxEdit KayitSekilleri;
        protected MyCheckedComboBoxEdit KayitDurumlari;
        protected MyCheckedComboBoxEdit IptalDurumlari;
        protected ComboBoxEdit HizmetAlimTuru;
        protected ComboBoxEdit HesaplamaSekli;
        protected MyDataLayoutControl DataLayoutControl;
        protected DateEdit IlkTarih, SonTarih;

        public BaseRapor()
        {
            InitializeComponent();
        }

        protected internal void Yukle()
        {
            DegiskenleriDoldur();
            EventsLoad();
            Navigator.NavigatableControl = Tablo.GridControl;

            ShowItems?.ForEach(x => x.Visibility = BarItemVisibility.Always);
            HideItems?.ForEach(x => x.Visibility = BarItemVisibility.Never);
        }

        protected virtual void DegiskenleriDoldur() { }

        private void EventsLoad()
        {
            foreach (BarItem button in ribbonControl.Items)
                button.ItemClick += Button_ItemClick;

            //Table Events
            Tablo.DoubleClick += Tablo_DoubleClick;
            Tablo.KeyDown += Control_KeyDown;
            Tablo.MouseUp += Tablo_MouseUp;
            Tablo.ColumnFilterChanged += Tablo_ColumnFilterChanged;
            Tablo.FilterEditorCreated += Tablo_FilterEditorCreated;
            Tablo.CustomDrawFooterCell += Tablo_CustomDrawFooterCell;
            Tablo.CustomDrawRowFooterCell += Tablo_CustomDrawRowFooterCell;
            Tablo.CustomSummaryCalculate += Tablo_CustomSummaryCalculate;
            Tablo.MasterRowGetRelationCount += Tablo_MasterRowGetRelationCount;
            Tablo.MasterRowGetRelationName += Tablo_MasterRowGetRelationName;
            Tablo.MasterRowGetChildList += Tablo_MasterRowGetChildList;
            //Form Events
            FormClosing += BaseRapor_FormClosing;

            void ControlEvents(Control control)
            {
                control.KeyDown += Control_KeyDown;
                if (control is SimpleButton btn)
                {
                    btn.Click += Control_Click;
                }
            }

            foreach (Control ctrl in DataLayoutControl.Controls)
            {
                ControlEvents(ctrl);
            }
        }

        protected void SubeKartlariYukle()
        {
            using (var bll = new SubeBll())
            {
                var entities = bll.List(x => AnaForm.YetkiliOlunanSubeler.Contains(x.Id));

                foreach (SubeL entity in entities)
                {
                    var item = new CheckedListBoxItem
                    {
                        CheckState = entity.Id == AnaForm.SubeId ? CheckState.Checked : CheckState.Unchecked,
                        Description = entity.SubeAdi,
                        Value = entity.Id
                    };
                    Subeler.Properties.Items.Add(item);
                }
            }
        }

        protected void KayitSekliYukle()
        {
            var enums = Enum.GetValues(typeof(KayitSekli));

            foreach (KayitSekli entity in enums)
            {
                var item = new CheckedListBoxItem
                {
                    CheckState = CheckState.Checked,
                    Description = entity.ToName(),
                    Value = entity
                };
                KayitSekilleri.Properties.Items.Add(item);
            }
        }

        protected void KayitDurumuYukle()
        {
            var enums = Enum.GetValues(typeof(KayitDurumu));

            foreach (KayitDurumu entity in enums)
            {
                var item = new CheckedListBoxItem
                {
                    CheckState = entity == KayitDurumu.KesinKayit ? CheckState.Checked : CheckState.Unchecked,
                    Description = entity.ToName(),
                    Value = entity
                };
                KayitDurumlari.Properties.Items.Add(item);
            }
        }

        protected void IptalDurumuYukle()
        {
            var enums = Enum.GetValues(typeof(IptalDurumu));

            foreach (IptalDurumu entity in enums)
            {
                var item = new CheckedListBoxItem
                {
                    CheckState = CheckState.Checked,
                    Description = entity.ToName(),
                    Value = entity
                };
                IptalDurumlari.Properties.Items.Add(item);
            }
        }

        protected void HizmetKartlariYukle()
        {
            using (var bll = new HizmetBll())
            {
                var entities = bll.List(null);

                foreach (HizmetL entity in entities)
                {
                    var item = new CheckedListBoxItem
                    {
                        CheckState = CheckState.Checked,
                        Description = entity.HizmetAdi,
                        Value = entity.Id
                    };
                    Hizmetler.Properties.Items.Add(item);
                }
            }
        }

        protected void OdemeTurleriYukle()
        {
            var enums = Enum.GetValues(typeof(OdemeTipi));

            foreach (OdemeTipi entity in enums)
            {
                var item = new CheckedListBoxItem
                {
                    CheckState = CheckState.Checked,
                    Description = entity.ToName(),
                    Value = entity
                };
                Odemeler.Properties.Items.Add(item);
            }
        }

        protected virtual void BelgeDurumuYukle()
        {
            var enums = Enum.GetValues(typeof(BelgeDurumu));

            foreach (BelgeDurumu entity in enums)
            {
                var item = new CheckedListBoxItem
                {
                    CheckState = CheckState.Checked,
                    Description = entity.ToName(),
                    Value = entity
                };
                BelgeDurumlari.Properties.Items.Add(item);
            }
        }

        protected void IndirimKartlariYukle()
        {
            using (var bll = new IndirimBll())
            {
                var entities = bll.List(null);

                foreach (IndirimL entity in entities)
                {
                    var item = new CheckedListBoxItem
                    {
                        CheckState = CheckState.Checked,
                        Description = entity.IndirimAdi,
                        Value = entity.Id
                    };
                    Indirimler.Properties.Items.Add(item);
                }
            }
        }

        private void FiltreSec()
        {
            var entity = (Filtre)ShowListForms<FiltreListForm>.ShowDialogListForm(KartTuru.Filtre, _filtreId, RaporTuru, Tablo.GridControl);
            if (entity == null) return;
            _filtreId = entity.Id;
            Tablo.ActiveFilterString = entity.FiltreMetni;
        }

        private void RaporSablonSec()
        {
            var entity = ShowListForms<RaporListForm>.ShowDialogListForm(KartTuru.Rapor, _raporSablonId, RaporTuru, _raporBolumTuru, SabloDosyasiOlustur());
            if (entity == null) return;
            _raporSablonId = entity.Id;

            using (var bll = new RaporBll())
            {
                var stream = ((Rapor)bll.Single(x => x.Id == entity.Id)).Dosya.ByteToStream();
                Tablo.RestoreLayoutFromStream(stream);
                Tablo.Focus();
            }
        }

        private byte[] SabloDosyasiOlustur()
        {
            var stream = new MemoryStream();
            Tablo.SaveLayoutToStream(stream);
            return stream.GetBuffer();
        }

        protected virtual void Listele()
        {
            Tablo.ExpandAllGroups();
        }

        protected virtual void ShowEditForm() { }

        protected virtual void BelgeHareketleri() { }

        protected virtual void Button_ItemClick(object sender, ItemClickEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            if (e.Item == btnGonder)
            {
                var link = (BarSubItemLink)e.Item.Links[0];
                link.Focus();
                link.OpenMenu();
                link.Item.ItemLinks[0].Focus();
            }
            else if (e.Item == btnStandarExcelDosyasi)
            {
                Tablo.TabloDisariAktar(DosyaTuru.ExcelStandart, e.Item.Caption, Text);
            }
            else if (e.Item == btnFormatliExcelDosyasi)
            {
                Tablo.TabloDisariAktar(DosyaTuru.ExcelFormatli, e.Item.Caption, Text);
            }
            else if (e.Item == btnExcelDosyasiFormatsiz)
            {
                Tablo.TabloDisariAktar(DosyaTuru.ExcelFormatsiz, e.Item.Caption, Text);
            }
            else if (e.Item == btnWordDosyasi)
            {
                Tablo.TabloDisariAktar(DosyaTuru.WordDosyasi, e.Item.Caption, Text);
            }
            else if (e.Item == btnPdfDosyasi)
            {
                Tablo.TabloDisariAktar(DosyaTuru.PdfDosyasi, e.Item.Caption, Text);
            }
            else if (e.Item == btnTxtDosyası)
            {
                Tablo.TabloDisariAktar(DosyaTuru.TxtDosyasi, e.Item.Caption, Text);
            }

            else if (e.Item == btnFiltrele)
            {
                FiltreSec();
            }

            else if (e.Item == btnKolonlar)
            {
                if (Tablo.CustomizationForm == null)
                {
                    Tablo.ShowCustomization();
                }
                else
                {
                    Tablo.HideCustomization();
                }
            }

            else if (e.Item == btnYazdir)
            {
                switch (RaporTuru)
                {
                    case KartTuru.GenelAmacliRapor:
                    case KartTuru.SinifRaporlari:
                    case KartTuru.UcretveOdemeRaporu:
                    case KartTuru.MesleklereGoreKayitRaporu:
                    case KartTuru.AylikKayitRaporu:
                    case KartTuru.UcretOrtalamalariRaporu:
                    case KartTuru.OdemeBelgeleriRaporu:
                        TablePrintingFunctions.Yazdir(Tablo, Tablo.ViewCaption, Subeler.Text, KayitSekilleri.Text, KayitDurumlari.Text, IptalDurumlari.Text);
                        break;

                    case KartTuru.HizmetAlimRaporu:
                        TablePrintingFunctions.Yazdir(Tablo, Tablo.ViewCaption, Subeler.Text, KayitSekilleri.Text, KayitDurumlari.Text, null, "Hizmet Türü", Hizmetler.Text, "Hizmet Alım Türü", HizmetAlimTuru.Text);
                        break;

                    case KartTuru.NetUcretRaporu:
                        TablePrintingFunctions.Yazdir(Tablo, Tablo.ViewCaption, Subeler.Text, KayitSekilleri.Text, KayitDurumlari.Text, IptalDurumlari.Text, "Hizmet Türü", Hizmetler.Text);
                        break;

                    case KartTuru.IndirimDagilimRaporu:
                        TablePrintingFunctions.Yazdir(Tablo, Tablo.ViewCaption, Subeler.Text, KayitSekilleri.Text, KayitDurumlari.Text, IptalDurumlari.Text, "İndirim Türü", Indirimler.Text);
                        break;

                    case KartTuru.GelirDagilimRaporu:
                        TablePrintingFunctions.Yazdir(Tablo, Tablo.ViewCaption, Subeler.Text, KayitSekilleri.Text, KayitDurumlari.Text, IptalDurumlari.Text, "Hesaplama Türü", HesaplamaSekli.Text);
                        break;

                    case KartTuru.TahsilatRaporu:
                    case KartTuru.OdemesiGecikenAlacaklarRaporu:
                        TablePrintingFunctions.Yazdir(Tablo, Tablo.ViewCaption, Subeler.Text, KayitSekilleri.Text, KayitDurumlari.Text, IptalDurumlari.Text, "Vade Aralığı", $"{IlkTarih.Text} - {SonTarih.Text}");
                        break;
                }
            }

            else if (e.Item == btnRaporSablonları)
            {
                RaporSablonSec();
            }

            else if (e.Item == btnKartAc)
            {
                ShowEditForm();
            }

            else if (e.Item == btnGruplamaPaneli)
            {
                Tablo.OptionsView.ShowGroupPanel = !Tablo.OptionsView.ShowGroupPanel;
            }

            else if (e.Item == btnTumGruplariGenislet)
            {
                Tablo.ExpandAllGroups();
            }

            else if (e.Item == btnTumGruplariDaralt)
            {
                Tablo.CollapseAllGroups();
            }

            else if (e.Item == btnTumDetaylariGenislet)
            {
                for (int i = 0; i < Tablo.DataRowCount; i++)
                {
                    Tablo.SetMasterRowExpanded(i, true);
                }
            }

            else if (e.Item == btnTumDetaylariDaralt)
            {
                for (int i = 0; i < Tablo.DataRowCount; i++)
                {
                    Tablo.CollapseAllDetails();
                }
            }

            else if (e.Item == btnBelgeHareketleri)
            {
                BelgeHareketleri();
            }

            else if (e.Item == btnCikis)
            {
                Close();
            }


            Cursor.Current = DefaultCursor;
        }

        private void Tablo_DoubleClick(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            ShowEditForm();
            Cursor.Current = DefaultCursor;
        }

        private void Control_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    Close();
                    break;

                case Keys.F7:
                    Subeler.Focus();
                    break;
            }
        }

        private void Tablo_MouseUp(object sender, MouseEventArgs e)
        {
            btnKartAc.Enabled = Tablo.DataRowCount > 0;
            btnTumGruplariGenislet.Enabled = Tablo.DataRowCount > 0;
            btnTumGruplariDaralt.Enabled = Tablo.DataRowCount > 0;
            btnTumDetaylariGenislet.Enabled = Tablo.DataRowCount > 0;
            btnTumDetaylariDaralt.Enabled = Tablo.DataRowCount > 0;
            btnBelgeHareketleri.Enabled = Tablo.DataRowCount > 0;

            e.SagMenuGoster(sagMenu);
        }

        private void Tablo_ColumnFilterChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Tablo.ActiveFilterString))
                _filtreId = 0;
        }

        private void Tablo_FilterEditorCreated(object sender, DevExpress.XtraGrid.Views.Base.FilterControlEventArgs e)
        {
            e.ShowFilterEditor = false;
            ShowEditForms<FiltreEditForm>.ShowDialogEditForms(KartTuru.Filtre, _filtreId, RaporTuru, Tablo.GridControl);
        }

        private void Tablo_CustomDrawFooterCell(object sender, FooterCellCustomDrawEventArgs e)
        {
            if (!Tablo.OptionsView.ShowFooter) return;
            if (e.Column.Summary.Count > 0 && e.Column.ColumnEdit != null)
                e.Appearance.TextOptions.HAlignment = e.Column.ColumnEdit.Appearance.HAlignment;
        }

        private void Tablo_CustomDrawRowFooterCell(object sender, FooterCellCustomDrawEventArgs e)
        {
            if (e.Column.Summary.Count > 0 && e.Column.ColumnEdit != null)
                e.Appearance.TextOptions.HAlignment = e.Column.ColumnEdit.Appearance.HAlignment;
        }

        protected virtual void Tablo_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e) { }

        protected virtual void Tablo_MasterRowGetChildList(object sender, MasterRowGetChildListEventArgs e) { }

        protected virtual void Tablo_MasterRowGetRelationName(object sender, MasterRowGetRelationNameEventArgs e) { }

        protected virtual void Tablo_MasterRowGetRelationCount(object sender, MasterRowGetRelationCountEventArgs e) { }

        private void BaseRapor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!AnaForm.KullaniciParametreleri.RaporlariOnayAlmadanKapat)
            {
                if (Messages.RaporKapatMesaj() != DialogResult.Yes)
                    e.Cancel = true;
            }
        }

        private void Control_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Listele();
            Tablo.Focus();
            Cursor.Current = DefaultCursor;
        }

    }
}
namespace Omega.Ots.UI.Win.Forms.DovizKurForms
{
    partial class DovizKurListForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DovizKurListForm));
            this.longNavigator = new Omega.Ots.UI.Win.UserControls.Navigators.LongNavigator();
            this.grid = new Omega.Ots.UI.Win.UserControls.Grid.MyGridControl();
            this.tablo = new Omega.Ots.UI.Win.UserControls.Grid.MyGridView();
            this.colId = new Omega.Ots.UI.Win.UserControls.Grid.MyGridColumn();
            this.colDovizId = new Omega.Ots.UI.Win.UserControls.Grid.MyGridColumn();
            this.colTarih = new Omega.Ots.UI.Win.UserControls.Grid.MyGridColumn();
            this.colDovizKodu = new Omega.Ots.UI.Win.UserControls.Grid.MyGridColumn();
            this.colDovizAdi = new Omega.Ots.UI.Win.UserControls.Grid.MyGridColumn();
            this.colTcmbKodu = new Omega.Ots.UI.Win.UserControls.Grid.MyGridColumn();
            this.colAlis = new Omega.Ots.UI.Win.UserControls.Grid.MyGridColumn();
            this.repositoryKur = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();
            this.colSatis = new Omega.Ots.UI.Win.UserControls.Grid.MyGridColumn();
            this.colEfektifAlis = new Omega.Ots.UI.Win.UserControls.Grid.MyGridColumn();
            this.colEfektifSatis = new Omega.Ots.UI.Win.UserControls.Grid.MyGridColumn();
            this.colOzelKur = new Omega.Ots.UI.Win.UserControls.Grid.MyGridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryKur)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl
            // 
            this.ribbonControl.ExpandCollapseItem.Id = 0;
            this.ribbonControl.MaxItemId = 98;
            // 
            // 
            // 
            this.ribbonControl.SearchEditItem.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
            this.ribbonControl.SearchEditItem.EditWidth = 150;
            this.ribbonControl.SearchEditItem.Id = -5000;
            this.ribbonControl.SearchEditItem.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.ribbonControl.Size = new System.Drawing.Size(1098, 109);
            this.ribbonControl.Toolbar.ShowCustomizeItem = false;
            // 
            // btnGonder
            // 
            this.btnGonder.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnGonder.ImageOptions.Image")));
            this.btnGonder.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnGonder.ImageOptions.LargeImage")));
            // 
            // barSubItem2
            // 
            this.barSubItem2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barSubItem2.ImageOptions.Image")));
            // 
            // barSubItem4
            // 
            this.barSubItem4.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barSubItem4.ImageOptions.Image")));
            // 
            // barSubItem5
            // 
            this.barSubItem5.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barSubItem5.ImageOptions.Image")));
            // 
            // barSubItem6
            // 
            this.barSubItem6.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barSubItem6.ImageOptions.Image")));
            // 
            // barSubItem7
            // 
            this.barSubItem7.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barSubItem7.ImageOptions.Image")));
            // 
            // btnYeniMakbuz
            // 
            this.btnYeniMakbuz.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnYeniMakbuz.ImageOptions.Image")));
            this.btnYeniMakbuz.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnYeniMakbuz.ImageOptions.LargeImage")));
            // 
            // btnYeniRapor
            // 
            this.btnYeniRapor.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnYeniRapor.ImageOptions.Image")));
            this.btnYeniRapor.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnYeniRapor.ImageOptions.LargeImage")));
            // 
            // btnOnTanimliRaporlar
            // 
            this.btnOnTanimliRaporlar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnOnTanimliRaporlar.ImageOptions.Image")));
            // 
            // longNavigator
            // 
            this.longNavigator.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.longNavigator.Location = new System.Drawing.Point(0, 394);
            this.longNavigator.Name = "longNavigator";
            this.longNavigator.Size = new System.Drawing.Size(1098, 24);
            this.longNavigator.TabIndex = 0;
            // 
            // grid
            // 
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Location = new System.Drawing.Point(0, 109);
            this.grid.MainView = this.tablo;
            this.grid.MenuManager = this.ribbonControl;
            this.grid.Name = "grid";
            this.grid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryKur});
            this.grid.Size = new System.Drawing.Size(1098, 285);
            this.grid.TabIndex = 2;
            this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.tablo});
            // 
            // tablo
            // 
            this.tablo.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.tablo.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Maroon;
            this.tablo.Appearance.FooterPanel.Options.UseFont = true;
            this.tablo.Appearance.FooterPanel.Options.UseForeColor = true;
            this.tablo.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Maroon;
            this.tablo.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.tablo.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.tablo.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tablo.Appearance.ViewCaption.ForeColor = System.Drawing.Color.Maroon;
            this.tablo.Appearance.ViewCaption.Options.UseForeColor = true;
            this.tablo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colDovizId,
            this.colTarih,
            this.colDovizKodu,
            this.colDovizAdi,
            this.colTcmbKodu,
            this.colAlis,
            this.colSatis,
            this.colEfektifAlis,
            this.colEfektifSatis,
            this.colOzelKur});
            this.tablo.GridControl = this.grid;
            this.tablo.Name = "tablo";
            this.tablo.OptionsMenu.EnableColumnMenu = false;
            this.tablo.OptionsMenu.EnableFooterMenu = false;
            this.tablo.OptionsMenu.EnableGroupPanelMenu = false;
            this.tablo.OptionsNavigation.EnterMoveNextColumn = true;
            this.tablo.OptionsPrint.AutoWidth = false;
            this.tablo.OptionsPrint.PrintFooter = false;
            this.tablo.OptionsPrint.PrintGroupFooter = false;
            this.tablo.OptionsView.ColumnAutoWidth = false;
            this.tablo.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.Button;
            this.tablo.OptionsView.RowAutoHeight = true;
            this.tablo.OptionsView.ShowAutoFilterRow = true;
            this.tablo.OptionsView.ShowGroupPanel = false;
            this.tablo.OptionsView.ShowViewCaption = true;
            this.tablo.StatusBarAciklama = null;
            this.tablo.StatusBarKisayol = null;
            this.tablo.StatusBarKisayolAciklama = null;
            this.tablo.ViewCaption = "Doviz Kur Listesi";
            // 
            // colId
            // 
            this.colId.Caption = "Id";
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            this.colId.OptionsColumn.AllowEdit = false;
            this.colId.OptionsColumn.ShowInCustomizationForm = false;
            this.colId.StatusBarAciklama = null;
            this.colId.StatusBarKisayol = null;
            this.colId.StatusBarKisayolAciklama = null;
            // 
            // colDovizId
            // 
            this.colDovizId.Caption = "DovizId";
            this.colDovizId.FieldName = "DovizId";
            this.colDovizId.Name = "colDovizId";
            this.colDovizId.OptionsColumn.AllowEdit = false;
            this.colDovizId.OptionsColumn.ShowInCustomizationForm = false;
            this.colDovizId.OptionsColumn.ShowInExpressionEditor = false;
            this.colDovizId.StatusBarAciklama = null;
            this.colDovizId.StatusBarKisayol = null;
            this.colDovizId.StatusBarKisayolAciklama = null;
            // 
            // colTarih
            // 
            this.colTarih.Caption = "Tarih";
            this.colTarih.FieldName = "Tarih";
            this.colTarih.Name = "colTarih";
            this.colTarih.OptionsColumn.AllowEdit = false;
            this.colTarih.StatusBarAciklama = null;
            this.colTarih.StatusBarKisayol = null;
            this.colTarih.StatusBarKisayolAciklama = null;
            this.colTarih.Visible = true;
            this.colTarih.VisibleIndex = 0;
            this.colTarih.Width = 100;
            // 
            // colDovizKodu
            // 
            this.colDovizKodu.Caption = "Doviz Kodu";
            this.colDovizKodu.FieldName = "DovizKodu";
            this.colDovizKodu.Name = "colDovizKodu";
            this.colDovizKodu.OptionsColumn.AllowEdit = false;
            this.colDovizKodu.StatusBarAciklama = null;
            this.colDovizKodu.StatusBarKisayol = null;
            this.colDovizKodu.StatusBarKisayolAciklama = null;
            this.colDovizKodu.Visible = true;
            this.colDovizKodu.VisibleIndex = 1;
            this.colDovizKodu.Width = 100;
            // 
            // colDovizAdi
            // 
            this.colDovizAdi.Caption = "Doviz Adı";
            this.colDovizAdi.FieldName = "DovizAdi";
            this.colDovizAdi.Name = "colDovizAdi";
            this.colDovizAdi.OptionsColumn.AllowEdit = false;
            this.colDovizAdi.StatusBarAciklama = null;
            this.colDovizAdi.StatusBarKisayol = null;
            this.colDovizAdi.StatusBarKisayolAciklama = null;
            this.colDovizAdi.Visible = true;
            this.colDovizAdi.VisibleIndex = 2;
            this.colDovizAdi.Width = 250;
            // 
            // colTcmbKodu
            // 
            this.colTcmbKodu.Caption = "Tcmb Kodu";
            this.colTcmbKodu.FieldName = "TcmbKodu";
            this.colTcmbKodu.Name = "colTcmbKodu";
            this.colTcmbKodu.OptionsColumn.AllowEdit = false;
            this.colTcmbKodu.StatusBarAciklama = null;
            this.colTcmbKodu.StatusBarKisayol = null;
            this.colTcmbKodu.StatusBarKisayolAciklama = null;
            this.colTcmbKodu.Visible = true;
            this.colTcmbKodu.VisibleIndex = 3;
            this.colTcmbKodu.Width = 100;
            // 
            // colAlis
            // 
            this.colAlis.Caption = "Alış";
            this.colAlis.ColumnEdit = this.repositoryKur;
            this.colAlis.FieldName = "Alis";
            this.colAlis.Name = "colAlis";
            this.colAlis.OptionsColumn.AllowEdit = false;
            this.colAlis.StatusBarAciklama = null;
            this.colAlis.StatusBarKisayol = null;
            this.colAlis.StatusBarKisayolAciklama = null;
            this.colAlis.Visible = true;
            this.colAlis.VisibleIndex = 4;
            this.colAlis.Width = 90;
            // 
            // repositoryKur
            // 
            this.repositoryKur.AutoHeight = false;
            this.repositoryKur.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryKur.DisplayFormat.FormatString = "n4";
            this.repositoryKur.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryKur.EditFormat.FormatString = "n4";
            this.repositoryKur.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryKur.Mask.EditMask = "n4";
            this.repositoryKur.Name = "repositoryKur";
            // 
            // colSatis
            // 
            this.colSatis.Caption = "Satış";
            this.colSatis.ColumnEdit = this.repositoryKur;
            this.colSatis.FieldName = "Satis";
            this.colSatis.Name = "colSatis";
            this.colSatis.OptionsColumn.AllowEdit = false;
            this.colSatis.StatusBarAciklama = null;
            this.colSatis.StatusBarKisayol = null;
            this.colSatis.StatusBarKisayolAciklama = null;
            this.colSatis.Visible = true;
            this.colSatis.VisibleIndex = 5;
            this.colSatis.Width = 90;
            // 
            // colEfektifAlis
            // 
            this.colEfektifAlis.Caption = "Efektif Alış";
            this.colEfektifAlis.ColumnEdit = this.repositoryKur;
            this.colEfektifAlis.FieldName = "EfektifAlis";
            this.colEfektifAlis.Name = "colEfektifAlis";
            this.colEfektifAlis.OptionsColumn.AllowEdit = false;
            this.colEfektifAlis.StatusBarAciklama = null;
            this.colEfektifAlis.StatusBarKisayol = null;
            this.colEfektifAlis.StatusBarKisayolAciklama = null;
            this.colEfektifAlis.Visible = true;
            this.colEfektifAlis.VisibleIndex = 6;
            this.colEfektifAlis.Width = 90;
            // 
            // colEfektifSatis
            // 
            this.colEfektifSatis.Caption = "Efektif Satış";
            this.colEfektifSatis.ColumnEdit = this.repositoryKur;
            this.colEfektifSatis.FieldName = "EfektifSatis";
            this.colEfektifSatis.Name = "colEfektifSatis";
            this.colEfektifSatis.OptionsColumn.AllowEdit = false;
            this.colEfektifSatis.StatusBarAciklama = null;
            this.colEfektifSatis.StatusBarKisayol = null;
            this.colEfektifSatis.StatusBarKisayolAciklama = null;
            this.colEfektifSatis.Visible = true;
            this.colEfektifSatis.VisibleIndex = 7;
            this.colEfektifSatis.Width = 90;
            // 
            // colOzelKur
            // 
            this.colOzelKur.Caption = "Özel Kur";
            this.colOzelKur.ColumnEdit = this.repositoryKur;
            this.colOzelKur.FieldName = "OzelKur";
            this.colOzelKur.Name = "colOzelKur";
            this.colOzelKur.OptionsColumn.AllowEdit = false;
            this.colOzelKur.StatusBarAciklama = null;
            this.colOzelKur.StatusBarKisayol = null;
            this.colOzelKur.StatusBarKisayolAciklama = null;
            this.colOzelKur.Visible = true;
            this.colOzelKur.VisibleIndex = 8;
            this.colOzelKur.Width = 90;
            // 
            // DovizKurListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1098, 442);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.longNavigator);
            this.IconOptions.ShowIcon = false;
            this.Name = "DovizKurListForm";
            this.Text = "Doviz Kur Listesi";
            this.Controls.SetChildIndex(this.ribbonControl, 0);
            this.Controls.SetChildIndex(this.longNavigator, 0);
            this.Controls.SetChildIndex(this.grid, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryKur)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UserControls.Navigators.LongNavigator longNavigator;
        private UserControls.Grid.MyGridControl grid;
        private UserControls.Grid.MyGridView tablo;
        private UserControls.Grid.MyGridColumn colId;
        private UserControls.Grid.MyGridColumn colDovizId;
        private UserControls.Grid.MyGridColumn colTarih;
        private UserControls.Grid.MyGridColumn colDovizKodu;
        private UserControls.Grid.MyGridColumn colDovizAdi;
        private UserControls.Grid.MyGridColumn colTcmbKodu;
        private UserControls.Grid.MyGridColumn colAlis;
        private UserControls.Grid.MyGridColumn colSatis;
        private UserControls.Grid.MyGridColumn colEfektifAlis;
        private UserControls.Grid.MyGridColumn colEfektifSatis;
        private UserControls.Grid.MyGridColumn colOzelKur;
        private DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit repositoryKur;
    }
}
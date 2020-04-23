using System;
using System.Windows.Forms;
using DevExpress.Utils.Extensions;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraVerticalGrid;
using Omega.Ots.Bll.Interfaces;
using Omega.Ots.Common.Enums;
using Omega.Ots.Common.Message;
using Omega.Ots.Model.Entities.Base;
using Omega.Ots.Model.Entities.Base.Interfaces;
using Omega.Ots.UI.Win.Functions;
using Omega.Ots.UI.Win.Interfaces;
using Omega.Ots.UI.Win.UserControls.Controls;
using Omega.Ots.UI.Win.UserControls.Grid;

namespace Omega.Ots.UI.Win.Forms.BaseForms
{
    public partial class BaseEditForm : RibbonForm
    {
        private bool _formSablonKayitEdilecek;

        #region Varaibles
        protected IBaseBll Bll;
        protected KartTuru kartTuru;
        protected BaseEntity oldEntity;
        protected BaseEntity currentEntity;
        protected MyDataLayoutControl dataLayoutControl;
        protected MyDataLayoutControl[] dataLayoutControls;
        protected bool IsLoaded;
        protected bool KayitSonrasiFormuKapat = true;
        protected BarItem[] ShowItems;
        protected BarItem[] HideItems;

        protected internal IslemTuru BaseIslemTuru;
        protected internal long Id;
        protected internal DateTime Tarih;
        protected internal bool RefreshYapilacak;
        protected bool FarkliSubeIslemi;
        #endregion

        public BaseEditForm()
        {
            InitializeComponent();
        }

        protected void EventsLoad()
        {
            //Button Events
            foreach (BarItem button in ribbonControl.Items)
            {
                button.ItemClick += Button_ItemClick;
            }
            //Form Events
            LocationChanged += BaseEditForm_LocationChanged;
            SizeChanged += BaseEditForm_SizeChanged;
            Load += BaseEditForm_Load;
            FormClosing += BaseEditForm_FormClosing;
            Shown += BaseEditForm_Shown;

            void ControlEvents(Control control)
            {
                control.KeyDown += Control_KeyDown;
                control.GotFocus += Control_GotFocus;
                control.Leave += Control_Leave;
                control.Enter += Control_Enter;
                switch (control)
                {
                    case FilterControl edt:
                        edt.FilterChanged += Control_EditValueChanged;
                        break;
                    case ComboBoxEdit edt:
                        edt.EditValueChanged += Control_EditValueChanged;
                        edt.SelectedValueChanged += Control_SelectedValueChanged;

                        break;
                    case MyButtonEdit edt:
                        edt.IdChanged += Control_IdChanged;
                        edt.EnabledChange += Control_EnabledChange;
                        edt.ButtonClick += Control_ButtonClick;
                        edt.DoubleClick += Control_DoubleClick;
                        break;
                    case BaseEdit edt:
                        edt.EditValueChanged += Control_EditValueChanged;
                        break;
                    case TabPane tab:
                        tab.SelectedPageChanged += Control_SelectedPageChanged;
                        break;
                    case PropertyGridControl pGrd:
                        pGrd.CellValueChanged += Control_CellValueChanged;
                        pGrd.FocusedRowChanged += Control_FocusedRowChanged;
                        break;
                    case MyGridControl grd:
                        grd.MainView.GotFocus += Control_GotFocus;
                        break;
                }
            }
            if (dataLayoutControls == null)
            {
                if (dataLayoutControl == null) return;
                foreach (Control ctrl in dataLayoutControl.Controls)
                {
                    ControlEvents(ctrl);
                }
            }
            else
            {
                foreach (var layout in dataLayoutControls)
                {
                    foreach (Control ctrl in layout.Controls)
                    {
                        ControlEvents(ctrl);
                    }
                }
            }

        }

        ////////////////////////////////////////////////////////////////////////Fonksiyonlar/////////////////////////////////////////////////7
        private void ButonGizleGoster()
        {
            ShowItems?.ForEach(x => x.Visibility = BarItemVisibility.Always);
            HideItems?.ForEach(x => x.Visibility = BarItemVisibility.Never);
            //Güncellenecek
        }

        private bool Kaydet(bool kapanis)
        {
            bool KayitIslemi()
            {
                Cursor.Current = Cursors.WaitCursor;

                switch (BaseIslemTuru)
                {
                    case IslemTuru.EntityInsert:
                        if (EntityInsert())
                            return KayitSonrasiIslemler();
                        break;

                    case IslemTuru.EntityUpdate:
                        if (EntityUpdate())
                            return KayitSonrasiIslemler();
                        break;

                }
                bool KayitSonrasiIslemler()
                {
                    oldEntity = currentEntity;
                    RefreshYapilacak = true;
                    ButonEnabledDurumu();
                    if (KayitSonrasiFormuKapat)
                    {
                        Close();
                    }
                    else
                    {
                        BaseIslemTuru = BaseIslemTuru == IslemTuru.EntityInsert ? IslemTuru.EntityUpdate : BaseIslemTuru;
                    }
                    return true;
                }
                return false;
            }


            var result = kapanis ? Messages.KapanisMesaj() : Messages.KayitMesaj();
            switch (result)
            {
                case DialogResult.Yes:
                    return KayitIslemi();

                case System.Windows.Forms.DialogResult.No:
                    if (kapanis)
                    {
                        btnKaydet.Enabled = false;
                    }
                    return true;

                case DialogResult.Cancel:
                    return false;

            }

            return false;
        }

        private void GeriAl()
        {
            if (Messages.HayirSeciliEvetHayir("Yapılan değişiklikler geri alınacaktır.Onaylıyor musunuz?", "Geri Al Onay") != DialogResult.Yes) return;
            if (BaseIslemTuru == IslemTuru.EntityUpdate)
                Yukle();
            else
                Close();
        }

        private void FarkliKaydet()
        {
            if (Messages.EvetSeciliEvetHayir("Bu Filtre Referans Alınarak Yeni Bir Filtre Oluşturulacaktır. Onaylıyormusunuz?", "Kayıt Onay") != DialogResult.Yes) return;
            BaseIslemTuru = IslemTuru.EntityInsert;
            Yukle();

            if (Kaydet(true))
                Close();
        }

        private void SablonYukle()
        {
            Name.FormSablonYukle(this);
        }

        public void SablonKaydet()
        {
            if (_formSablonKayitEdilecek)
                Name.FormSablonKaydet(Left, Top, Width, Height, WindowState);
        }

        protected virtual void SecimYap(object sender) { }

        protected virtual void FiltreUygula() { }

        protected virtual void TaksitOlustur() { }

        protected virtual bool EntityUpdate()
        {
            return ((IBaseGenelBll)Bll).Update(oldEntity, currentEntity);
        }

        protected virtual bool EntityInsert()
        {
            return ((IBaseGenelBll)Bll).Insert(currentEntity);
        }

        protected virtual void EntityDelete()
        {
            if (!((IBaseCommonBll)Bll).Delete(oldEntity)) return;
            RefreshYapilacak = true;
            Close();
        }

        protected virtual void BaskiOnIzleme() { }

        protected virtual void Yazdir() { }

        protected virtual void NesneyiKontrollereBagla() { }

        protected virtual void GuncelNesneOlustur() { }

        protected virtual void TabloYukle() { }

        protected virtual void SifreSifirla() { }

        protected internal virtual void Yukle() { }

        protected internal virtual void Giris() { }

        protected virtual void TcmbKurlariniIndir() { }

        protected virtual void SonKurlariKaydet() { }

        protected internal virtual IBaseEntity ReturnEntity() { return null; }

        protected internal virtual void ButonEnabledDurumu()
        {
            if (!IsLoaded) return;
            GeneralFunctions.ButtonEnabledDurumu(btnYeni, btnKaydet, btnGeriAl, btnSil, oldEntity, currentEntity);
        }

        protected virtual void BagliTabloYukle() { }

        protected virtual bool BagliTabloKaydet() { return false; }

        protected virtual bool BagliTabloHataliGirisKontrol() { return false; }


        //////////////////////////////////////////////////////////////////////////Eventler////////////////////////////////////////////////////////////////////
        private void Control_Leave(object sender, EventArgs e)
        {
            statusBarKisayol.Visibility = BarItemVisibility.Never;
            statusBarKisayolAciklama.Visibility = BarItemVisibility.Never;
        }
        protected virtual void Control_Enter(object sender, EventArgs e) { }


        private void Control_GotFocus(object sender, EventArgs e)
        {
            var type = sender.GetType();
            if (type == typeof(MyButtonEdit) || type == typeof(MyGridView) || type == typeof(MyPictureEdit) || type == typeof(MyComboBoxEdit) || type == typeof(MyDateEdit) || type == typeof(MyCalcEdit) || type == typeof(MyColorPickEdit))
            {
                statusBarKisayol.Visibility = BarItemVisibility.Always;
                statusBarKisayolAciklama.Visibility = BarItemVisibility.Always;

                statusBarAciklama.Caption = ((IStatusBarAciklama)sender).StatusBarAciklama;
                statusBarKisayol.Caption = ((IStatusBarKisayol)sender).StatusBarKisayol;
                statusBarKisayolAciklama.Caption = ((IStatusBarKisayol)sender).StatusBarKisayolAciklama;
            }
            else if (sender is IStatusBarAciklama ctrl)
            {
                statusBarAciklama.Caption = ctrl.StatusBarAciklama;
            }
        }

        private void BaseEditForm_SizeChanged(object sender, EventArgs e)
        {
            _formSablonKayitEdilecek = true;
        }

        private void BaseEditForm_LocationChanged(object sender, EventArgs e)
        {
            _formSablonKayitEdilecek = true;
        }

        protected virtual void BaseEditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SablonKaydet();
            if (btnKaydet.Visibility == BarItemVisibility.Never || !btnKaydet.Enabled) return;

            if (!Kaydet(true))
                e.Cancel = true;
        }

        protected virtual void BaseEditForm_Shown(object sender, EventArgs e) { }

        protected virtual void Control_EditValueChanged(object sender, EventArgs e)
        {
            if (!IsLoaded) return;
            GuncelNesneOlustur();
        }

        private void Control_DoubleClick(object sender, EventArgs e)
        {
            SecimYap(sender);
        }

        private void Control_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            SecimYap(sender);
        }

        protected virtual void Control_IdChanged(object sender, IdChangedEventArgs e)
        {
            if (!IsLoaded) return;
            GuncelNesneOlustur();
        }

        protected virtual void Control_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
            if (sender is MyButtonEdit edt)
            {
                switch (e.KeyCode)
                {
                    //kontrol+shift +delete basılırsa aynı anda bu işlemleri yap demek
                    case Keys.Delete when e.Control && e.Shift:
                        edt.Id = null;
                        edt.EditValue = null;
                        break;
                    case Keys.F4:
                    case Keys.Down when e.Modifiers == Keys.Alt:
                        SecimYap(edt);
                        break;
                }
            }
        }

        private void BaseEditForm_Load(object sender, EventArgs e)
        {
            IsLoaded = true;
            GuncelNesneOlustur();
            SablonYukle();
            ButonGizleGoster();

            if (FarkliSubeIslemi)
                Messages.UyariMesaji("İşlem Yapılan Kart Çalışılan Şube Veya Dönemde Olmadığı İçin Yapılan Değişiklikler Kayıt Edilemez.");
        }

        protected virtual void Button_ItemClick(object sender, ItemClickEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (e.Item == btnYeni)
            {
                if (!kartTuru.YetkiKontrolu(YetkiTuru.Ekleyebilir)) return;
                BaseIslemTuru = IslemTuru.EntityInsert;
                Yukle();
            }
            else if (e.Item == btnKaydet)
            {
                Kaydet(false);
            }
            else if (e.Item == btnFarkliKaydet)
            {
                if (!kartTuru.YetkiKontrolu(YetkiTuru.Ekleyebilir)) return;
                FarkliKaydet();
            }
            else if (e.Item == btnGeriAl)
            {
                GeriAl();
            }
            else if (e.Item == btnSil)
            {
                if (!kartTuru.YetkiKontrolu(YetkiTuru.Silebilir)) return;
                EntityDelete();
            }
            else if (e.Item == btnUygula)
            {
                FiltreUygula();
            }
            else if (e.Item == btnTaksitOlustur)
            {
                TaksitOlustur();
            }
            else if (e.Item == btnYazdir)
            {
                Yazdir();
            }
            else if (e.Item == btnBaskiOnizleme)
            {
                BaskiOnIzleme();
            }
            else if (e.Item == btnSifreSifirla)
            {
                SifreSifirla();
            }
            else if (e.Item == btnCikis)
            {
                Close();
            }
            else if (e.Item == btnGiris)
            {
                Giris();
            }
            else if (e.Item == btnTcmbKurIndir)
            {
                TcmbKurlariniIndir();
            }
            else if (e.Item == btnSonKurlariKaydet)
            {
                SonKurlariKaydet();
            }
            Cursor.Current = DefaultCursor;
        }

        protected virtual void Control_SelectedValueChanged(object sender, EventArgs e) { }

        protected virtual void Control_EnabledChange(object sender, EventArgs e) { }

        protected virtual void Control_SelectedPageChanged(object sender, SelectedPageChangedEventArgs e) { }

        protected virtual void Control_CellValueChanged(object sender, DevExpress.XtraVerticalGrid.Events.CellValueChangedEventArgs e) { }

        protected virtual void Control_FocusedRowChanged(object sender, DevExpress.XtraVerticalGrid.Events.FocusedRowChangedEventArgs e) { }

    }
}
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using Omega.Ots.Common.Enums;
using System.Windows.Forms;
using System.Security;
using Omega.Ots.Bll.General;
using Omega.Ots.Common.Message;
using Omega.Ots.UI.Win.Functions;
using Omega.Ots.Model.Entities.Base;
using Omega.Ots.Data.Context;
using Omega.Ots.Model.Entities;
using Omega.Ots.UI.Win.GeneralForms;
using Omega.Ots.UI.Yonetim.Show;
using Omega.Ots.UI.Win.Show;
using Omega.Ots.UI.Win.Forms.SubeForms;
using Omega.Ots.UI.Win.Forms.DonemForms;
using Omega.Ots.UI.Win.Forms.KullaniciForms;

namespace Omega.Ots.UI.Yonetim.GeneralForms
{
    public partial class AnaForm : RibbonForm
    {
        #region Variables
        private readonly string _server;
        private readonly SecureString _kullaniciAdi;
        private readonly SecureString _sifre;
        private readonly YetkilendirmeTuru _yetkilendirmeTuru;
        private readonly KurumBll _bll;

        #endregion

        public AnaForm(params object[] prm)
        {
            InitializeComponent();
            longNavigator.Navigator.NavigatableControl = tablo.GridControl;
            EventsLoad();
            ButtonEnabledDurumu();

            _server = prm[0].ToString();
            _kullaniciAdi = (SecureString)prm[1];
            _sifre = (SecureString)prm[2];
            _yetkilendirmeTuru = (YetkilendirmeTuru)prm[3];
            _bll = new KurumBll();
        }

        private void EventsLoad()
        {
            //Button Events
            foreach (BarItem button in ribbonControl.Items)
            {
                button.ItemClick += Button_ItemClick;
            }

            //Table Events
            tablo.DoubleClick += Tablo_DoubleClick;
            tablo.KeyDown += Tablo_KeyDown;
            tablo.MouseUp += Tablo_MouseUp;
            tablo.RowCountChanged += Tablo_RowCountChanged;

            //Forms Evnts
            FormClosing += AnaForm_FormClosing;
            Load += AnaForm_Load;
        }

        protected internal void Listele()
        {
            tablo.GridControl.DataSource = _bll.List(null);
        }

        protected virtual void ShowEditForm(long id)
        {
            Functions.YonetimGeneralFunctions.CreateConnectionString("OmegaOtsYonetim", _server, _kullaniciAdi, _sifre, _yetkilendirmeTuru);
            var result = YonetimShowEditForms<KurumEditForm>.ShowDialogEditForms(id, _server, _kullaniciAdi, _sifre, _yetkilendirmeTuru);
            if (result <= 0) return;
            Listele();
            tablo.RowFocus("Id", result);
        }

        private void ButtonEnabledDurumu()
        {
            foreach (BarItem button in ribbonControl.Items)
            {
                if (!(button is BarButtonItem item)) continue;
                if (item != btnYeni)
                    item.Enabled = tablo.DataRowCount > 0;
            }
        }

        private void EntityDelete(BaseEntity entity)
        {
            Functions.YonetimGeneralFunctions.CreateConnectionString(entity.Kod, _server, _kullaniciAdi, _sifre, _yetkilendirmeTuru);
            if (!Functions.YonetimGeneralFunctions.DeleteDatabase<OgrenciTakipYonetimContext>()) return;

            Functions.YonetimGeneralFunctions.CreateConnectionString("OmegaOtsYonetim", _server, _kullaniciAdi, _sifre, _yetkilendirmeTuru);
            _bll.Delete(entity);
            tablo.DeleteSelectedRows();
            tablo.RowFocus(tablo.FocusedRowHandle);
        }

        private void Button_ItemClick(object sender, ItemClickEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (e.Item == btnYeni || e.Item == btnDuzelt)
            {
                if (e.Item == btnYeni)
                {
                    ShowEditForm(-1);
                }

                else if (e.Item == btnDuzelt)
                {
                    ShowEditForm(tablo.GetRowId());
                }
            }

            else
            {
                var entity = tablo.GetRow<Kurum>();
                if (entity == null) return;
                Functions.YonetimGeneralFunctions.CreateConnectionString(entity.Kod, _server, _kullaniciAdi, _sifre, _yetkilendirmeTuru);

                if (e.Item == btnSil)
                {
                    EntityDelete(entity);
                }

                else if (e.Item == btnEmailParametreleri)
                {
                    Win.Show.ShowEditForms<EmailParametreEditForm>.ShowDialogEditForms();
                }

                else if (e.Item == btnSubeKartlari)
                {
                    ShowListForms<SubeListForm>.ShowDialogListForm();
                }

                else if (e.Item == btnDonemKartlari)
                {
                    ShowListForms<DonemListForm>.ShowDialogListForm();
                }

                else if (e.Item == btnKurumBilgileri)
                {
                    Win.Show.ShowEditForms<KurumBilgileriEditForm>.ShowDialogEditForms(null, entity.Kod, entity.KurumAdi);
                }

                else if (e.Item == btnRolKartlari)
                {
                    ShowListForms<RolListForm>.ShowDialogListForm();
                }

                else if (e.Item == btnKullaniciKartlari)
                {
                    ShowListForms<KullaniciListForm>.ShowDialogListForm();
                }
                else if (e.Item == btnKullaniciBirimYetkileri)
                {
                    Win.Show.ShowEditForms<KullaniciBirimYetkileriEditForm>.ShowDialogEditForms();
                }
            }

            Cursor.Current = DefaultCursor;
        }

        private void Tablo_DoubleClick(object sender, System.EventArgs e)
        {
            if (tablo.FocusedRowHandle < 0) return;
            ShowEditForm(tablo.GetRowId());
        }

        private void Tablo_KeyDown(object sender, KeyEventArgs e)
        {
            if (tablo.FocusedRowHandle < 0) return;

            switch (e.KeyCode)
            {
                case Keys.Enter:
                    ShowEditForm(tablo.GetRowId());
                    break;
                case Keys.Escape:
                    Close();
                    break;
            }
        }

        private void Tablo_MouseUp(object sender, MouseEventArgs e)
        {
            e.SagMenuGoster(sagMenu);
        }

        private void Tablo_RowCountChanged(object sender, System.EventArgs e)
        {
            ButtonEnabledDurumu();
        }

        private void AnaForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Messages.HayirSeciliEvetHayir("Programdan Çıkmak İstiyor Musunuz?", "Çıkış Onay") == DialogResult.Yes)
                Application.ExitThread();
            else
                e.Cancel = true;
        }

        private void AnaForm_Load(object sender, System.EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Listele();
            tablo.Focus();
            Cursor.Current = Cursors.Default;
        }
    }
}
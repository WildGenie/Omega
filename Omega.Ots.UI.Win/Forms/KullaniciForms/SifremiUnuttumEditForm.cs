using DevExpress.XtraBars;
using Omega.Ots.Bll.Functions;
using Omega.Ots.Bll.General;
using Omega.Ots.Common.Message;
using Omega.Ots.Model.Dto;
using Omega.Ots.Model.Entities;
using Omega.Ots.UI.Win.Forms.BaseForms;
using Omega.Ots.UI.Win.Functions;
using System.Windows.Forms;

namespace Omega.Ots.UI.Win.Forms.KullaniciForms
{
    public partial class SifremiUnuttumEditForm : BaseEditForm
    {
        #region Variables
        private readonly string _kullaniciAdi;
        #endregion

        public SifremiUnuttumEditForm(params object[] prm)
        {
            InitializeComponent();

            dataLayoutControl = myDataLayoutControl;
            Bll = new KullaniciBll(myDataLayoutControl);
            HideItems = new BarItem[] { btnYeni, btnKaydet, btnGeriAl, btnSil, };
            ShowItems = new BarItem[] { btnSifreSifirla };
            EventsLoad();

            _kullaniciAdi = prm[0].ToString();
        }

        protected internal override void Yukle()
        {
            txtKullaniciAdi.Text = _kullaniciAdi;
        }

        protected override void SifreSifirla()
        {
            if (Messages.EmailGonderimOnayı() != DialogResult.Yes) return;

            var entity = ((KullaniciBll)Bll).SingleDetail(x => x.Kod == txtKullaniciAdi.Text).EntityConvert<KullaniciS>();
            if (entity == null)
            {
                Messages.HataMesaji("Veritabanında Kayıtlı Böyle Bir Kullanıcı Bulunmamaktadır.");
                return;
            }

            if (txtAdi.Text == entity.Adi && txtSoyadi.Text == entity.Soyadi && txtEmail.Text == entity.Email && txtGizliKelime.Text.Md5Sifrele() == entity.GizliKelime)
            {
                var result = Functions.GeneralFunctions.SifreUret();

                var currentEntity = new Kullanici
                {
                    Id = entity.Id,
                    Kod = entity.Kod,
                    Adi = entity.Adi,
                    Soyadi = entity.Soyadi,
                    Email = entity.Email,
                    RolId = entity.RolId,
                    Aciklama = entity.Aciklama,
                    Durum = entity.Durum,
                    Sifre = result.sifre,
                    GizliKelime = result.gizliKelime
                };

                if (!((KullaniciBll)Bll).Update(entity, currentEntity)) return;

                var sonuc = txtKullaniciAdi.Text.SifreMailiGonder(entity.RolAdi, entity.Email, result.secureSifre, result.secureGizliKelime);

                if (sonuc)
                {
                    Messages.BilgiMesaji("Şifre Sıfırlama İşlemi Başarılı Bir Şekilde Geçekleşti.");
                    Close();
                }

                else
                {
                    Messages.HataMesaji("Şifre Sıfırlama İşlemi Başarılı Bir Şekilde Gerçekleşti. Anca Email Gönderilemedi. Lütfen Tekar Deneyiniz.");
                }
            }

            else
            {
                Messages.HataMesaji("Girilen Bilgiler Mevcut Bilgilerle Uyuşmuyor. Lütfen Kontrol Edip Tekrar Deneyiniz.");
            }
        }

    }
}
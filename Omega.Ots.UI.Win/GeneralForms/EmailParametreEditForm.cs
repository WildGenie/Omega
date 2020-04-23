using DevExpress.XtraBars;
using Omega.Ots.Bll.Functions;
using Omega.Ots.Bll.General;
using Omega.Ots.Common.Enums;
using Omega.Ots.Common.Functions;
using Omega.Ots.Model.Entities;
using Omega.Ots.UI.Win.Forms.BaseForms;
using Omega.Ots.UI.Win.Functions;

namespace Omega.Ots.UI.Win.GeneralForms
{
    public partial class EmailParametreEditForm : BaseEditForm
    {
        public EmailParametreEditForm()
        {
            InitializeComponent();

            dataLayoutControl = myDataLayoutControl;
            Bll = new MailParametreBll(myDataLayoutControl);
            HideItems = new BarItem[] { btnYeni, btnSil };
            txtSslKullan.Properties.Items.AddRange(EnumFunctions.GetEnumDescriptionList<EvetHayir>());
            EventsLoad();
        }

        protected internal override void Yukle()
        {
            oldEntity = ((MailParametreBll)Bll).Single(null) ?? new MailParametre();
            ((MailParametre)oldEntity).Sifre = "Bu Email Şifresidir.".Encrypt(oldEntity.Id + oldEntity.Kod);

            BaseIslemTuru = oldEntity.Id == 0 ? IslemTuru.EntityInsert : IslemTuru.EntityUpdate;
            NesneyiKontrollereBagla();
            if (BaseIslemTuru != IslemTuru.EntityInsert) return;
            Id = BaseIslemTuru.IdOlustur(oldEntity);
            txtKod.Text = "Email";
            txtEmail.Focus();
        }

        protected override void NesneyiKontrollereBagla()
        {
            var entity = (MailParametre)oldEntity;

            Id = entity.Id;
            txtKod.Text = entity.Kod;
            txtEmail.Text = entity.Email;
            txtSifre.Text = BaseIslemTuru == IslemTuru.EntityInsert ? null : entity.Sifre.Decrypt(entity.Id + entity.Kod);
            txtPortNo.Value = entity.PortNo;
            txtHost.Text = entity.Host;
            txtSslKullan.SelectedItem = entity.SslKullan.ToName();
        }

        protected override void GuncelNesneOlustur()
        {
            currentEntity = new MailParametre
            {
                Id = Id,
                Kod = txtKod.Text,
                Email = txtEmail.Text,
                Sifre = string.IsNullOrWhiteSpace(txtSifre.Text) ? null : txtSifre.Text.Encrypt(Id + txtKod.Text),
                PortNo = (int)txtPortNo.Value,
                Host = txtHost.Text,
                SslKullan = txtSslKullan.Text.GetEnum<EvetHayir>()
            };

            ButonEnabledDurumu();
        }
    }
}
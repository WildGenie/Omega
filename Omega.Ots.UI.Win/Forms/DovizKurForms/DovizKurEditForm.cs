using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using Omega.Ots.Bll.General;
using Omega.Ots.Common.Enums;
using Omega.Ots.Common.Functions;
using Omega.Ots.Common.Message;
using Omega.Ots.Model.Dto;
using Omega.Ots.Model.Entities;
using Omega.Ots.UI.Win.Forms.BaseForms;
using Omega.Ots.UI.Win.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Omega.Ots.UI.Win.Forms.DovizKurForms
{
    public partial class DovizKurEditForm : BaseEditForm
    {
        public DovizKurEditForm()
        {
            InitializeComponent();
            txtKod.DateTime = txtTarih.DateTime = DateTime.Now.Date;
            dataLayoutControl = myDataLayoutControl;
            Bll = new DovizKurBll(myDataLayoutControl);
            kartTuru = KartTuru.DovizKur;
            EventsLoad();
        }

        public DovizKurEditForm(params object[] prm) : this()
        {
            string kayitTuru = (string)prm[0];
            if (kayitTuru == "OtomatikKurKaydet")
            {
                panelControl1.Visible = true;
                dataLayoutControl.Visible = false;
                panelControl1.BringToFront();
                dataLayoutControl.SendToBack();
                ShowItems = new BarItem[] { btnTcmbKurIndir, btnSonKurlariKaydet };
                HideItems = new BarItem[] { btnYeni, btnSil, btnKaydet, btnGeriAl };
            }
        }

        protected internal override void Yukle()
        {
            oldEntity = BaseIslemTuru == IslemTuru.EntityInsert ? new DovizKurS() : ((DovizKurBll)Bll).Single(FilterFunctions.Filter<DovizKur>(Id));
            NesneyiKontrollereBagla();

            if (BaseIslemTuru != IslemTuru.EntityInsert) return;
            Id = BaseIslemTuru.IdOlustur(oldEntity);
            txtDoviz.Focus();
        }
        protected override void NesneyiKontrollereBagla()
        {
            var entity = (DovizKurS)oldEntity;

            txtKod.DateTime = entity.Tarih;
            txtDoviz.Id = entity.DovizId;
            txtDoviz.Text = entity.DovizAdi;
            txtAlis.Value = entity.Alis;
            txtSatis.Value = entity.Satis;
            txtEfektifAlis.Value = entity.EfektifAlis;
            txtEfektifSatis.Value = entity.EfektifSatis;
            txtOzelKur.Value = entity.OzelKur;
        }
        protected override void GuncelNesneOlustur()
        {
            string tarihKod = String.Format("{0:yyyy-MM-dd}", txtKod.DateTime.Date);
            currentEntity = new DovizKur
            {
                Id = Id,
                Kod = tarihKod,
                Tarih = txtKod.DateTime.Date,
                DovizId = Convert.ToInt64(txtDoviz.Id),
                Alis = txtAlis.Value,
                Satis = txtSatis.Value,
                EfektifAlis = txtEfektifAlis.Value,
                EfektifSatis = txtEfektifSatis.Value,
                OzelKur = txtOzelKur.Value
            };
            ButonEnabledDurumu();
        }
        protected override bool EntityInsert()
        {
            Int64 _dovizId = Convert.ToInt64(txtDoviz.Id);
            return ((DovizKurBll)Bll).Insert(currentEntity, x => x.Tarih == txtKod.DateTime.Date && x.DovizId == _dovizId);
        }
        protected override bool EntityUpdate()
        {
            Int64 _dovizId = Convert.ToInt64(txtDoviz.Id);
            return ((DovizKurBll)Bll).Update(oldEntity, currentEntity, x => x.Tarih == txtKod.DateTime.Date && x.DovizId == _dovizId);
        }
        protected override void SecimYap(object sender)
        {
            if (!(sender is ButtonEdit)) return;
            using (var sec = new SelectFunctions())
                if (sender == txtDoviz)
                    sec.Sec(txtDoviz);
        }
        protected override void Control_EnabledChange(object sender, EventArgs e)
        {
            if (sender != txtDoviz) return;
            txtDoviz.ControlEnabledChange(txtAlis);
            txtDoviz.ControlEnabledChange(txtSatis);
            txtDoviz.ControlEnabledChange(txtEfektifAlis);
            txtDoviz.ControlEnabledChange(txtEfektifSatis);
            txtDoviz.ControlEnabledChange(txtOzelKur);
        }
        protected override void TcmbKurlariniIndir()
        {
            txtKod.DateTime = txtTarih.DateTime;
            using (var bllDovizKur = new DovizKurBll())
            {
                var listDovizKuru = bllDovizKur.List(x => x.Tarih == txtKod.DateTime.Date).OrderByDescending(x => x.Id).ToList();
                if (listDovizKuru.Count > 0)
                {
                    Messages.HataMesaji($"Bu Tarihe ({String.Format("{0:dd.MM.yyyy}", txtKod.DateTime.Date)}) Daha Önce Kur Girilmiş, Kurları Otomatik Almak İçin Bu Kurları Silmelisiniz .");
                    return;
                }
                using (var bllDoviz = new DovizBll())
                {
                    var listDovizKodu = bllDoviz.List(x => x.TcmbDovizKodu >= 0 && x.Durum == true).ToList();
                    Dictionary<string, Currency> gunlukDovizKur = GetCurrencyRates.GetCurrencyRate(txtKod.DateTime.Date);
                    foreach (var item in listDovizKodu)
                    {
                        Doviz entity = ((Doviz)item);
                        if (entity.TcmbDovizKodu != 0 && gunlukDovizKur.Count > 0)
                        {
                            Id = BaseIslemTuru.IdOlustur(oldEntity);
                            txtDoviz.Id = entity.Id;
                            txtDoviz.Text = entity.DovizAdi;

                            Currency dovizKur = gunlukDovizKur[entity.TcmbDovizKodu.ToName()];
                            txtAlis.EditValue = dovizKur.ForexBuying;
                            txtSatis.EditValue = dovizKur.ForexSelling;
                            txtEfektifAlis.EditValue = dovizKur.BanknoteBuying;
                            txtEfektifSatis.EditValue = dovizKur.BanknoteSelling;

                            ((DovizKurBll)Bll).Insert(currentEntity, x => x.Tarih == txtKod.DateTime.Date && x.DovizId == entity.Id);
                        }
                    }
                    btnKaydet.Visibility = BarItemVisibility.Never;
                    KayitSonrasiFormuKapat = true;
                    RefreshYapilacak = true;
                    Close();
                }
            }
        }

        protected override void SonKurlariKaydet()
        {
            txtKod.DateTime = txtTarih.DateTime;
            using (var bllDovizKur = new DovizKurBll())
            {
                var listDovizKuru = bllDovizKur.List(x => x.Tarih == txtKod.DateTime.Date).OrderByDescending(x => x.Id).ToList();
                if (listDovizKuru.Count > 0)
                {
                    Messages.HataMesaji($"Bu Tarihe ({txtKod.Text}) Daha Önce Kur Girilmiş, Kurları Otomatik Almak İçin Bu Kurları Silmelisiniz .");
                    return;
                }
            }

            using (var bllDovizKur = new DovizKurBll())
            {
                var kurGirilenSonGun = ((DovizKurL)bllDovizKur.List(null).OrderByDescending(x => x.Id).FirstOrDefault());
                if (Messages.EvetSeciliEvetHayir($"En Son Girilen Kur {String.Format("{0:dd.MM.yyyy}", kurGirilenSonGun.Tarih)} Tarihine Girilmiştir. Bu Kurlar Kopyalansın mı ?", "Kur Kopyala") != DialogResult.Yes)
                    return;

                var listDovizKuru = bllDovizKur.List(x => x.Tarih == kurGirilenSonGun.Tarih).ToList();
                foreach (var item in listDovizKuru)
                {
                    DovizKurL entity = ((DovizKurL)item);
                    Id = BaseIslemTuru.IdOlustur(oldEntity);
                    txtDoviz.Text = entity.DovizAdi;
                    txtDoviz.Id = entity.DovizId;
                    txtAlis.EditValue = entity.Alis;
                    txtSatis.EditValue = entity.Satis;
                    txtEfektifAlis.EditValue = entity.EfektifAlis;
                    txtEfektifSatis.EditValue = entity.EfektifSatis;
                    ((DovizKurBll)Bll).Insert(currentEntity, x => x.Tarih == txtKod.DateTime.Date && x.DovizId == entity.Id);
                }
                btnKaydet.Visibility = BarItemVisibility.Never;
                KayitSonrasiFormuKapat = true;
                RefreshYapilacak = true;
                Close();
            }
        }
    }
}
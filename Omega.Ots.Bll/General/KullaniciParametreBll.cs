using System;
using System.Linq.Expressions;
using System.Windows.Forms;
using Omega.Ots.Bll.Base;
using Omega.Ots.Bll.Interfaces;
using Omega.Ots.Common.Enums;
using Omega.Ots.Model.Dto;
using Omega.Ots.Model.Entities;
using Omega.Ots.Model.Entities.Base;

namespace Omega.Ots.Bll.General
{
    public class KullaniciParametreBll : BaseGenelBll<KullaniciParametre>, IBaseGenelBll
    {
        public KullaniciParametreBll() : base(KartTuru.KullaniciParametre) { }
        public KullaniciParametreBll(Control ctrl) : base(ctrl, KartTuru.KullaniciParametre) { }

        public override BaseEntity Single(Expression<Func<KullaniciParametre, bool>> filter)
        {
            return BaseSingle(filter, x => new KullaniciParametreS
            {
                Id = x.Id,
                Kod = x.Kod,
                KullaniciId = x.KullaniciId,
                DefaultAvukatHesapId = x.DefaultAvukatHesapId,
                DefaultAvukatHesapAdi = x.DefaultAvukatHesap.AdiSoyadi,
                DefaultBankaHesapId = x.DefaultBankaHesapId,
                DefaultBankaHesapAdi = x.DefaultBankaHesap.HesapAdi,
                DefaultKasaHesapId = x.DefaultKasaHesapId,
                DefaultKasaHesapAdi = x.DefaultKasaHesap.KasaAdi,
                RaporlariOnayAlmadanKapat = x.RaporlariOnayAlmadanKapat,
                TableViewCaptionForeColor = x.TableViewCaptionForeColor,
                TableColumnHeaderForeColor = x.TableColumnHeaderForeColor,
                TableBandPanelForeColor = x.TableBandPanelForeColor,
                ArkaPlanResim = x.ArkaPlanResim,
            });
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
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
    public class MakbuzBll : BaseGenelBll<Makbuz>, IBaseCommonBll
    {
        public MakbuzBll() : base(KartTuru.Makbuz) { }

        public MakbuzBll(Control ctrl) : base(ctrl, KartTuru.Makbuz) { }

        public override BaseEntity Single(Expression<Func<Makbuz, bool>> filter)
        {
            return BaseSingle(filter, x => new MakbuzS
            {
                Id = x.Id,
                Kod = x.Kod,
                Tarih = x.Tarih,
                MakbuzTuru = x.MakbuzTuru,
                HesapTuru = x.HesapTuru,
                AvukatHesapId = x.AvukatHesapId,
                BankaHesapId = x.BankaHesapId,
                CariHesapId = x.CariHesapId,
                KasaHesapId = x.KasaHesapId,
                SubeHesapId = x.SubeHesapId,
                HesapAdi = x.HesapTuru == MakbuzHesapTuru.Avukat ? x.AvukatHesap.AdiSoyadi :
                           x.HesapTuru == MakbuzHesapTuru.Banka || x.HesapTuru == MakbuzHesapTuru.Epos ||
                           x.HesapTuru == MakbuzHesapTuru.Ots || x.HesapTuru == MakbuzHesapTuru.Pos ? x.BankaHesap.HesapAdi :
                           x.HesapTuru == MakbuzHesapTuru.Cari || x.HesapTuru == MakbuzHesapTuru.Mahsup ? x.CariHesap.CariAdi :
                           x.HesapTuru == MakbuzHesapTuru.Kasa ? x.KasaHesap.KasaAdi :
                           x.HesapTuru == MakbuzHesapTuru.Transfer ? x.SubeHesap.SubeAdi : null,
                HareketSayisi = x.HareketSayisi,
                MakbuzToplami = x.MakbuzToplami,
                DonemId = x.DonemId,
                SubeId = x.SubeId
            });
        }
        public override IEnumerable<BaseEntity> List(Expression<Func<Makbuz, bool>> filter)
        {
            return BaseList(filter, x => new MakbuzL
            {
                Id = x.Id,
                Kod = x.Kod,
                Tarih = x.Tarih,
                MakbuzTuru = x.MakbuzTuru,
                HesapTuru = x.HesapTuru,
                HesapAdi = x.HesapTuru == MakbuzHesapTuru.Avukat ? x.AvukatHesap.AdiSoyadi :
                           x.HesapTuru == MakbuzHesapTuru.Banka || x.HesapTuru == MakbuzHesapTuru.Epos ||
                           x.HesapTuru == MakbuzHesapTuru.Ots || x.HesapTuru == MakbuzHesapTuru.Pos ? x.BankaHesap.HesapAdi :
                           x.HesapTuru == MakbuzHesapTuru.Cari || x.HesapTuru == MakbuzHesapTuru.Mahsup ? x.CariHesap.CariAdi :
                           x.HesapTuru == MakbuzHesapTuru.Kasa ? x.KasaHesap.KasaAdi :
                           x.HesapTuru == MakbuzHesapTuru.Transfer ? x.SubeHesap.SubeAdi : null,
                HareketSayisi = x.HareketSayisi,
                MakbuzToplami = x.MakbuzToplami,
            }).OrderBy(x => x.Kod).ToList();
        }

        public override bool Delete(BaseEntity entity)
        {
            return BaseDelete(entity, KartTuru.Makbuz, false);
        }
    }
}
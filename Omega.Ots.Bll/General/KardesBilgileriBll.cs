﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Omega.Ots.Bll.Base;
using Omega.Ots.Bll.Interfaces;
using Omega.Ots.Common.Enums;
using Omega.Ots.Data.Context;
using Omega.Ots.Model.Dto;
using Omega.Ots.Model.Entities;
using Omega.Ots.Model.Entities.Base;

namespace Omega.Ots.Bll.General
{
    public class KardesBilgileriBll : BaseHareketBll<KardesBilgileri, OgrenciTakipContext>, IBaseHareketSelectBll<KardesBilgileri>
    {
        public IEnumerable<BaseHareketEntity> List(Expression<Func<KardesBilgileri, bool>> filter)
        {
            return List(filter, x => new KardesBilgileriL
            {
                Id = x.Id,
                TahakkukId = x.TahakkukId,
                KardesTahakkukId = x.KardesTahakkukId,
                Adi = x.KardesTahakkuk.Ogrenci.Adi,
                Soyadi = x.KardesTahakkuk.Ogrenci.Soyadi,
                SinifAdi = x.KardesTahakkuk.Sinif.SinifAdi,
                KayitSekli = x.KardesTahakkuk.KayitSekli,
                KayitDurumu = x.KardesTahakkuk.KayitDurumu,
                IptalDurumu = x.KardesTahakkuk.Durum ? IptalDurumu.DevamEdiyor : IptalDurumu.IptalEdildi,
                SubeAdi = x.KardesTahakkuk.Sube.SubeAdi,
                DonemId = x.KardesTahakkuk.DonemId,
                SubeId = x.KardesTahakkuk.SubeId
            }).ToList();
        }
    }
}
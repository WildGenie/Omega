using Omega.Ots.Bll.Base;
using Omega.Ots.Bll.Interfaces;
using Omega.Ots.Data.Context;
using Omega.Ots.Model.Dto;
using Omega.Ots.Model.Entities;
using Omega.Ots.Model.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Omega.Ots.Bll.General
{
    public class AileBilgileriBll : BaseHareketBll<AileBilgileri, OgrenciTakipContext>, IBaseHareketSelectBll<AileBilgileri>
    {
        public IEnumerable<BaseHareketEntity> List(Expression<Func<AileBilgileri, bool>> filter)
        {
            return List(filter, x => new AileBilgileriL
            {
                Id = x.Id,
                TahakkukId = x.TahakkukId,
                AileBilgiId = x.AileBilgiId,
                BilgiAdi = x.Ailebilgi.BilgiAdi,
                Aciklama = x.Aciklama
            }).ToList();
        }
    }
}
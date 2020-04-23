using Omega.Ots.Bll.Base;
using Omega.Ots.Bll.Interfaces;
using Omega.Ots.Common.Enums;
using Omega.Ots.Model.Entities;
using Omega.Ots.Model.Entities.Base;
using System.Windows.Forms;
using System;
using System.Linq.Expressions;
using Omega.Ots.Model.Dto;
using System.Collections.Generic;
using System.Linq;

namespace Omega.Ots.Bll.General
{
    public class BankaBll : BaseGenelBll<Banka>, IBaseGenelBll, IBaseCommonBll
    {
        public BankaBll() : base(KartTuru.Banka) { }
        public BankaBll(Control ctrl) : base(ctrl, KartTuru.Banka) { }

        public override BaseEntity Single(Expression<Func<Banka, bool>> filter)
        {
            return BaseSingle(filter, x => new BankaS
            {
                Id = x.Id,
                Kod = x.Kod,
                BankaAdi = x.BankaAdi,
                OzelKod1Id = x.OzelKod1Id,
                OzelKod1Adi = x.OzelKod1.OzelKodAdi,
                OzelKod2Id = x.OzelKod2Id,
                OzelKod2Adi = x.OzelKod2.OzelKodAdi,
                Aciklama = x.Aciklama,
                Durum = x.Durum
            });
        }
        public override IEnumerable<BaseEntity> List(Expression<Func<Banka, bool>> filter)
        {
            return BaseList(filter, x => new BankaL
            {
                Id = x.Id,
                Kod = x.Kod,
                BankaAdi = x.BankaAdi,
                OzelKod1Adi = x.OzelKod1.OzelKodAdi,
                OzelKod2Adi = x.OzelKod2.OzelKodAdi,
                Aciklama = x.Aciklama
            }).OrderBy(x => x.Kod).ToList();
        }
    }
}
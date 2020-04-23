using Omega.Ots.Bll.Base;
using Omega.Ots.Bll.Interfaces;
using Omega.Ots.Common.Enums;
using Omega.Ots.Model.Dto;
using Omega.Ots.Model.Entities;
using Omega.Ots.Model.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;

namespace Omega.Ots.Bll.General
{
    public class DovizKurBll : BaseGenelBll<DovizKur>, IBaseGenelBll, IBaseCommonBll
    {
        public DovizKurBll() : base(KartTuru.DovizKur) { }
        public DovizKurBll(Control ctrl) : base(ctrl, KartTuru.DovizKur) { }

        public override BaseEntity Single(Expression<Func<DovizKur, bool>> filter)
        {
            return BaseSingle(filter, x => new DovizKurS
            {
                Id = x.Id,
                Kod = x.Kod,
                Tarih = x.Tarih,
                DovizId = x.DovizId,
                DovizKodu = x.Doviz.Kod,
                DovizAdi = x.Doviz.DovizAdi,
                TcmbKodu = x.Doviz.TcmbDovizKodu,
                Alis = x.Alis,
                Satis = x.Satis,
                EfektifAlis = x.EfektifAlis,
                EfektifSatis = x.EfektifSatis,
                OzelKur = x.OzelKur
            });

        }
        public override IEnumerable<BaseEntity> List(Expression<Func<DovizKur, bool>> filter)
        {
            return BaseList(filter, x => new DovizKurL
            {
                Id = x.Id,
                Kod = x.Kod,
                Tarih = x.Tarih,
                DovizId = x.DovizId,
                DovizKodu = x.Doviz.Kod,
                DovizAdi = x.Doviz.DovizAdi,
                TcmbKodu = x.Doviz.TcmbDovizKodu,
                Alis = x.Alis,
                Satis = x.Satis,
                EfektifAlis = x.EfektifAlis,
                EfektifSatis = x.EfektifSatis,
                OzelKur = x.OzelKur
            }).OrderByDescending(x => x.Tarih).ToList();
        }
    }
}
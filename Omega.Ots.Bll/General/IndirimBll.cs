﻿using Omega.Ots.Bll.Base;
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
    public class IndirimBll : BaseGenelBll<Indirim>, IBaseCommonBll
    {
        public IndirimBll() : base(KartTuru.Indirim) { }
        public IndirimBll(Control ctrl) : base(ctrl, KartTuru.Indirim) { }

        public override BaseEntity Single(Expression<Func<Indirim, bool>> filter)
        {
            return BaseSingle(filter, x => new IndirimS
            {
                Id = x.Id,
                Kod = x.Kod,
                IndirimAdi = x.IndirimAdi,
                IndirimTuruId = x.IndirimTuruId,
                IndirimTuruAdi = x.IndirimTuru.IndirimTuruAdi,
                SubeId = x.SubeId,
                DonemId = x.DonemId,
                Aciklama = x.Aciklama,
                Durum = x.Durum
            });

        }
        public override IEnumerable<BaseEntity> List(Expression<Func<Indirim, bool>> filter)
        {
            return BaseList(filter, x => new IndirimL
            {
                Id = x.Id,
                Kod = x.Kod,
                IndirimAdi = x.IndirimAdi,
                IndirimTuruAdi = x.IndirimTuru.IndirimTuruAdi,
                Aciklama = x.Aciklama,
            }).OrderBy(x => x.Kod).ToList();
        }
    }
}
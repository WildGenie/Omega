using System;
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
    public class RaporBll : BaseGenelBll<Rapor>, IBaseGenelBll, IBaseCommonBll
    {
        public RaporBll() : base(KartTuru.Rapor) { }

        public RaporBll(Control ctrl) : base(ctrl, KartTuru.Rapor) { }

        public override IEnumerable<BaseEntity> List(Expression<Func<Rapor, bool>> filter)
        {
            return BaseList(filter, x => new RaporL
            {
                Id = x.Id,
                Kod = x.Kod,
                RaporAdi = x.RaporAdi,
                Aciklama = x.Aciklama
            }).OrderBy(x => x.Kod).ToList();
        }
    }
}
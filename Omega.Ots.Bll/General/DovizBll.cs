using Omega.Ots.Bll.Base;
using Omega.Ots.Bll.Interfaces;
using Omega.Ots.Common.Enums;
using Omega.Ots.Model.Entities;
using Omega.Ots.Model.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;

namespace Omega.Ots.Bll.General
{
    public class DovizBll : BaseGenelBll<Doviz>, IBaseGenelBll, IBaseCommonBll
    {
        public DovizBll() : base(KartTuru.Doviz) { }
        public DovizBll(Control ctrl) : base(ctrl, KartTuru.Doviz) { }

        public override IEnumerable<BaseEntity> List(Expression<Func<Doviz, bool>> filter)
        {
            return BaseList(filter, x => x).OrderBy(x => x.Id).ToList();
        }
    }
}
using Omega.Ots.Model.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Omega.Ots.Bll.Interfaces
{
    public interface IBaseHareketSelectBll<T>
    {
        IEnumerable<BaseHareketEntity> List(Expression<Func<T, bool>> filter);
    }
}
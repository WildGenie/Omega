using Omega.Ots.Bll.Base;
using Omega.Ots.Bll.Interfaces;
using Omega.Ots.Common.Enums;
using Omega.Ots.Model.Dto;
using Omega.Ots.Model.Entities;
using Omega.Ots.Model.Entities.Base;
using System;
using System.Linq.Expressions;
using System.Windows.Forms;

namespace Omega.Ots.Bll.General
{
    public class HizmetTuruBll : BaseGenelBll<HizmetTuru>, IBaseGenelBll, IBaseCommonBll
    {
        public HizmetTuruBll() : base(KartTuru.HizmetTuru) { }
        public HizmetTuruBll(Control ctrl) : base(ctrl, KartTuru.HizmetTuru) { }

    }
}
using Omega.Ots.Bll.Base;
using Omega.Ots.Bll.Interfaces;
using Omega.Ots.Common.Enums;
using Omega.Ots.Model.Entities;
using System.Windows.Forms;

namespace Omega.Ots.Bll.General
{
    public class AileBilgiBll : BaseGenelBll<AileBilgi>, IBaseGenelBll, IBaseCommonBll
    {
        public AileBilgiBll() : base(KartTuru.AileBilgi) { }
        public AileBilgiBll(Control ctrl) : base(ctrl, KartTuru.AileBilgi) { }
    }
}
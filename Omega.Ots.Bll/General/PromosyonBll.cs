using Omega.Ots.Bll.Base;
using Omega.Ots.Bll.Interfaces;
using Omega.Ots.Common.Enums;
using Omega.Ots.Model.Entities;
using System.Windows.Forms;

namespace Omega.Ots.Bll.General
{
    public class PromosyonBll : BaseGenelBll<Promosyon>, IBaseCommonBll
    {
        public PromosyonBll() : base(KartTuru.Promosyon) { }
        public PromosyonBll(Control ctrl) : base(ctrl, KartTuru.Promosyon) { }
    }
}
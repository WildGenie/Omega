using Omega.Ots.Bll.Base;
using Omega.Ots.Bll.Interfaces;
using Omega.Ots.Common.Enums;
using Omega.Ots.Model;
using System.Windows.Forms;

namespace Omega.Ots.Bll.General
{
    public class EvrakBll : BaseGenelBll<Evrak>, IBaseCommonBll
    {
        public EvrakBll() : base(KartTuru.Evrak) { }
        public EvrakBll(Control ctrl) : base(ctrl, KartTuru.Evrak) { }
    }
}
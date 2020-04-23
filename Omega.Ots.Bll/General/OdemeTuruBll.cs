using Omega.Ots.Bll.Base;
using Omega.Ots.Bll.Interfaces;
using Omega.Ots.Common.Enums;
using Omega.Ots.Model.Entities;
using System.Windows.Forms;

namespace Omega.Ots.Bll.General
{
    public class OdemeTuruBll : BaseGenelBll<OdemeTuru>, IBaseGenelBll, IBaseCommonBll
    {
        public OdemeTuruBll() : base(KartTuru.OdemeTuru) { }
        public OdemeTuruBll(Control ctrl) : base(ctrl, KartTuru.OdemeTuru) { }
    }
}
using Omega.Ots.Bll.Base;
using Omega.Ots.Bll.Interfaces;
using Omega.Ots.Common.Enums;
using Omega.Ots.Model;
using System.Windows.Forms;

namespace Omega.Ots.Bll.General
{
    public class YabanciDilBll : BaseGenelBll<YabanciDil>, IBaseGenelBll, IBaseCommonBll
    {
        public YabanciDilBll() : base(KartTuru.YabanciDil) { }
        public YabanciDilBll(Control control) : base(control, KartTuru.YabanciDil) { }
    }
}
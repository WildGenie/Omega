using Omega.Ots.Bll.Base;
using Omega.Ots.Bll.Interfaces;
using Omega.Ots.Common.Enums;
using Omega.Ots.Model.Entities;
using System.Windows.Forms;

namespace Omega.Ots.Bll.General
{
    public class BankaSubeBll : BaseGenelBll<BankaSube>, IBaseCommonBll
    {
        public BankaSubeBll() : base(KartTuru.BankaSube) { }
        public BankaSubeBll(Control ctrl) : base(ctrl, KartTuru.BankaSube) { }
    }
}
using Omega.Ots.Bll.Base;
using Omega.Ots.Bll.Interfaces;
using Omega.Ots.Common.Enums;
using Omega.Ots.Model.Entities;
using System.Windows.Forms;

namespace Omega.Ots.Bll.General
{
    public class SinifGrupBll : BaseGenelBll<SinifGrup>, IBaseGenelBll, IBaseCommonBll
    {
        public SinifGrupBll() : base(KartTuru.SinifGrup) { }
        public SinifGrupBll(Control ctrl) : base(ctrl, KartTuru.SinifGrup) { }

    }
}
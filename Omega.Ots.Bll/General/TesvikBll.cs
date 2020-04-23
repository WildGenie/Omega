using Omega.Ots.Bll.Base;
using Omega.Ots.Bll.Interfaces;
using Omega.Ots.Common.Enums;
using Omega.Ots.Model.Entities;
using System.Windows.Forms;

namespace Omega.Ots.Bll.General
{
    public class TesvikBll : BaseGenelBll<Tesvik>, IBaseGenelBll, IBaseCommonBll
    {
        public TesvikBll() : base(KartTuru.Tesvik) { }
        public TesvikBll(Control control) : base(control, KartTuru.Tesvik) { }
    }
}
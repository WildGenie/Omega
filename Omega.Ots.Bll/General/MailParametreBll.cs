using Omega.Ots.Bll.Base;
using Omega.Ots.Bll.Interfaces;
using Omega.Ots.Model.Entities;
using System.Windows.Forms;

namespace Omega.Ots.Bll.General
{
    public class MailParametreBll : BaseGenelBll<MailParametre>, IBaseGenelBll, IBaseCommonBll
    {
        public MailParametreBll() { }
        public MailParametreBll(Control ctrl) : base(ctrl) { }
    }
}
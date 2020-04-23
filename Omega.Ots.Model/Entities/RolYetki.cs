using Omega.Ots.Common.Enums;
using Omega.Ots.Model.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Omega.Ots.Model.Entities
{
    public class RolYetki : BaseEntity
    {
        public KartTuru KartTuru { get; set; }
    }
}

using Omega.Ots.Common.Enums;
using Omega.Ots.Model.Entities.Base;

namespace Omega.Ots.Model.Entities
{
    public class RolYetkileri : BaseHareketEntity
    {
        public long RolId { get; set; }
        public KartTuru KartTuru { get; set; }
        public byte Gorebilir { get; set; }
        public byte Ekleyebilir { get; set; }
        public byte Degistirebilir { get; set; }
        public byte Silebilir { get; set; }

        public Rol Rol { get; set; }
    }
}

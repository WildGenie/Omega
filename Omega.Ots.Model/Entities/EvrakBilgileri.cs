using Omega.Ots.Model.Entities.Base;

namespace Omega.Ots.Model.Entities
{
    public class EvrakBilgileri : BaseHareketEntity
    {
        public long TahakkukId { get; set; }
        public long EvrakId { get; set; }
        public Evrak Evrak { get; set; }
    }
}

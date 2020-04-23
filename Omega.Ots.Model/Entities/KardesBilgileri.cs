using Omega.Ots.Model.Entities.Base;

namespace Omega.Ots.Model.Entities
{
    public class KardesBilgileri : BaseHareketEntity
    {
        public long TahakkukId { get; set; }
        public long KardesTahakkukId { get; set; }

        public Tahakkuk KardesTahakkuk { get; set; }
    }
}

using Omega.Ots.Common.Enums;
using Omega.Ots.Model.Entities.Base;

namespace Omega.Ots.Model.Entities
{
    public class KullaniciBirimYetkileri : BaseHareketEntity
    {
        public long KullaniciId { get; set; }
        public KartTuru KartTuru { get; set; }
        public long? SubeId { get; set; }
        public long? DonemId { get; set; }

        public Kullanici Kullanici { get; set; }
        public Sube Sube { get; set; }
        public Donem Donem { get; set; }
    }
}

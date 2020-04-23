using Omega.Ots.Common.Enums;
using Omega.Ots.Model.Entities.Base;
using System.Security;

namespace Omega.Ots.Model.Entities
{
    public class BaglantiAyarlari : BaseEntity
    {
        public string Server { get; set; }
        public YetkilendirmeTuru YetkilendirmeTuru { get; set; }
        public SecureString KullaniciAdi { get; set; }
        public SecureString Sifre { get; set; }
    }
}
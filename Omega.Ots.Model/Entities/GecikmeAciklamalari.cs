using Omega.Ots.Model.Attributes;
using Omega.Ots.Model.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Omega.Ots.Model.Entities
{
    public class GecikmeAciklamalari : BaseEntity
    {
        [Index("IX_kod", IsUnique = false)]
        public override string Kod { get; set; }

        public int OdemeBilgileriId { get; set; }
        public long KullaniciId { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime TarihSaat { get; set; }

        [Required, StringLength(1000), ZorunluAlan("Açıklama", "txtAciklama")]
        public string Aciklama { get; set; }

        public OdemeBilgileri OdemeBilgileri { get; set; }
        public Kullanici Kullanici { get; set; }
    }
}

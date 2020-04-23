using Omega.Ots.Model.Attributes;
using Omega.Ots.Model.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Omega.Ots.Model.Entities
{
    public class Il : BaseEntityDurum
    {
        [Index("IX_Kod", IsUnique = true)]
        public override string Kod { get; set; }
        [Required, StringLength(50), Kod("İl Adı", "txtIlAdi")]
        public string IlAdi { get; set; }
        [StringLength(500)]
        public string Aciklama { get; set; }

        //Il üzerinden Ilcelerine ulabildik. 
        //Bu sayede İl'den bir eleman silince ona ait ilçelerinde otomatik olarak silinmesini sağlıcaz.
        //İl ile bağlantı yapma sadece ilçeleri almak için yaptık. Çift yönlü bağlantıyı engeller. 
        [InverseProperty("Il")] 
        public ICollection<Ilce> Ilce{ get; set; }
    }
}

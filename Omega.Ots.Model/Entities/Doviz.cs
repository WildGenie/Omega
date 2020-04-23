using Omega.Ots.Common.Enums;
using Omega.Ots.Model.Attributes;
using Omega.Ots.Model.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Omega.Ots.Model.Entities
{
    public class Doviz : BaseEntityDurum
    {
        [Index("IX_kod", IsUnique = true), StringLength(5)]
        public override string Kod { get; set; }

        [Required, StringLength(50), ZorunluAlan("Döviz Adı", "txtDovizAdi")]
        public string DovizAdi { get; set; }

        public TcmbDovizKodu TcmbDovizKodu { get; set; } = TcmbDovizKodu.Bos;

        [StringLength(500)]
        public string Aciklama { get; set; }
    }
}
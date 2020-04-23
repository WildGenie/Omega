using Omega.Ots.Model.Attributes;
using Omega.Ots.Model.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Omega.Ots.Model.Entities
{
    public class DovizKur : BaseEntity
    {
        [Index("IX_Kod", IsUnique = false), StringLength(12),]
        public override string Kod { get; set; }

        [ZorunluAlan("Doviz", "txtDoviz")]
        public long DovizId { get; set; }

        [Index("IX_Tarih"), Column(TypeName = "date"), ZorunluAlan("Tarih", "txtTarih")]
        public DateTime Tarih { get; set; } = DateTime.Now.Date;

        [Column(TypeName = "smallmoney")]
        public decimal Alis { get; set; }

        [Column(TypeName = "smallmoney")]
        public decimal Satis { get; set; }

        [Column(TypeName = "smallmoney")]
        public decimal EfektifAlis { get; set; }

        [Column(TypeName = "smallmoney")]
        public decimal EfektifSatis { get; set; }

        [Column(TypeName = "smallmoney")]
        public decimal OzelKur { get; set; }

        public Doviz Doviz { get; set; }
    }
}
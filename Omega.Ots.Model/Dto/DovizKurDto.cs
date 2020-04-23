using Omega.Ots.Common.Enums;
using Omega.Ots.Model.Entities;
using Omega.Ots.Model.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Omega.Ots.Model.Dto
{
    [NotMapped]
    public class DovizKurS : DovizKur
    {
        public string DovizKodu { get; set; }
        public string DovizAdi { get; set; }
        public TcmbDovizKodu TcmbKodu { get; set; }
    }

    public class DovizKurL : BaseEntity
    {
        public DateTime Tarih { get; set; }
        public long DovizId { get; set; }
        public string DovizKodu { get; set; }
        public string DovizAdi { get; set; }
        public TcmbDovizKodu TcmbKodu { get; set; }
        public decimal Alis { get; set; }
        public decimal Satis { get; set; }
        public decimal EfektifAlis { get; set; }
        public decimal EfektifSatis { get; set; }
        public decimal OzelKur { get; set; }
    }
}
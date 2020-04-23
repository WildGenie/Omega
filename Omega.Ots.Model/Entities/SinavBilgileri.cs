﻿using Omega.Ots.Model.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Omega.Ots.Model.Entities
{
    public class SinavBilgileri : BaseHareketEntity
    {
        public long TahakkukId { get; set; }

        [Column(TypeName = "date")]
        public DateTime Tarih { get; set; }

        [StringLength(30),Required]
        public string SinavAdi { get; set; }

        [StringLength(20),Required]
        public string PuanTuru { get; set; }

        public double Puan { get; set; }
        public int Sira { get; set; }
        public double Yuzde { get; set; }
    }
}

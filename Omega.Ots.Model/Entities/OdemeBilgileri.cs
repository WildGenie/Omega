﻿using Omega.Ots.Common.Enums;
using Omega.Ots.Model.Entities.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Omega.Ots.Model.Entities
{
    public class OdemeBilgileri : BaseHareketEntity
    {
        public long TahakkukId { get; set; }
        public long OdemeTuruId { get; set; }
        public OdemeTipi OdemeTipi { get; set; }
        public long? BankaHesapId { get; set; }
        public byte BlokeGunSayisi { get; set; }

        [Column(TypeName = "date")]
        public DateTime GirisTarihi { get; set; }

        [Column(TypeName = "date")]
        public DateTime Vade { get; set; }

        [Column(TypeName = "date")]
        public DateTime HesabaGecisTarihi { get; set; }

        [Column(TypeName = "money")]
        public decimal Tutar { get; set; }

        [StringLength(20)]
        public string TakipNo { get; set; }

        public long? BankaId { get; set; }
        public long? BankaSubeId { get; set; }

        [StringLength(20)]
        public string BelgeNo { get; set; }

        [StringLength(20)]
        public string HesapNo { get; set; }

        [StringLength(50)]
        public string AsilBorclu { get; set; }

        [StringLength(50)]
        public string Ciranta { get; set; }

        [Required, StringLength(50)]
        public string TutarYazi { get; set; }

        [Required, StringLength(50)]
        public string VadeYazi { get; set; }

        [StringLength(250)]
        public string Aciklama { get; set; }

        public Tahakkuk Tahakkuk { get; set; }
        public OdemeTuru OdemeTuru { get; set; }
        public BankaHesap BankaHesap { get; set; }
        public Banka Banka { get; set; }
        public BankaSube BankaSube { get; set; }
        public ICollection<MakbuzHareketleri> MakbuzHareketleri { get; set; }
    }
}

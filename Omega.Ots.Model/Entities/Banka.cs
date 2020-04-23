﻿using Omega.Ots.Model.Attributes;
using Omega.Ots.Model.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Omega.Ots.Model.Entities
{
    public class Banka : BaseEntityDurum
    {
        [Index("IX_kod", IsUnique = true)]
        public override string Kod { get; set; }

        [Required, StringLength(50), ZorunluAlan("Banka Adı", "txtBankaAdi")]
        public string BankaAdi { get; set; }

        [StringLength(500)]
        public string Aciklama { get; set; }

        public long? OzelKod1Id { get; set; }
        public long? OzelKod2Id { get; set; }

        public OzelKod OzelKod1 { get; set; }
        public OzelKod OzelKod2 { get; set; }

         [InverseProperty("Banka")]
        public ICollection<BankaSube> BankaSube { get; set; }
    }
}

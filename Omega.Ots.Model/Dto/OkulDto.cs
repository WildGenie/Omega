﻿using Omega.Ots.Model.Entities;
using Omega.Ots.Model.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Omega.Ots.Model.Dto
{
    [NotMapped]
    public class OkulS : Okul
    {
        public string IlAdi { get; set; }
        public string IlceAdi { get; set; }
    }

    public class OkulL : BaseEntity
    {
        public string OkulAdi { get; set; }
        public string IlAdi { get; set; }
        public string IlceAdi { get; set; }
        public string Aciklama { get; set; }
    }
}
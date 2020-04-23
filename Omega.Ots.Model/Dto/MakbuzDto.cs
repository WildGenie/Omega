﻿using Omega.Ots.Common.Enums;
using Omega.Ots.Model.Entities;
using Omega.Ots.Model.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Omega.Ots.Model.Dto
{
    [NotMapped]
    public class MakbuzS : Makbuz
    {
        public string HesapAdi { get; set; }
    }

    public class MakbuzL : BaseEntity
    {
        public DateTime Tarih { get; set; }
        public MakbuzTuru MakbuzTuru { get; set; }
        public MakbuzHesapTuru HesapTuru { get; set; }
        public decimal MakbuzToplami { get; set; }
        public int HareketSayisi { get; set; }
        public string HesapAdi { get; set; }

    }
}
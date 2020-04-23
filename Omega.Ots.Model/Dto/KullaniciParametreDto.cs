using Omega.Ots.Model.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Omega.Ots.Model.Dto
{
    [NotMapped]
    public class KullaniciParametreS : KullaniciParametre
    {
        public string DefaultAvukatHesapAdi { get; set; }
        public string DefaultBankaHesapAdi { get; set; }
        public string DefaultKasaHesapAdi { get; set; }
    }
}
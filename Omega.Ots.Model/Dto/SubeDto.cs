using Omega.Ots.Model.Entities;
using Omega.Ots.Model.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Omega.Ots.Model.Dto
{
    [NotMapped]
    public class SubeS : Sube
    {
        public string AdresIlAdi { get; set; }
        public string AdresIlceAdi { get; set; }
    }

    public class SubeL : BaseEntity
    {
        public string SubeAdi { get; set; }
        public string Adres { get; set; }
        public string AdresIlAdi { get; set; }
        public string AdresIlceAdi { get; set; }
        public string Telefon { get; set; }
        public string Fax { get; set; }
        public string IbanNo { get; set; }
        public string GrupAdi { get; set; }
        public int? SiraNo { get; set; }
        public string KurumAdi { get; set; }
    }
}
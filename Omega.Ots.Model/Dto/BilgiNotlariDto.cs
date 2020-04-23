using Omega.Ots.Model.Entities;
using Omega.Ots.Model.Entities.Base.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace Omega.Ots.Model.Dto
{
    [NotMapped]
    public class BilgiNotlariL : BilgiNotlari, IBaseHareketEntity
    {
        public bool Insert { get; set; }
        public bool Update { get; set; }
        public bool Delete { get; set; }
    }
}
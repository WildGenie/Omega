using Omega.Ots.Common.Enums;
using Omega.Ots.Model.Attributes;
using Omega.Ots.Model.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace Omega.Ots.Model.Entities
{
    public class MailParametre : BaseEntity
    {

        [Required, StringLength(50), ZorunluAlan("Email", "txtEmail")]
        public string Email { get; set; }

        [Required, StringLength(50), ZorunluAlan("Email Şifre", "txtSifre")]
        public string Sifre { get; set; }

        [ZorunluAlan("Por tNo", "txtPortNo")]
        public int PortNo { get; set; }

        [Required, StringLength(50), ZorunluAlan("Host", "txtHost")]
        public string Host { get; set; }
        public EvetHayir SslKullan { get; set; } = EvetHayir.Evet;
    }
}

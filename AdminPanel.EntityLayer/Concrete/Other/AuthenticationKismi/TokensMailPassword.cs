using AdminPanel.EntityLayer.Concrete.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminPanel.EntityLayer.Concrete.Other.AuthenticationKismi
{
    [Table(name: "TokensMailPasswords")]
    public class TokensMailPassword : EntityBase
    {
        public string mail { get; set; }
        public string password { get; set; }
    }
}

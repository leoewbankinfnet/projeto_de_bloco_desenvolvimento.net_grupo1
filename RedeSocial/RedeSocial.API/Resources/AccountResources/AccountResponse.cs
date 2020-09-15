using RedeSocial.Domain.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedeSocial.API.Resources.AccountResources
{
    public class AccountResponse
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public DateTime DtBirthday { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
        public Role Role { get; set; }
        public string UserName { get; set; }
        public string fotoPerfil { get; set; }
    }
}

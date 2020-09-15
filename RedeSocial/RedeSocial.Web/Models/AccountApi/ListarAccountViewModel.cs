using Microsoft.AspNetCore.Http;
using RedeSocial.Domain.Account;
using System;

namespace RedeSocial.Web.Models.Account
{
    public class ListarAccountViewModel
    {
        public string Id { get; set; }
        public String Name { get; set; }
        public DateTime DtBirthday { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
        public Role Role { get; set; }
        public string UserName { get; set; }
        public string fotoPerfil { get; set; }
    }
}

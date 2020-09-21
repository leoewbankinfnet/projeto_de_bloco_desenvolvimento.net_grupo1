using Microsoft.AspNetCore.Http;
using RedeSocial.Domain.Account;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RedeSocial.Web.Models.Account
{
    public class CriarAccountViewModel
    {
        [Required(ErrorMessage = "Nome é um campo obrigátorio")]
        public String Name { get; set; }
        [Required(ErrorMessage = "Data aniversario é um campo obrigátorio")]
        public DateTime DtBirthday { get; set; }
        [Required(ErrorMessage = "Email é um campo obrigátorio")]
        public String Email { get; set; }
        [Required(ErrorMessage = "password é um campo obrigátorio")]
        public String Password { get; set; }
        public Role Role { get; set; }
        [Required(ErrorMessage = "Username é um campo obrigátorio")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Foto é um campo obrigátorio")]
        public IFormFile fotoAccount { get; set; }
        public string fotoPerfil { get; set; }
    }
}

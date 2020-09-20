using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RedeSocial.API.Resources.Authentication
{
    public class LoginRequest
    {   
        [Required(ErrorMessage = "Campo Obrigatorio")]
        public String UserName { get; set; }


        [Required(ErrorMessage = "Campo Obrigatorio")]
        public String Password { get; set; }
    }
}

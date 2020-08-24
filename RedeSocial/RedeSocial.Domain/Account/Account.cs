using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RedeSocial.Domain.Account
{
    public class Account
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public DateTime DtBirthday { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }


        //Uma conta pode ter vários perfis
        public List<Profile> Profiles { get; set; }

    }
}

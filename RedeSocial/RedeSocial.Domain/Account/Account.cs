using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace RedeSocial.Domain.Account
{
    public class Account
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public DateTime DtBirthday { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
        public Role Role { get; set; }
        public string UserName { get; set; }
    }
}

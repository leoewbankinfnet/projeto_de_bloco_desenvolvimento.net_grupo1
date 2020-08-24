using System;
using System.Collections.Generic;
using System.Text;

namespace RedeSocial.Domain.Account
{
    public class Profile
    {
        public Guid Id { get; set; }

        public String Name { get; set; }


        //O perfil só tem uma conta, incluindo essas informações, pode-se fazer a navegação de perfil para conta (modificações no AccountMap necessárias)
        //public Account Account { get; set; }
        //public Guid AccountId { get; set; }

    }
}

using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RedeSocial.Services.Account
{
    public interface IAccountIdentityManager
    {
        Task<SignInResult> Login(string userName, string password);
    }
}

using Microsoft.AspNetCore.Identity;
using RedeSocial.Domain.Account;
using RedeSocial.Domain.Account.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RedeSocial.Services.Account
{
    public class AccountIdentityManager : IAccountIdentityManager
    {
        private IAccountRepository Repository { get; set; }
        private SignInManager<Domain.Account.Account> SignInManager { get; set; }

        public AccountIdentityManager(IAccountRepository accountRepository, SignInManager<Domain.Account.Account> signInManager)
        {
            this.Repository = accountRepository;
            this.SignInManager = signInManager;

        }

        public async Task<SignInResult> Login(string userName, string password)
        {
            var account = await this.Repository.GetAccountByUserNamePassword(userName, password);

            if (account == null)
            {
                return SignInResult.Failed;
            }

            await SignInManager.SignInAsync(account, false);
            
            return SignInResult.Success;
            
        }

        public async Task Logout()
        {
            await this.SignInManager.SignOutAsync();
        }
    }
}

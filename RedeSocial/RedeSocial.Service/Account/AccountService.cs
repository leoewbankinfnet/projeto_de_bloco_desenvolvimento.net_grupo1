using RedeSocial.Domain.Account.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace RedeSocial.Service.Account
{
    public class AccountService : IAccountService
    {
        private IAccountRepository AccountRepository { get; set; }

        public AccountService(IAccountRepository accountRepository)
        {
            this.AccountRepository = accountRepository;
        }

    }
}

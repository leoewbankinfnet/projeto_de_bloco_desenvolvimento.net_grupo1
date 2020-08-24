using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using RedeSocial.Domain.Account;
using System.Threading.Tasks;
using System.Threading;

namespace RedeSocial.Repository.Account
{
    public class AccountRepository : IUserStore<Domain.Account.Account>
    { 
        public Task<IdentityResult> CreateAsync(Domain.Account.Account user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> DeleteAsync(Domain.Account.Account user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<Domain.Account.Account> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Domain.Account.Account> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetNormalizedUserNameAsync(Domain.Account.Account user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetUserIdAsync(Domain.Account.Account user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetUserNameAsync(Domain.Account.Account user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetNormalizedUserNameAsync(Domain.Account.Account user, string normalizedName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetUserNameAsync(Domain.Account.Account user, string userName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> UpdateAsync(Domain.Account.Account user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

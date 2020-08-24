using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RedeSocial.Domain.Account.Repository;

namespace RedeSocial.Repository.Repository
{
    public class ApplicationDbContext : IdentityDbContext, IAccountRepository
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}

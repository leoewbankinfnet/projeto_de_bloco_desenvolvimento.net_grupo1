using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RedeSocial.Domain.Account;

namespace RedeSocial.API.Data
{
    public class RedeSocialAPIContext : DbContext
    {
        public RedeSocialAPIContext (DbContextOptions<RedeSocialAPIContext> options)
            : base(options)
        {
        }

        public DbSet<Account> Account { get; set; }
        public DbSet<Comentario> Comentario { get; set; }
        public DbSet<Postagem> Postagem { get; set; }


    }
}

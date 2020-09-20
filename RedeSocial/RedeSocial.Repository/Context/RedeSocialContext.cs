using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RedeSocial.Domain.Account;
using RedeSocial.Repository.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace RedeSocial.Repository.Context
{
    public class RedeSocialContext : DbContext
    {

        public DbSet<Domain.Account.Account> Accounts { get; set; }
        public DbSet<Role> Profiles { get; set; }
        public DbSet<Postagem> Postagens { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }

        public static readonly ILoggerFactory _loggerFactory
                    = LoggerFactory.Create(builder => { builder.AddConsole(); });

        public RedeSocialContext(DbContextOptions<RedeSocialContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(_loggerFactory);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccountMap());
            modelBuilder.ApplyConfiguration(new RoleMap());
            modelBuilder.ApplyConfiguration(new PostagemMap());
            modelBuilder.ApplyConfiguration(new ComentarioMap());

            base.OnModelCreating(modelBuilder);
        }

    }
}

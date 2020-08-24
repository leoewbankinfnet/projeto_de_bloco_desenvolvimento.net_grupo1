using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace RedeSocial.Repository.Mapping
{
    public class AccountMap : IEntityTypeConfiguration<Domain.Account.Account>
    {
        public void Configure(EntityTypeBuilder<Domain.Account.Account> builder)
        {
            builder.ToTable("Account");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Email).IsRequired().HasMaxLength(250);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Password).IsRequired().HasMaxLength(150);
            builder.Property(x => x.DtBirthday).IsRequired();

            builder.HasMany(x => x.Profiles).WithOne(); //navegação unidirecional, Um perfil tem várias contas, o perfil de uma conta.
            //builder.HasMany(x => x.Profiles).WithOne(x=>x.Accounts); navegação bidirecional, consegue ir de conta para perfil e de perfil saber a relação com a conta
        }
    }
}

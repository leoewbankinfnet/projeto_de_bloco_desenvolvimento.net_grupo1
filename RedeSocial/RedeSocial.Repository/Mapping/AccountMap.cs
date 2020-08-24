using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RedeSocial.Domain.Account;
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
            builder.Property(x => x.UserName).HasMaxLength(50);

            builder.HasOne(x => x.Role).WithMany(x => x.Accounts);

        }
    }
}

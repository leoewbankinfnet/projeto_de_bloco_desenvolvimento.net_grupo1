using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RedeSocial.Domain.Account;
using System;
using System.Collections.Generic;
using System.Text;

namespace RedeSocial.Repository.Mapping
{
    public class PostagemMap : IEntityTypeConfiguration<Domain.Account.Postagem>
    {
        public void Configure(EntityTypeBuilder<Domain.Account.Postagem> builder)
        {
            builder.ToTable("Postagem");
            builder.HasKey(x => x.postagemId);
            
            builder.Property(x => x.postagemId).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.titulo).IsRequired();
            builder.Property(x => x.urlFotoPost).IsRequired();
            builder.Property(x => x.legenda);
            builder.Property(x => x.accountId);
            builder.Property(x => x.accountName);


        }
    }
}

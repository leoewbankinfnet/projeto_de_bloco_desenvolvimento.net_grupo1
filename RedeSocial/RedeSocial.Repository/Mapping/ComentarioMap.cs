using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RedeSocial.Domain.Account;
using System;
using System.Collections.Generic;
using System.Text;

namespace RedeSocial.Repository.Mapping
{
    public class ComentarioMap : IEntityTypeConfiguration<Comentario>
    {
        public void Configure(EntityTypeBuilder<Comentario> builder)
        {
            builder.ToTable("Comentario");
            builder.HasKey(x => x.comentarioId);
            
            builder.Property(x => x.comentarioId).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.comentario).IsRequired();
            builder.Property(x => x.accountName).IsRequired().HasMaxLength(150);
            builder.Property(x => x.idDaPostagem);

        }
    }
}

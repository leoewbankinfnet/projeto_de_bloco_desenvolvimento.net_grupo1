﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RedeSocial.Repository.Context;

namespace RedeSocial.Repository.Migrations
{
    [DbContext(typeof(RedeSocialContext))]
    partial class RedeSocialContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RedeSocial.Domain.Account.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DtBirthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<Guid?>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("fotoPerfil")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("RedeSocial.Domain.Account.Comentario", b =>
                {
                    b.Property<Guid>("comentarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("accountName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("comentario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("idDaPostagem")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("postagemId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("comentarioId");

                    b.HasIndex("postagemId");

                    b.ToTable("Comentario");
                });

            modelBuilder.Entity("RedeSocial.Domain.Account.Postagem", b =>
                {
                    b.Property<Guid>("postagemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("accountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("legenda")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("titulo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("urlFotoPost")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("postagemId");

                    b.HasIndex("accountId");

                    b.ToTable("Postagem");
                });

            modelBuilder.Entity("RedeSocial.Domain.Account.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("RedeSocial.Domain.Account.Account", b =>
                {
                    b.HasOne("RedeSocial.Domain.Account.Role", "Role")
                        .WithMany("Accounts")
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("RedeSocial.Domain.Account.Comentario", b =>
                {
                    b.HasOne("RedeSocial.Domain.Account.Postagem", null)
                        .WithMany("Comentarios")
                        .HasForeignKey("postagemId");
                });

            modelBuilder.Entity("RedeSocial.Domain.Account.Postagem", b =>
                {
                    b.HasOne("RedeSocial.Domain.Account.Account", null)
                        .WithMany("Postagem")
                        .HasForeignKey("accountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RedeSocial.Repository.Migrations
{
    public partial class dbinit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 150, nullable: false),
                    DtBirthday = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(maxLength: 250, nullable: false),
                    Password = table.Column<string>(maxLength: 150, nullable: false),
                    RoleId = table.Column<Guid>(nullable: true),
                    UserName = table.Column<string>(maxLength: 50, nullable: true),
                    fotoPerfil = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Account_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Postagem",
                columns: table => new
                {
                    postagemId = table.Column<Guid>(nullable: false),
                    titulo = table.Column<string>(nullable: false),
                    urlFotoPost = table.Column<string>(nullable: false),
                    legenda = table.Column<string>(nullable: true),
                    accountName = table.Column<string>(nullable: true),
                    accountId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Postagem", x => x.postagemId);
                    table.ForeignKey(
                        name: "FK_Postagem_Account_accountId",
                        column: x => x.accountId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comentario",
                columns: table => new
                {
                    comentarioId = table.Column<Guid>(nullable: false),
                    comentario = table.Column<string>(nullable: false),
                    idDaPostagem = table.Column<Guid>(nullable: false),
                    accountName = table.Column<string>(maxLength: 150, nullable: false),
                    postagemId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentario", x => x.comentarioId);
                    table.ForeignKey(
                        name: "FK_Comentario_Postagem_postagemId",
                        column: x => x.postagemId,
                        principalTable: "Postagem",
                        principalColumn: "postagemId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account_RoleId",
                table: "Account",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Comentario_postagemId",
                table: "Comentario",
                column: "postagemId");

            migrationBuilder.CreateIndex(
                name: "IX_Postagem_accountId",
                table: "Postagem",
                column: "accountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comentario");

            migrationBuilder.DropTable(
                name: "Postagem");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}

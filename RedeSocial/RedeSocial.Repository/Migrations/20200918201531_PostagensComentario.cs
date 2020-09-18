using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RedeSocial.Repository.Migrations
{
    public partial class PostagensComentario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Postagem",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    titulo = table.Column<string>(nullable: true),
                    urlFotoPost = table.Column<string>(nullable: true),
                    legenda = table.Column<string>(nullable: true),
                    accountId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Postagem", x => x.Id);
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
                    Id = table.Column<Guid>(nullable: false),
                    comentario = table.Column<string>(nullable: true),
                    postagemId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comentario_Postagem_postagemId",
                        column: x => x.postagemId,
                        principalTable: "Postagem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
        }
    }
}

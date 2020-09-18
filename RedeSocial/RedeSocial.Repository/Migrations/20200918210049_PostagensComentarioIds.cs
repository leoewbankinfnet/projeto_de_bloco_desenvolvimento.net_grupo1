using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RedeSocial.Repository.Migrations
{
    public partial class PostagensComentarioIds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comentario_Postagem_postagemId",
                table: "Comentario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Postagem",
                table: "Postagem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comentario",
                table: "Comentario");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Postagem");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Comentario");

            migrationBuilder.AddColumn<Guid>(
                name: "postagemId",
                table: "Postagem",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "postagemId",
                table: "Comentario",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "comentarioId",
                table: "Comentario",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "idDaPostagem",
                table: "Comentario",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Postagem",
                table: "Postagem",
                column: "postagemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comentario",
                table: "Comentario",
                column: "comentarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comentario_Postagem_postagemId",
                table: "Comentario",
                column: "postagemId",
                principalTable: "Postagem",
                principalColumn: "postagemId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comentario_Postagem_postagemId",
                table: "Comentario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Postagem",
                table: "Postagem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comentario",
                table: "Comentario");

            migrationBuilder.DropColumn(
                name: "postagemId",
                table: "Postagem");

            migrationBuilder.DropColumn(
                name: "comentarioId",
                table: "Comentario");

            migrationBuilder.DropColumn(
                name: "idDaPostagem",
                table: "Comentario");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Postagem",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "postagemId",
                table: "Comentario",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Comentario",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Postagem",
                table: "Postagem",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comentario",
                table: "Comentario",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comentario_Postagem_postagemId",
                table: "Comentario",
                column: "postagemId",
                principalTable: "Postagem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace RedeSocial.Repository.Migrations
{
    public partial class AlterTableAccountAddColumnUserName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Account",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Account");
        }
    }
}

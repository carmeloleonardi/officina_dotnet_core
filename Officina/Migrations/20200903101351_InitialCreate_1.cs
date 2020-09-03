using Microsoft.EntityFrameworkCore.Migrations;

namespace Officina.Migrations
{
    public partial class InitialCreate_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "client_type",
                table: "client",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "client_type1",
                table: "client",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "client_type1",
                table: "client");

            migrationBuilder.AlterColumn<string>(
                name: "client_type",
                table: "client",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}

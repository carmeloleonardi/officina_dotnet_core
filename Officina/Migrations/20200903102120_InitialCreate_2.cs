using Microsoft.EntityFrameworkCore.Migrations;

namespace Officina.Migrations
{
    public partial class InitialCreate_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "client_type1",
                table: "client");

            migrationBuilder.AlterColumn<string>(
                name: "client_type",
                table: "client",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "client_type",
                table: "client",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "client_type1",
                table: "client",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}

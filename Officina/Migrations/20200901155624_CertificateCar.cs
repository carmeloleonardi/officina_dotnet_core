using Microsoft.EntityFrameworkCore.Migrations;

namespace Officina.Migrations
{
    public partial class CertificateCar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CertificateCar",
                columns: table => new
                {
                    CertificateCarId = table.Column<string>(nullable: false),
                    ChassisNumber = table.Column<string>(nullable: true),
                    Year = table.Column<string>(nullable: true),
                    Kw = table.Column<float>(nullable: false),
                    EngineDisplacement = table.Column<float>(nullable: false),
                    EmptyMass = table.Column<float>(nullable: false),
                    CarId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CertificateCar", x => x.CertificateCarId);
                    table.ForeignKey(
                        name: "FK_CertificateCar_Car_CarId",
                        column: x => x.CarId,
                        principalTable: "Car",
                        principalColumn: "CarId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CertificateCar_CarId",
                table: "CertificateCar",
                column: "CarId",
                unique: true,
                filter: "[CarId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CertificateCar");
        }
    }
}

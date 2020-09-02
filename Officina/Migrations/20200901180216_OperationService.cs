using Microsoft.EntityFrameworkCore.Migrations;

namespace Officina.Migrations
{
    public partial class OperationService : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Car_client_ClientId",
                table: "Car");

            migrationBuilder.DropForeignKey(
                name: "FK_CertificateCar_Car_CarId",
                table: "CertificateCar");

            migrationBuilder.DropForeignKey(
                name: "FK_Operation_Car_CarId",
                table: "Operation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Operation",
                table: "Operation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CertificateCar",
                table: "CertificateCar");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Car",
                table: "Car");

            migrationBuilder.RenameTable(
                name: "Operation",
                newName: "Operations");

            migrationBuilder.RenameTable(
                name: "CertificateCar",
                newName: "CertificateCars");

            migrationBuilder.RenameTable(
                name: "Car",
                newName: "Cars");

            migrationBuilder.RenameIndex(
                name: "IX_Operation_CarId",
                table: "Operations",
                newName: "IX_Operations_CarId");

            migrationBuilder.RenameIndex(
                name: "IX_CertificateCar_CarId",
                table: "CertificateCars",
                newName: "IX_CertificateCars_CarId");

            migrationBuilder.RenameIndex(
                name: "IX_Car_ClientId",
                table: "Cars",
                newName: "IX_Cars_ClientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Operations",
                table: "Operations",
                column: "OperationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CertificateCars",
                table: "CertificateCars",
                column: "CertificateCarId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cars",
                table: "Cars",
                column: "CarId");

            migrationBuilder.CreateTable(
                name: "Piece",
                columns: table => new
                {
                    PieceId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    Cost = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Piece", x => x.PieceId);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    ServiceId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    Cost = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.ServiceId);
                });

            migrationBuilder.CreateTable(
                name: "Workmen",
                columns: table => new
                {
                    WorkmanId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Telephone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workmen", x => x.WorkmanId);
                });

            migrationBuilder.CreateTable(
                name: "PieceOperations",
                columns: table => new
                {
                    PieceId = table.Column<long>(nullable: false),
                    OperationId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PieceOperations", x => new { x.OperationId, x.PieceId });
                    table.ForeignKey(
                        name: "FK_PieceOperations_Operations_OperationId",
                        column: x => x.OperationId,
                        principalTable: "Operations",
                        principalColumn: "OperationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PieceOperations_Piece_PieceId",
                        column: x => x.PieceId,
                        principalTable: "Piece",
                        principalColumn: "PieceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceOperations",
                columns: table => new
                {
                    OperationId = table.Column<long>(nullable: false),
                    ServiceId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceOperations", x => new { x.OperationId, x.ServiceId });
                    table.ForeignKey(
                        name: "FK_ServiceOperations_Operations_OperationId",
                        column: x => x.OperationId,
                        principalTable: "Operations",
                        principalColumn: "OperationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceOperations_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "ServiceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employements",
                columns: table => new
                {
                    OperationId = table.Column<long>(nullable: false),
                    WorkmanId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employements", x => new { x.OperationId, x.WorkmanId });
                    table.ForeignKey(
                        name: "FK_Employements_Operations_OperationId",
                        column: x => x.OperationId,
                        principalTable: "Operations",
                        principalColumn: "OperationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employements_Workmen_WorkmanId",
                        column: x => x.WorkmanId,
                        principalTable: "Workmen",
                        principalColumn: "WorkmanId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employements_WorkmanId",
                table: "Employements",
                column: "WorkmanId");

            migrationBuilder.CreateIndex(
                name: "IX_PieceOperations_PieceId",
                table: "PieceOperations",
                column: "PieceId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceOperations_ServiceId",
                table: "ServiceOperations",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_client_ClientId",
                table: "Cars",
                column: "ClientId",
                principalTable: "client",
                principalColumn: "ClientId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CertificateCars_Cars_CarId",
                table: "CertificateCars",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "CarId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Operations_Cars_CarId",
                table: "Operations",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "CarId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_client_ClientId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_CertificateCars_Cars_CarId",
                table: "CertificateCars");

            migrationBuilder.DropForeignKey(
                name: "FK_Operations_Cars_CarId",
                table: "Operations");

            migrationBuilder.DropTable(
                name: "Employements");

            migrationBuilder.DropTable(
                name: "PieceOperations");

            migrationBuilder.DropTable(
                name: "ServiceOperations");

            migrationBuilder.DropTable(
                name: "Workmen");

            migrationBuilder.DropTable(
                name: "Piece");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Operations",
                table: "Operations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CertificateCars",
                table: "CertificateCars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cars",
                table: "Cars");

            migrationBuilder.RenameTable(
                name: "Operations",
                newName: "Operation");

            migrationBuilder.RenameTable(
                name: "CertificateCars",
                newName: "CertificateCar");

            migrationBuilder.RenameTable(
                name: "Cars",
                newName: "Car");

            migrationBuilder.RenameIndex(
                name: "IX_Operations_CarId",
                table: "Operation",
                newName: "IX_Operation_CarId");

            migrationBuilder.RenameIndex(
                name: "IX_CertificateCars_CarId",
                table: "CertificateCar",
                newName: "IX_CertificateCar_CarId");

            migrationBuilder.RenameIndex(
                name: "IX_Cars_ClientId",
                table: "Car",
                newName: "IX_Car_ClientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Operation",
                table: "Operation",
                column: "OperationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CertificateCar",
                table: "CertificateCar",
                column: "CertificateCarId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Car",
                table: "Car",
                column: "CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Car_client_ClientId",
                table: "Car",
                column: "ClientId",
                principalTable: "client",
                principalColumn: "ClientId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CertificateCar_Car_CarId",
                table: "CertificateCar",
                column: "CarId",
                principalTable: "Car",
                principalColumn: "CarId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Operation_Car_CarId",
                table: "Operation",
                column: "CarId",
                principalTable: "Car",
                principalColumn: "CarId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

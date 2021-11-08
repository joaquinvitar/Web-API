using Microsoft.EntityFrameworkCore.Migrations;

namespace Locación.Shared.Migrations
{
    public partial class Inicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Países",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaísCódigo = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    PaísNombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Países", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Provincias",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProvCódigo = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    ProvNombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PaísID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provincias", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Provincias_Países_PaísID",
                        column: x => x.PaísID,
                        principalTable: "Países",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "UQ_País_PaísCódigo",
                table: "Países",
                column: "PaísCódigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Provincias_PaísID",
                table: "Provincias",
                column: "PaísID");

            migrationBuilder.CreateIndex(
                name: "UQ_País_ProvCódigo",
                table: "Provincias",
                column: "ProvCódigo",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Provincias");

            migrationBuilder.DropTable(
                name: "Países");
        }
    }
}

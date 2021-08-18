using Microsoft.EntityFrameworkCore.Migrations;

namespace Locación.Shared.Migrations
{
    public partial class Provincia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ProvCódigo",
                table: "Provincias",
                type: "nvarchar(1)",
                maxLength: 1,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(2)",
                oldMaxLength: 2);

            migrationBuilder.AddColumn<int>(
                name: "PaísID",
                table: "Provincias",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Provincias_PaísID",
                table: "Provincias",
                column: "PaísID");

            migrationBuilder.CreateIndex(
                name: "UQ_País_ProvCódigo",
                table: "Provincias",
                column: "ProvCódigo",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Provincias_Países_PaísID",
                table: "Provincias",
                column: "PaísID",
                principalTable: "Países",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Provincias_Países_PaísID",
                table: "Provincias");

            migrationBuilder.DropIndex(
                name: "IX_Provincias_PaísID",
                table: "Provincias");

            migrationBuilder.DropIndex(
                name: "UQ_País_ProvCódigo",
                table: "Provincias");

            migrationBuilder.DropColumn(
                name: "PaísID",
                table: "Provincias");

            migrationBuilder.AlterColumn<string>(
                name: "ProvCódigo",
                table: "Provincias",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1)",
                oldMaxLength: 1);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructure.Migrations.AzureTienda
{
    /// <inheritdoc />
    public partial class QuitoRelacionCondATipoComp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex("IX_CondicionTributaria_IdTipoDeComprobante", "CondicionTributaria", "IdTipoDeComprobante", schema: "Admin");

            migrationBuilder.DropForeignKey(
                name: "FK_CondicionTributaria_TipoDeComprobante_IdTipoDeComprobante",
                schema: "Admin",
                table: "CondicionTributaria");

            migrationBuilder.DropIndex(
                name: "IX_CondicionTributaria_IdTipoDeComprobante",
                schema: "Admin",
                table: "CondicionTributaria");

            migrationBuilder.DropColumn(
                name: "IdTipoDeComprobante",
                schema: "Admin",
                table: "CondicionTributaria");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex("IX_CondicionTributaria_IdTipoDeComprobante", "CondicionTributaria", schema: "Admin");

            migrationBuilder.AddColumn<int>(
                name: "IdTipoDeComprobante",
                schema: "Admin",
                table: "CondicionTributaria",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CondicionTributaria_IdTipoDeComprobante",
                schema: "Admin",
                table: "CondicionTributaria",
                column: "IdTipoDeComprobante");

            migrationBuilder.AddForeignKey(
                name: "FK_CondicionTributaria_TipoDeComprobante_IdTipoDeComprobante",
                schema: "Admin",
                table: "CondicionTributaria",
                column: "IdTipoDeComprobante",
                principalSchema: "Ventas",
                principalTable: "TipoDeComprobante",
                principalColumn: "IdTipoDeComprobante",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

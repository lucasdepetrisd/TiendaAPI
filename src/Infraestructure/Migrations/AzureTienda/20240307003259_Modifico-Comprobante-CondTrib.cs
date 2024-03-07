using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructure.Migrations.AzureTienda
{
    /// <inheritdoc />
    public partial class ModificoComprobanteCondTrib : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Descripcion",
                schema: "Admin",
                table: "CondicionTributaria",
                newName: "Nombre");

            migrationBuilder.AddColumn<int>(
                name: "IdCondicionTributariaEmisor",
                schema: "Ventas",
                table: "TipoDeComprobante",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "IdCondicionTributariaReceptor",
                schema: "Ventas",
                table: "TipoDeComprobante",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.CreateIndex(
                name: "IX_TipoDeComprobante_IdCondicionTributariaEmisor",
                schema: "Ventas",
                table: "TipoDeComprobante",
                column: "IdCondicionTributariaEmisor");

            migrationBuilder.CreateIndex(
                name: "IX_TipoDeComprobante_IdCondicionTributariaReceptor",
                schema: "Ventas",
                table: "TipoDeComprobante",
                column: "IdCondicionTributariaReceptor");

            migrationBuilder.AddForeignKey(
                name: "FK_TipoDeComprobante_CondicionTributaria_IdCondicionTributariaEmisor",
                schema: "Ventas",
                table: "TipoDeComprobante",
                column: "IdCondicionTributariaEmisor",
                principalSchema: "Admin",
                principalTable: "CondicionTributaria",
                principalColumn: "IdCondicionTributaria");

            migrationBuilder.AddForeignKey(
                name: "FK_TipoDeComprobante_CondicionTributaria_IdCondicionTributariaReceptor",
                schema: "Ventas",
                table: "TipoDeComprobante",
                column: "IdCondicionTributariaReceptor",
                principalSchema: "Admin",
                principalTable: "CondicionTributaria",
                principalColumn: "IdCondicionTributaria");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TipoDeComprobante_CondicionTributaria_IdCondicionTributariaEmisor",
                schema: "Ventas",
                table: "TipoDeComprobante");

            migrationBuilder.DropForeignKey(
                name: "FK_TipoDeComprobante_CondicionTributaria_IdCondicionTributariaReceptor",
                schema: "Ventas",
                table: "TipoDeComprobante");

            migrationBuilder.DropIndex(
                name: "IX_TipoDeComprobante_IdCondicionTributariaEmisor",
                schema: "Ventas",
                table: "TipoDeComprobante");

            migrationBuilder.DropIndex(
                name: "IX_TipoDeComprobante_IdCondicionTributariaReceptor",
                schema: "Ventas",
                table: "TipoDeComprobante");

            migrationBuilder.DropColumn(
                name: "IdCondicionTributariaEmisor",
                schema: "Ventas",
                table: "TipoDeComprobante");

            migrationBuilder.DropColumn(
                name: "IdCondicionTributariaReceptor",
                schema: "Ventas",
                table: "TipoDeComprobante");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                schema: "Admin",
                table: "CondicionTributaria",
                newName: "Descripcion");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructure.Migrations.AzureTienda
{
    /// <inheritdoc />
    public partial class QuitoRelacionesCondTrib : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex("IX_Tienda_IdCondicionTributaria", "Tienda", "IdCondicionTributaria", schema: "Admin");
            migrationBuilder.CreateIndex("IX_Cliente_IdCondicionTributaria", "Cliente", "IdCondicionTributaria", schema: "Admin");

            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_CondicionTributaria_IdCondicionTributaria",
                schema: "Admin",
                table: "Cliente");

            migrationBuilder.DropForeignKey(
                name: "FK_Tienda_CondicionTributaria_IdCondicionTributaria",
                schema: "Admin",
                table: "Tienda");

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

            migrationBuilder.DropIndex(
                name: "IX_Tienda_IdCondicionTributaria",
                schema: "Admin",
                table: "Tienda");

            migrationBuilder.DropIndex(
                name: "IX_Cliente_IdCondicionTributaria",
                schema: "Admin",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "IdCondicionTributariaEmisor",
                schema: "Ventas",
                table: "TipoDeComprobante");

            migrationBuilder.DropColumn(
                name: "IdCondicionTributariaReceptor",
                schema: "Ventas",
                table: "TipoDeComprobante");

            migrationBuilder.DropColumn(
                name: "IdCondicionTributaria",
                schema: "Admin",
                table: "Tienda");

            migrationBuilder.DropColumn(
                name: "IdCondicionTributaria",
                schema: "Admin",
                table: "Cliente");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex("IX_Tienda_IdCondicionTributaria", "Tienda", schema: "Admin");
            migrationBuilder.DropIndex("IX_Cliente_IdCondicionTributaria", "Cliente", schema: "Admin");

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

            migrationBuilder.AddColumn<int>(
                name: "IdCondicionTributaria",
                schema: "Admin",
                table: "Tienda",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdCondicionTributaria",
                schema: "Admin",
                table: "Cliente",
                type: "int",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Tienda_IdCondicionTributaria",
                schema: "Admin",
                table: "Tienda",
                column: "IdCondicionTributaria",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_IdCondicionTributaria",
                schema: "Admin",
                table: "Cliente",
                column: "IdCondicionTributaria");

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_CondicionTributaria_IdCondicionTributaria",
                schema: "Admin",
                table: "Cliente",
                column: "IdCondicionTributaria",
                principalSchema: "Admin",
                principalTable: "CondicionTributaria",
                principalColumn: "IdCondicionTributaria");

            migrationBuilder.AddForeignKey(
                name: "FK_Tienda_CondicionTributaria_IdCondicionTributaria",
                schema: "Admin",
                table: "Tienda",
                column: "IdCondicionTributaria",
                principalSchema: "Admin",
                principalTable: "CondicionTributaria",
                principalColumn: "IdCondicionTributaria",
                onDelete: ReferentialAction.Cascade);

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
    }
}

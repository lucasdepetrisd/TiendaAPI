using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructure.Migrations.AzureTienda
{
    /// <inheritdoc />
    public partial class ModificoClienteDocumento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Monto",
                schema: "Ventas",
                table: "Venta");

            migrationBuilder.RenameColumn(
                name: "Dni",
                schema: "Admin",
                table: "Cliente",
                newName: "TipoDocumento");

            migrationBuilder.RenameColumn(
                name: "Cuil",
                schema: "Admin",
                table: "Cliente",
                newName: "NroDocumento");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TipoDocumento",
                schema: "Admin",
                table: "Cliente",
                newName: "Dni");

            migrationBuilder.RenameColumn(
                name: "NroDocumento",
                schema: "Admin",
                table: "Cliente",
                newName: "Cuil");

            migrationBuilder.AddColumn<decimal>(
                name: "Monto",
                schema: "Ventas",
                table: "Venta",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);
        }
    }
}

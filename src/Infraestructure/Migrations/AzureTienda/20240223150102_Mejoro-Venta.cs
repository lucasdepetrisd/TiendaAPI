using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructure.Migrations.AzureTienda
{
    /// <inheritdoc />
    public partial class MejoroVenta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Venta_Cliente_IdCliente",
                schema: "Ventas",
                table: "Venta");

            migrationBuilder.AlterColumn<int>(
                name: "IdTipoDeComprobante",
                schema: "Ventas",
                table: "Venta",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IdCliente",
                schema: "Ventas",
                table: "Venta",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Venta_Cliente_IdCliente",
                schema: "Ventas",
                table: "Venta",
                column: "IdCliente",
                principalSchema: "Admin",
                principalTable: "Cliente",
                principalColumn: "IdCliente");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Venta_Cliente_IdCliente",
                schema: "Ventas",
                table: "Venta");

            migrationBuilder.AlterColumn<int>(
                name: "IdTipoDeComprobante",
                schema: "Ventas",
                table: "Venta",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdCliente",
                schema: "Ventas",
                table: "Venta",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Venta_Cliente_IdCliente",
                schema: "Ventas",
                table: "Venta",
                column: "IdCliente",
                principalSchema: "Admin",
                principalTable: "Cliente",
                principalColumn: "IdCliente",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

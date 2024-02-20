using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class Agregocolumnaslindeventa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Medida",
                schema: "Articulo",
                table: "Talle",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "MontoIVA",
                schema: "Ventas",
                table: "LineaDeVenta",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "NetoGravado",
                schema: "Ventas",
                table: "LineaDeVenta",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Subtotal",
                schema: "Ventas",
                table: "LineaDeVenta",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MontoIVA",
                schema: "Ventas",
                table: "LineaDeVenta");

            migrationBuilder.DropColumn(
                name: "NetoGravado",
                schema: "Ventas",
                table: "LineaDeVenta");

            migrationBuilder.DropColumn(
                name: "Subtotal",
                schema: "Ventas",
                table: "LineaDeVenta");

            migrationBuilder.AlterColumn<string>(
                name: "Medida",
                schema: "Articulo",
                table: "Talle",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}

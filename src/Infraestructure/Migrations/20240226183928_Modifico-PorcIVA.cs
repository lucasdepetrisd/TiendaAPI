using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class ModificoPorcIVA : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PorcentajeIVA",
                schema: "Ventas",
                table: "LineaDeVenta");

            migrationBuilder.AddColumn<decimal>(
                name: "PorcentajeIVA",
                schema: "Articulo",
                table: "Articulo",
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
                name: "PorcentajeIVA",
                schema: "Articulo",
                table: "Articulo");

            migrationBuilder.AddColumn<decimal>(
                name: "PorcentajeIVA",
                schema: "Ventas",
                table: "LineaDeVenta",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);
        }
    }
}

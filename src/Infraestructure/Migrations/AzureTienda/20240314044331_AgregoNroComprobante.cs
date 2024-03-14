using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructure.Migrations.AzureTienda
{
    /// <inheritdoc />
    public partial class AgregoNroComprobante : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NroComprobante",
                schema: "Ventas",
                table: "Comprobante",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NroComprobante",
                schema: "Ventas",
                table: "Comprobante");
        }
    }
}

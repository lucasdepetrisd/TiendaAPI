using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructure.Migrations.AzureTienda
{
    /// <inheritdoc />
    public partial class ModificoEstadosVentaPagoComp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NroTicket",
                schema: "Ventas",
                table: "Pago");

            migrationBuilder.AddColumn<string>(
                name: "NroTicket",
                schema: "Ventas",
                table: "Comprobante",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NroTicket",
                schema: "Ventas",
                table: "Comprobante");

            migrationBuilder.AddColumn<string>(
                name: "NroTicket",
                schema: "Ventas",
                table: "Pago",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class ModificoEstadosVentaPagoComp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ticket",
                schema: "Ventas",
                table: "Pago");

            migrationBuilder.AlterColumn<string>(
                name: "Estado",
                schema: "Ventas",
                table: "Pago",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "MontoTotal",
                schema: "Ventas",
                table: "Pago",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "NroCae",
                schema: "Ventas",
                table: "Pago",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "NroComprobante",
                schema: "Ventas",
                table: "Comprobante",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

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
                name: "MontoTotal",
                schema: "Ventas",
                table: "Pago");

            migrationBuilder.DropColumn(
                name: "NroCae",
                schema: "Ventas",
                table: "Pago");

            migrationBuilder.DropColumn(
                name: "NroComprobante",
                schema: "Ventas",
                table: "Comprobante");

            migrationBuilder.DropColumn(
                name: "NroTicket",
                schema: "Ventas",
                table: "Comprobante");

            migrationBuilder.AlterColumn<string>(
                name: "Estado",
                schema: "Ventas",
                table: "Pago",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "Ticket",
                schema: "Ventas",
                table: "Pago",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

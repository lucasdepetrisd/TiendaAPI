using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructure.Migrations.AzureTienda
{
    /// <inheritdoc />
    public partial class ColumnasPago : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NroTicket",
                schema: "Ventas",
                table: "Pago",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

            migrationBuilder.AlterColumn<string>(
                name: "NroTicket",
                schema: "Ventas",
                table: "Pago",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}

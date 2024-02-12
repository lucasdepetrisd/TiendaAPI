using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TiendaAPI.Migrations
{
    /// <inheritdoc />
    public partial class New2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LineaDeVenta_Venta_IdVenta",
                schema: "Venta",
                table: "LineaDeVenta");

            migrationBuilder.DropForeignKey(
                name: "FK_LineaDeVenta_Venta_VentaIdVenta",
                schema: "Venta",
                table: "LineaDeVenta");

            migrationBuilder.DropForeignKey(
                name: "FK_Venta_PuntoDeVenta_IdPuntoVenta",
                schema: "Venta",
                table: "Venta");

            migrationBuilder.DropForeignKey(
                name: "FK_Venta_PuntoDeVenta_PuntoDeVentaIdPuntoDeVenta",
                schema: "Venta",
                table: "Venta");

            migrationBuilder.DropForeignKey(
                name: "FK_Venta_TipoDeComprobante_IdTipoDeComprobante",
                schema: "Venta",
                table: "Venta");

            migrationBuilder.DropForeignKey(
                name: "FK_Venta_TipoDeComprobante_TipoDeComprobanteIdTipoDeComprobante",
                schema: "Venta",
                table: "Venta");

            migrationBuilder.DropIndex(
                name: "IX_Venta_IdPuntoVenta",
                schema: "Venta",
                table: "Venta");

            migrationBuilder.DropIndex(
                name: "IX_Venta_IdTipoDeComprobante",
                schema: "Venta",
                table: "Venta");

            migrationBuilder.DropIndex(
                name: "IX_Venta_PuntoDeVentaIdPuntoDeVenta",
                schema: "Venta",
                table: "Venta");

            migrationBuilder.DropIndex(
                name: "IX_Venta_TipoDeComprobanteIdTipoDeComprobante",
                schema: "Venta",
                table: "Venta");

            migrationBuilder.DropIndex(
                name: "IX_LineaDeVenta_IdVenta",
                schema: "Venta",
                table: "LineaDeVenta");

            migrationBuilder.DropIndex(
                name: "IX_LineaDeVenta_VentaIdVenta",
                schema: "Venta",
                table: "LineaDeVenta");

            migrationBuilder.DropColumn(
                name: "PuntoDeVentaIdPuntoDeVenta",
                schema: "Venta",
                table: "Venta");

            migrationBuilder.DropColumn(
                name: "TipoDeComprobanteIdTipoDeComprobante",
                schema: "Venta",
                table: "Venta");

            migrationBuilder.DropColumn(
                name: "VentaIdVenta",
                schema: "Venta",
                table: "LineaDeVenta");

            migrationBuilder.CreateIndex(
                name: "IX_Venta_IdPuntoVenta",
                schema: "Venta",
                table: "Venta",
                column: "IdPuntoVenta");

            migrationBuilder.CreateIndex(
                name: "IX_Venta_IdTipoDeComprobante",
                schema: "Venta",
                table: "Venta",
                column: "IdTipoDeComprobante");

            migrationBuilder.CreateIndex(
                name: "IX_LineaDeVenta_IdVenta",
                schema: "Venta",
                table: "LineaDeVenta",
                column: "IdVenta");

            migrationBuilder.AddForeignKey(
                name: "FK_LineaDeVenta_Venta_IdVenta",
                schema: "Venta",
                table: "LineaDeVenta",
                column: "IdVenta",
                principalSchema: "Venta",
                principalTable: "Venta",
                principalColumn: "IdVenta",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Venta_PuntoDeVenta_IdPuntoVenta",
                schema: "Venta",
                table: "Venta",
                column: "IdPuntoVenta",
                principalSchema: "Admin",
                principalTable: "PuntoDeVenta",
                principalColumn: "IdPuntoDeVenta",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Venta_TipoDeComprobante_IdTipoDeComprobante",
                schema: "Venta",
                table: "Venta",
                column: "IdTipoDeComprobante",
                principalSchema: "Venta",
                principalTable: "TipoDeComprobante",
                principalColumn: "IdTipoDeComprobante",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LineaDeVenta_Venta_IdVenta",
                schema: "Venta",
                table: "LineaDeVenta");

            migrationBuilder.DropForeignKey(
                name: "FK_Venta_PuntoDeVenta_IdPuntoVenta",
                schema: "Venta",
                table: "Venta");

            migrationBuilder.DropForeignKey(
                name: "FK_Venta_TipoDeComprobante_IdTipoDeComprobante",
                schema: "Venta",
                table: "Venta");

            migrationBuilder.DropIndex(
                name: "IX_Venta_IdPuntoVenta",
                schema: "Venta",
                table: "Venta");

            migrationBuilder.DropIndex(
                name: "IX_Venta_IdTipoDeComprobante",
                schema: "Venta",
                table: "Venta");

            migrationBuilder.DropIndex(
                name: "IX_LineaDeVenta_IdVenta",
                schema: "Venta",
                table: "LineaDeVenta");

            migrationBuilder.AddColumn<int>(
                name: "PuntoDeVentaIdPuntoDeVenta",
                schema: "Venta",
                table: "Venta",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipoDeComprobanteIdTipoDeComprobante",
                schema: "Venta",
                table: "Venta",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VentaIdVenta",
                schema: "Venta",
                table: "LineaDeVenta",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Venta_IdPuntoVenta",
                schema: "Venta",
                table: "Venta",
                column: "IdPuntoVenta",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Venta_IdTipoDeComprobante",
                schema: "Venta",
                table: "Venta",
                column: "IdTipoDeComprobante",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Venta_PuntoDeVentaIdPuntoDeVenta",
                schema: "Venta",
                table: "Venta",
                column: "PuntoDeVentaIdPuntoDeVenta");

            migrationBuilder.CreateIndex(
                name: "IX_Venta_TipoDeComprobanteIdTipoDeComprobante",
                schema: "Venta",
                table: "Venta",
                column: "TipoDeComprobanteIdTipoDeComprobante");

            migrationBuilder.CreateIndex(
                name: "IX_LineaDeVenta_IdVenta",
                schema: "Venta",
                table: "LineaDeVenta",
                column: "IdVenta",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LineaDeVenta_VentaIdVenta",
                schema: "Venta",
                table: "LineaDeVenta",
                column: "VentaIdVenta");

            migrationBuilder.AddForeignKey(
                name: "FK_LineaDeVenta_Venta_IdVenta",
                schema: "Venta",
                table: "LineaDeVenta",
                column: "IdVenta",
                principalSchema: "Venta",
                principalTable: "Venta",
                principalColumn: "IdVenta");

            migrationBuilder.AddForeignKey(
                name: "FK_LineaDeVenta_Venta_VentaIdVenta",
                schema: "Venta",
                table: "LineaDeVenta",
                column: "VentaIdVenta",
                principalSchema: "Venta",
                principalTable: "Venta",
                principalColumn: "IdVenta");

            migrationBuilder.AddForeignKey(
                name: "FK_Venta_PuntoDeVenta_IdPuntoVenta",
                schema: "Venta",
                table: "Venta",
                column: "IdPuntoVenta",
                principalSchema: "Admin",
                principalTable: "PuntoDeVenta",
                principalColumn: "IdPuntoDeVenta");

            migrationBuilder.AddForeignKey(
                name: "FK_Venta_PuntoDeVenta_PuntoDeVentaIdPuntoDeVenta",
                schema: "Venta",
                table: "Venta",
                column: "PuntoDeVentaIdPuntoDeVenta",
                principalSchema: "Admin",
                principalTable: "PuntoDeVenta",
                principalColumn: "IdPuntoDeVenta");

            migrationBuilder.AddForeignKey(
                name: "FK_Venta_TipoDeComprobante_IdTipoDeComprobante",
                schema: "Venta",
                table: "Venta",
                column: "IdTipoDeComprobante",
                principalSchema: "Venta",
                principalTable: "TipoDeComprobante",
                principalColumn: "IdTipoDeComprobante");

            migrationBuilder.AddForeignKey(
                name: "FK_Venta_TipoDeComprobante_TipoDeComprobanteIdTipoDeComprobante",
                schema: "Venta",
                table: "Venta",
                column: "TipoDeComprobanteIdTipoDeComprobante",
                principalSchema: "Venta",
                principalTable: "TipoDeComprobante",
                principalColumn: "IdTipoDeComprobante");
        }
    }
}

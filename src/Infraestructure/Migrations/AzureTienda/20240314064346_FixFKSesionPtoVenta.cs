using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructure.Migrations.AzureTienda
{
    /// <inheritdoc />
    public partial class FixFKSesionPtoVenta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                name: "FK_Sesion_PuntoDeVenta_IdSesion",
                schema: "Admin",
                table: "Sesion",
                column: "IdSesion",
                principalSchema: "Admin",
                principalTable: "PuntoDeVenta",
                principalColumn: "IdPuntoDeVenta");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sesion_PuntoDeVenta_IdSesion",
                schema: "Admin",
                table: "Sesion");
        }
    }
}

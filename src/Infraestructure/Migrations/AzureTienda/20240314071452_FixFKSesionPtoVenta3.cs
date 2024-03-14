using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructure.Migrations.AzureTienda
{
    /// <inheritdoc />
    public partial class FixFKSesionPtoVenta3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /*migrationBuilder.CreateIndex(
                name: "IX_Sesion_IdPuntoDeVenta",
                schema: "Admin",
                table: "Sesion",
                column: "IdPuntoDeVenta");

            migrationBuilder.AddForeignKey(
                name: "FK_Sesion_PuntoDeVenta_IdPuntoDeVenta",
                schema: "Admin",
                table: "Sesion",
                column: "IdPuntoDeVenta",
                principalSchema: "Admin",
                principalTable: "PuntoDeVenta",
                principalColumn: "IdPuntoDeVenta",
                onDelete: ReferentialAction.NoAction);*/
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructure.Migrations.AzureTienda
{
    /// <inheritdoc />
    public partial class FixFKSesionPtoVenta2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /*migrationBuilder.DropForeignKey(
                name: "FK_Sesion_PuntoDeVenta_IdSesion",
                schema: "Admin",
                table: "Sesion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sesion",
                schema: "Admin",
                table: "Sesion");

            migrationBuilder.DropColumn(
                name: "IdSesion",
                schema: "Admin",
                table: "Sesion");

            migrationBuilder.AddColumn<int>(
                name: "IdSesion",
                schema: "Admin",
                table: "Sesion",
                type: "int",
                nullable: false)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sesion",
                schema: "Admin",
                table: "Sesion",
                column: "IdSesion");*/
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}

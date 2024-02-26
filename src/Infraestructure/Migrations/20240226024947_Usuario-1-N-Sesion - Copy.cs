using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class Usuario1NSesion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Sesion_IdUsuario",
                schema: "Admin",
                table: "Sesion");

            migrationBuilder.CreateIndex(
                name: "IX_Sesion_IdUsuario",
                schema: "Admin",
                table: "Sesion",
                column: "IdUsuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Sesion_IdUsuario",
                schema: "Admin",
                table: "Sesion");

            migrationBuilder.CreateIndex(
                name: "IX_Sesion_IdUsuario",
                schema: "Admin",
                table: "Sesion",
                column: "IdUsuario",
                unique: true);
        }
    }
}

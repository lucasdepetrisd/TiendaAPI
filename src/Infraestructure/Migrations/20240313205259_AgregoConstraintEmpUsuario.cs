using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class AgregoConstraintEmpUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sesion_PuntoDeVenta_IdPuntoDeVenta",
                schema: "Admin",
                table: "Sesion");

            migrationBuilder.DropIndex(
                name: "IX_Sesion_IdPuntoDeVenta",
                schema: "Admin",
                table: "Sesion");

            migrationBuilder.AlterColumn<int>(
                name: "IdPuntoDeVenta",
                schema: "Admin",
                table: "Sesion",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            /*migrationBuilder.AlterColumn<int>(
                name: "IdSesion",
                schema: "Admin",
                table: "Sesion",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");*/

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

            migrationBuilder.AlterColumn<int>(
                name: "IdPuntoDeVenta",
                schema: "Admin",
                table: "Sesion",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            /*migrationBuilder.AlterColumn<int>(
                name: "IdSesion",
                schema: "Admin",
                table: "Sesion",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");*/

            migrationBuilder.CreateIndex(
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
                principalColumn: "IdPuntoDeVenta");
        }
    }
}

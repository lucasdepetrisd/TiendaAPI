using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructure.Migrations.AzureTienda
{
    /// <inheritdoc />
    public partial class FixSesion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Sesion",
                table: "Sesion",
                schema: "Admin");

            migrationBuilder.DropForeignKey(
                name: "FK_Sesion_PuntoDeVenta_IdPuntoDeVenta",
                schema: "Admin",
                table: "Sesion");

            migrationBuilder.DropColumn(
                name: "IdSesion",
                table: "Sesion",
                schema: "Admin");

            migrationBuilder.AddColumn<int>(
                name: "IdSesion",
                table: "Sesion",
                schema: "Admin",
                type: "int",
                nullable: false)
                .Annotation("SqlServer:Identity", "1, 1");

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
                principalColumn: "IdPuntoDeVenta",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "IdSesion",
                schema: "Admin",
                table: "Sesion",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddForeignKey(
                name: "FK_Sesion_PuntoDeVenta_IdSesion",
                schema: "Admin",
                table: "Sesion",
                column: "IdSesion",
                principalSchema: "Admin",
                principalTable: "PuntoDeVenta",
                principalColumn: "IdPuntoDeVenta");
        }
    }
}

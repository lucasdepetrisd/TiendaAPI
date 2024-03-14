using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructure.Migrations.AzureTienda
{
    /// <inheritdoc />
    public partial class RearmoSesion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sesion",
                schema: "Admin",
                columns: table => new
                {
                    IdSesion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    IdPuntoDeVenta = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sesion", x => x.IdSesion);
                    table.ForeignKey(
                        name: "FK_Sesion_PuntoDeVenta_IdPuntoDeVenta",
                        column: x => x.IdPuntoDeVenta,
                        principalSchema: "Admin",
                        principalTable: "PuntoDeVenta",
                        principalColumn: "IdPuntoDeVenta");
                    table.ForeignKey(
                        name: "FK_Sesion_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalSchema: "Admin",
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

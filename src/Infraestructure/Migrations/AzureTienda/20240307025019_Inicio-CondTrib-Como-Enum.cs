using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infraestructure.Migrations.AzureTienda
{
    /// <inheritdoc />
    public partial class InicioCondTribComoEnum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdCondicionTributariaEmisor",
                schema: "Ventas",
                table: "TipoDeComprobante",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdCondicionTributariaReceptor",
                schema: "Ventas",
                table: "TipoDeComprobante",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdCondicionTributaria",
                schema: "Admin",
                table: "Tienda",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdCondicionTributaria",
                schema: "Admin",
                table: "Cliente",
                type: "int",
                nullable: true);

            migrationBuilder.DropPrimaryKey(
                name: "PK_CondicionTributaria",
                schema: "Admin",
                table: "CondicionTributaria");

            migrationBuilder.DropColumn(
                name: "IdCondicionTributaria",
                schema: "Admin",
                table: "CondicionTributaria");

            migrationBuilder.AddColumn<int>(
                name: "IdCondicionTributaria",
                schema: "Admin",
                table: "CondicionTributaria",
                type: "int",
                nullable: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CondicionTributaria",
                schema: "Admin",
                table: "CondicionTributaria",
                column: "IdCondicionTributaria");

            migrationBuilder.InsertData(
                schema: "Admin",
                table: "CondicionTributaria",
                columns: new[] { "IdCondicionTributaria", "Nombre" },
                values: new object[,]
                {
                    { 0, "ResponsableInscripto" },
                    { 1, "Monotributista" },
                    { 2, "Exento" },
                    { 3, "NoResponsable" },
                    { 4, "ConsumidorFinal" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TipoDeComprobante_IdCondicionTributariaEmisor",
                schema: "Ventas",
                table: "TipoDeComprobante",
                column: "IdCondicionTributariaEmisor");

            migrationBuilder.CreateIndex(
                name: "IX_TipoDeComprobante_IdCondicionTributariaReceptor",
                schema: "Ventas",
                table: "TipoDeComprobante",
                column: "IdCondicionTributariaReceptor");

            migrationBuilder.CreateIndex(
                name: "IX_Tienda_IdCondicionTributaria",
                schema: "Admin",
                table: "Tienda",
                column: "IdCondicionTributaria",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_IdCondicionTributaria",
                schema: "Admin",
                table: "Cliente",
                column: "IdCondicionTributaria");

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_CondicionTributaria_IdCondicionTributaria",
                schema: "Admin",
                table: "Cliente",
                column: "IdCondicionTributaria",
                principalSchema: "Admin",
                principalTable: "CondicionTributaria",
                principalColumn: "IdCondicionTributaria");

            migrationBuilder.AddForeignKey(
                name: "FK_Tienda_CondicionTributaria_IdCondicionTributaria",
                schema: "Admin",
                table: "Tienda",
                column: "IdCondicionTributaria",
                principalSchema: "Admin",
                principalTable: "CondicionTributaria",
                principalColumn: "IdCondicionTributaria",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TipoDeComprobante_CondicionTributaria_IdCondicionTributariaEmisor",
                schema: "Ventas",
                table: "TipoDeComprobante",
                column: "IdCondicionTributariaEmisor",
                principalSchema: "Admin",
                principalTable: "CondicionTributaria",
                principalColumn: "IdCondicionTributaria");

            migrationBuilder.AddForeignKey(
                name: "FK_TipoDeComprobante_CondicionTributaria_IdCondicionTributariaReceptor",
                schema: "Ventas",
                table: "TipoDeComprobante",
                column: "IdCondicionTributariaReceptor",
                principalSchema: "Admin",
                principalTable: "CondicionTributaria",
                principalColumn: "IdCondicionTributaria");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_CondicionTributaria_IdCondicionTributaria",
                schema: "Admin",
                table: "Cliente");

            migrationBuilder.DropForeignKey(
                name: "FK_Tienda_CondicionTributaria_IdCondicionTributaria",
                schema: "Admin",
                table: "Tienda");

            migrationBuilder.DropForeignKey(
                name: "FK_TipoDeComprobante_CondicionTributaria_IdCondicionTributariaEmisor",
                schema: "Ventas",
                table: "TipoDeComprobante");

            migrationBuilder.DropForeignKey(
                name: "FK_TipoDeComprobante_CondicionTributaria_IdCondicionTributariaReceptor",
                schema: "Ventas",
                table: "TipoDeComprobante");

            migrationBuilder.DropIndex(
                name: "IX_TipoDeComprobante_IdCondicionTributariaEmisor",
                schema: "Ventas",
                table: "TipoDeComprobante");

            migrationBuilder.DropIndex(
                name: "IX_TipoDeComprobante_IdCondicionTributariaReceptor",
                schema: "Ventas",
                table: "TipoDeComprobante");

            migrationBuilder.DropIndex(
                name: "IX_Tienda_IdCondicionTributaria",
                schema: "Admin",
                table: "Tienda");

            migrationBuilder.DropIndex(
                name: "IX_Cliente_IdCondicionTributaria",
                schema: "Admin",
                table: "Cliente");

            migrationBuilder.DeleteData(
                schema: "Admin",
                table: "CondicionTributaria",
                keyColumn: "IdCondicionTributaria",
                keyValue: 0);

            migrationBuilder.DeleteData(
                schema: "Admin",
                table: "CondicionTributaria",
                keyColumn: "IdCondicionTributaria",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "Admin",
                table: "CondicionTributaria",
                keyColumn: "IdCondicionTributaria",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "Admin",
                table: "CondicionTributaria",
                keyColumn: "IdCondicionTributaria",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "Admin",
                table: "CondicionTributaria",
                keyColumn: "IdCondicionTributaria",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "IdCondicionTributariaEmisor",
                schema: "Ventas",
                table: "TipoDeComprobante");

            migrationBuilder.DropColumn(
                name: "IdCondicionTributariaReceptor",
                schema: "Ventas",
                table: "TipoDeComprobante");

            migrationBuilder.DropColumn(
                name: "IdCondicionTributaria",
                schema: "Admin",
                table: "Tienda");

            migrationBuilder.DropColumn(
                name: "IdCondicionTributaria",
                schema: "Admin",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "IdCondicionTributaria",
                schema: "Admin",
                table: "CondicionTributaria");

            migrationBuilder.AddColumn<int>(
                name: "IdCondicionTributaria",
                schema: "Admin",
                table: "CondicionTributaria",
                type: "int",
                nullable: false)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "IdCondicionTributaria",
                schema: "Admin",
                table: "CondicionTributaria",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");
        }
    }
}

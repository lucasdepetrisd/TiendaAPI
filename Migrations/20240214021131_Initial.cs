using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TiendaAPI.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Articulo");

            migrationBuilder.EnsureSchema(
                name: "Admin");

            migrationBuilder.EnsureSchema(
                name: "Ventas");

            migrationBuilder.CreateTable(
                name: "Categoria",
                schema: "Articulo",
                columns: table => new
                {
                    IdCategoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.IdCategoria);
                });

            migrationBuilder.CreateTable(
                name: "Color",
                schema: "Articulo",
                columns: table => new
                {
                    IdColor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Color", x => x.IdColor);
                });

            migrationBuilder.CreateTable(
                name: "Marca",
                schema: "Articulo",
                columns: table => new
                {
                    IdMarca = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marca", x => x.IdMarca);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                schema: "Admin",
                columns: table => new
                {
                    IdRol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.IdRol);
                });

            migrationBuilder.CreateTable(
                name: "TipoDeComprobante",
                schema: "Ventas",
                columns: table => new
                {
                    IdTipoDeComprobante = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDeComprobante", x => x.IdTipoDeComprobante);
                });

            migrationBuilder.CreateTable(
                name: "TipoTalle",
                schema: "Articulo",
                columns: table => new
                {
                    IdTipoTalle = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoTalle", x => x.IdTipoTalle);
                });

            migrationBuilder.CreateTable(
                name: "CondicionTributaria",
                schema: "Admin",
                columns: table => new
                {
                    IdCondicionTributaria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdTipoDeComprobante = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CondicionTributaria", x => x.IdCondicionTributaria);
                    table.ForeignKey(
                        name: "FK_CondicionTributaria_TipoDeComprobante_IdTipoDeComprobante",
                        column: x => x.IdTipoDeComprobante,
                        principalSchema: "Ventas",
                        principalTable: "TipoDeComprobante",
                        principalColumn: "IdTipoDeComprobante",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Articulo",
                schema: "Articulo",
                columns: table => new
                {
                    IdArticulo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Costo = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    PorcentajeIVA = table.Column<int>(type: "int", nullable: false),
                    MargenGanancia = table.Column<int>(type: "int", nullable: false),
                    IdCategoria = table.Column<int>(type: "int", nullable: true),
                    IdMarca = table.Column<int>(type: "int", nullable: true),
                    IdTipoTalle = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articulo", x => x.IdArticulo);
                    table.ForeignKey(
                        name: "FK_Articulo_Categoria_IdCategoria",
                        column: x => x.IdCategoria,
                        principalSchema: "Articulo",
                        principalTable: "Categoria",
                        principalColumn: "IdCategoria");
                    table.ForeignKey(
                        name: "FK_Articulo_Marca_IdMarca",
                        column: x => x.IdMarca,
                        principalSchema: "Articulo",
                        principalTable: "Marca",
                        principalColumn: "IdMarca");
                    table.ForeignKey(
                        name: "FK_Articulo_TipoTalle_IdTipoTalle",
                        column: x => x.IdTipoTalle,
                        principalSchema: "Articulo",
                        principalTable: "TipoTalle",
                        principalColumn: "IdTipoTalle");
                });

            migrationBuilder.CreateTable(
                name: "Talle",
                schema: "Articulo",
                columns: table => new
                {
                    IdTalle = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Medida = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdTipoTalle = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Talle", x => x.IdTalle);
                    table.ForeignKey(
                        name: "FK_Talle_TipoTalle_IdTipoTalle",
                        column: x => x.IdTipoTalle,
                        principalSchema: "Articulo",
                        principalTable: "TipoTalle",
                        principalColumn: "IdTipoTalle");
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                schema: "Admin",
                columns: table => new
                {
                    IdCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dni = table.Column<int>(type: "int", nullable: false),
                    Cuil = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Domicilio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCondicionTributaria = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.IdCliente);
                    table.ForeignKey(
                        name: "FK_Cliente_CondicionTributaria_IdCondicionTributaria",
                        column: x => x.IdCondicionTributaria,
                        principalSchema: "Admin",
                        principalTable: "CondicionTributaria",
                        principalColumn: "IdCondicionTributaria");
                });

            migrationBuilder.CreateTable(
                name: "Tienda",
                schema: "Admin",
                columns: table => new
                {
                    IdTienda = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cuit = table.Column<int>(type: "int", nullable: false),
                    IdCondicionTributaria = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tienda", x => x.IdTienda);
                    table.ForeignKey(
                        name: "FK_Tienda_CondicionTributaria_IdCondicionTributaria",
                        column: x => x.IdCondicionTributaria,
                        principalSchema: "Admin",
                        principalTable: "CondicionTributaria",
                        principalColumn: "IdCondicionTributaria",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sucursal",
                schema: "Admin",
                columns: table => new
                {
                    IdSucursal = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Domicilio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ciudad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdTienda = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sucursal", x => x.IdSucursal);
                    table.ForeignKey(
                        name: "FK_Sucursal_Tienda_IdTienda",
                        column: x => x.IdTienda,
                        principalSchema: "Admin",
                        principalTable: "Tienda",
                        principalColumn: "IdTienda",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Empleado",
                schema: "Admin",
                columns: table => new
                {
                    IdEmpleado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Legajo = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Domicilio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdSucursal = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleado", x => x.IdEmpleado);
                    table.ForeignKey(
                        name: "FK_Empleado_Sucursal_IdSucursal",
                        column: x => x.IdSucursal,
                        principalSchema: "Admin",
                        principalTable: "Sucursal",
                        principalColumn: "IdSucursal",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inventario",
                schema: "Articulo",
                columns: table => new
                {
                    IdInventario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    IdSucursal = table.Column<int>(type: "int", nullable: false),
                    IdColor = table.Column<int>(type: "int", nullable: false),
                    IdTalle = table.Column<int>(type: "int", nullable: false),
                    IdArticulo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventario", x => x.IdInventario);
                    table.ForeignKey(
                        name: "FK_Inventario_Articulo_IdArticulo",
                        column: x => x.IdArticulo,
                        principalSchema: "Articulo",
                        principalTable: "Articulo",
                        principalColumn: "IdArticulo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inventario_Color_IdColor",
                        column: x => x.IdColor,
                        principalSchema: "Articulo",
                        principalTable: "Color",
                        principalColumn: "IdColor",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inventario_Sucursal_IdSucursal",
                        column: x => x.IdSucursal,
                        principalSchema: "Admin",
                        principalTable: "Sucursal",
                        principalColumn: "IdSucursal",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inventario_Talle_IdTalle",
                        column: x => x.IdTalle,
                        principalSchema: "Articulo",
                        principalTable: "Talle",
                        principalColumn: "IdTalle",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PuntoDeVenta",
                schema: "Admin",
                columns: table => new
                {
                    IdPuntoDeVenta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroPtoVenta = table.Column<int>(type: "int", nullable: false),
                    Habilitado = table.Column<bool>(type: "bit", nullable: false),
                    IdSucursal = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PuntoDeVenta", x => x.IdPuntoDeVenta);
                    table.ForeignKey(
                        name: "FK_PuntoDeVenta_Sucursal_IdSucursal",
                        column: x => x.IdSucursal,
                        principalSchema: "Admin",
                        principalTable: "Sucursal",
                        principalColumn: "IdSucursal",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                schema: "Admin",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contraseña = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdRol = table.Column<int>(type: "int", nullable: true),
                    IdEmpleado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.IdUsuario);
                    table.ForeignKey(
                        name: "FK_Usuario_Empleado_IdEmpleado",
                        column: x => x.IdEmpleado,
                        principalSchema: "Admin",
                        principalTable: "Empleado",
                        principalColumn: "IdEmpleado",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Usuario_Rol_IdRol",
                        column: x => x.IdRol,
                        principalSchema: "Admin",
                        principalTable: "Rol",
                        principalColumn: "IdRol");
                });

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

            migrationBuilder.CreateTable(
                name: "Venta",
                schema: "Ventas",
                columns: table => new
                {
                    IdVenta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Monto = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdCliente = table.Column<int>(type: "int", nullable: false),
                    IdTipoDeComprobante = table.Column<int>(type: "int", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    IdPuntoVenta = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venta", x => x.IdVenta);
                    table.ForeignKey(
                        name: "FK_Venta_Cliente_IdCliente",
                        column: x => x.IdCliente,
                        principalSchema: "Admin",
                        principalTable: "Cliente",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Venta_PuntoDeVenta_IdPuntoVenta",
                        column: x => x.IdPuntoVenta,
                        principalSchema: "Admin",
                        principalTable: "PuntoDeVenta",
                        principalColumn: "IdPuntoDeVenta",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Venta_TipoDeComprobante_IdTipoDeComprobante",
                        column: x => x.IdTipoDeComprobante,
                        principalSchema: "Ventas",
                        principalTable: "TipoDeComprobante",
                        principalColumn: "IdTipoDeComprobante",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Venta_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalSchema: "Admin",
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comprobante",
                schema: "Ventas",
                columns: table => new
                {
                    IdComprobante = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdVenta = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comprobante", x => x.IdComprobante);
                    table.ForeignKey(
                        name: "FK_Comprobante_Venta_IdVenta",
                        column: x => x.IdVenta,
                        principalSchema: "Ventas",
                        principalTable: "Venta",
                        principalColumn: "IdVenta",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LineaDeVenta",
                schema: "Ventas",
                columns: table => new
                {
                    IdLineaDeVenta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    PorcentajeIVA = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    IdInventario = table.Column<int>(type: "int", nullable: false),
                    IdVenta = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineaDeVenta", x => x.IdLineaDeVenta);
                    table.ForeignKey(
                        name: "FK_LineaDeVenta_Inventario_IdInventario",
                        column: x => x.IdInventario,
                        principalSchema: "Articulo",
                        principalTable: "Inventario",
                        principalColumn: "IdInventario",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LineaDeVenta_Venta_IdVenta",
                        column: x => x.IdVenta,
                        principalSchema: "Ventas",
                        principalTable: "Venta",
                        principalColumn: "IdVenta",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pago",
                schema: "Ventas",
                columns: table => new
                {
                    IdPago = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ticket = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdVenta = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pago", x => x.IdPago);
                    table.ForeignKey(
                        name: "FK_Pago_Venta_IdVenta",
                        column: x => x.IdVenta,
                        principalSchema: "Ventas",
                        principalTable: "Venta",
                        principalColumn: "IdVenta",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articulo_IdCategoria",
                schema: "Articulo",
                table: "Articulo",
                column: "IdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Articulo_IdMarca",
                schema: "Articulo",
                table: "Articulo",
                column: "IdMarca");

            migrationBuilder.CreateIndex(
                name: "IX_Articulo_IdTipoTalle",
                schema: "Articulo",
                table: "Articulo",
                column: "IdTipoTalle");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_IdCondicionTributaria",
                schema: "Admin",
                table: "Cliente",
                column: "IdCondicionTributaria");

            migrationBuilder.CreateIndex(
                name: "IX_Comprobante_IdVenta",
                schema: "Ventas",
                table: "Comprobante",
                column: "IdVenta",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CondicionTributaria_IdTipoDeComprobante",
                schema: "Admin",
                table: "CondicionTributaria",
                column: "IdTipoDeComprobante");

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_IdSucursal",
                schema: "Admin",
                table: "Empleado",
                column: "IdSucursal");

            migrationBuilder.CreateIndex(
                name: "IX_Inventario_IdArticulo",
                schema: "Articulo",
                table: "Inventario",
                column: "IdArticulo");

            migrationBuilder.CreateIndex(
                name: "IX_Inventario_IdColor",
                schema: "Articulo",
                table: "Inventario",
                column: "IdColor");

            migrationBuilder.CreateIndex(
                name: "IX_Inventario_IdSucursal",
                schema: "Articulo",
                table: "Inventario",
                column: "IdSucursal");

            migrationBuilder.CreateIndex(
                name: "IX_Inventario_IdTalle",
                schema: "Articulo",
                table: "Inventario",
                column: "IdTalle");

            migrationBuilder.CreateIndex(
                name: "IX_LineaDeVenta_IdInventario",
                schema: "Ventas",
                table: "LineaDeVenta",
                column: "IdInventario");

            migrationBuilder.CreateIndex(
                name: "IX_LineaDeVenta_IdVenta",
                schema: "Ventas",
                table: "LineaDeVenta",
                column: "IdVenta");

            migrationBuilder.CreateIndex(
                name: "IX_Pago_IdVenta",
                schema: "Ventas",
                table: "Pago",
                column: "IdVenta",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PuntoDeVenta_IdSucursal",
                schema: "Admin",
                table: "PuntoDeVenta",
                column: "IdSucursal");

            migrationBuilder.CreateIndex(
                name: "IX_Sesion_IdPuntoDeVenta",
                schema: "Admin",
                table: "Sesion",
                column: "IdPuntoDeVenta");

            migrationBuilder.CreateIndex(
                name: "IX_Sesion_IdUsuario",
                schema: "Admin",
                table: "Sesion",
                column: "IdUsuario",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sucursal_IdTienda",
                schema: "Admin",
                table: "Sucursal",
                column: "IdTienda");

            migrationBuilder.CreateIndex(
                name: "IX_Talle_IdTipoTalle",
                schema: "Articulo",
                table: "Talle",
                column: "IdTipoTalle");

            migrationBuilder.CreateIndex(
                name: "IX_Tienda_IdCondicionTributaria",
                schema: "Admin",
                table: "Tienda",
                column: "IdCondicionTributaria",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_IdEmpleado",
                schema: "Admin",
                table: "Usuario",
                column: "IdEmpleado",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_IdRol",
                schema: "Admin",
                table: "Usuario",
                column: "IdRol");

            migrationBuilder.CreateIndex(
                name: "IX_Venta_IdCliente",
                schema: "Ventas",
                table: "Venta",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Venta_IdPuntoVenta",
                schema: "Ventas",
                table: "Venta",
                column: "IdPuntoVenta");

            migrationBuilder.CreateIndex(
                name: "IX_Venta_IdTipoDeComprobante",
                schema: "Ventas",
                table: "Venta",
                column: "IdTipoDeComprobante");

            migrationBuilder.CreateIndex(
                name: "IX_Venta_IdUsuario",
                schema: "Ventas",
                table: "Venta",
                column: "IdUsuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comprobante",
                schema: "Ventas");

            migrationBuilder.DropTable(
                name: "LineaDeVenta",
                schema: "Ventas");

            migrationBuilder.DropTable(
                name: "Pago",
                schema: "Ventas");

            migrationBuilder.DropTable(
                name: "Sesion",
                schema: "Admin");

            migrationBuilder.DropTable(
                name: "Inventario",
                schema: "Articulo");

            migrationBuilder.DropTable(
                name: "Venta",
                schema: "Ventas");

            migrationBuilder.DropTable(
                name: "Articulo",
                schema: "Articulo");

            migrationBuilder.DropTable(
                name: "Color",
                schema: "Articulo");

            migrationBuilder.DropTable(
                name: "Talle",
                schema: "Articulo");

            migrationBuilder.DropTable(
                name: "Cliente",
                schema: "Admin");

            migrationBuilder.DropTable(
                name: "PuntoDeVenta",
                schema: "Admin");

            migrationBuilder.DropTable(
                name: "Usuario",
                schema: "Admin");

            migrationBuilder.DropTable(
                name: "Categoria",
                schema: "Articulo");

            migrationBuilder.DropTable(
                name: "Marca",
                schema: "Articulo");

            migrationBuilder.DropTable(
                name: "TipoTalle",
                schema: "Articulo");

            migrationBuilder.DropTable(
                name: "Empleado",
                schema: "Admin");

            migrationBuilder.DropTable(
                name: "Rol",
                schema: "Admin");

            migrationBuilder.DropTable(
                name: "Sucursal",
                schema: "Admin");

            migrationBuilder.DropTable(
                name: "Tienda",
                schema: "Admin");

            migrationBuilder.DropTable(
                name: "CondicionTributaria",
                schema: "Admin");

            migrationBuilder.DropTable(
                name: "TipoDeComprobante",
                schema: "Ventas");
        }
    }
}

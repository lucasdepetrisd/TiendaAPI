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
                name: "Venta");

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
                name: "CondicionTributaria",
                schema: "Venta",
                columns: table => new
                {
                    IdCondicionTributaria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CondicionTributaria", x => x.IdCondicionTributaria);
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
                schema: "Venta",
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
                name: "Cliente",
                schema: "Venta",
                columns: table => new
                {
                    IdCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dni = table.Column<int>(type: "int", nullable: false),
                    Cuil = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Domicilio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCondicionTributaria = table.Column<int>(type: "int", nullable: false),
                    IdCondicionTributariaNavigationIdCondicionTributaria = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.IdCliente);
                    table.ForeignKey(
                        name: "FK_Cliente_CondicionTributaria_IdCondicionTributariaNavigationIdCondicionTributaria",
                        column: x => x.IdCondicionTributariaNavigationIdCondicionTributaria,
                        principalSchema: "Venta",
                        principalTable: "CondicionTributaria",
                        principalColumn: "IdCondicionTributaria",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tienda",
                schema: "Venta",
                columns: table => new
                {
                    IdTienda = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cuit = table.Column<int>(type: "int", nullable: false),
                    IdCondicionTributaria = table.Column<int>(type: "int", nullable: false),
                    IdCondicionTributariaNavigationIdCondicionTributaria = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tienda", x => x.IdTienda);
                    table.ForeignKey(
                        name: "FK_Tienda_CondicionTributaria_IdCondicionTributariaNavigationIdCondicionTributaria",
                        column: x => x.IdCondicionTributariaNavigationIdCondicionTributaria,
                        principalSchema: "Venta",
                        principalTable: "CondicionTributaria",
                        principalColumn: "IdCondicionTributaria",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TipoDeComprobante",
                schema: "Venta",
                columns: table => new
                {
                    IdTipoDeComprobante = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCondicionTributaria = table.Column<int>(type: "int", nullable: false),
                    NombreTipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCondicionTributariaNavigationIdCondicionTributaria = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDeComprobante", x => x.IdTipoDeComprobante);
                    table.ForeignKey(
                        name: "FK_TipoDeComprobante_CondicionTributaria_IdCondicionTributariaNavigationIdCondicionTributaria",
                        column: x => x.IdCondicionTributariaNavigationIdCondicionTributaria,
                        principalSchema: "Venta",
                        principalTable: "CondicionTributaria",
                        principalColumn: "IdCondicionTributaria",
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
                    Iva = table.Column<int>(type: "int", nullable: false),
                    MargenGanancia = table.Column<int>(type: "int", nullable: false),
                    IdCategoria = table.Column<int>(type: "int", nullable: false),
                    IdMarca = table.Column<int>(type: "int", nullable: false),
                    IdTipoTalle = table.Column<int>(type: "int", nullable: false),
                    IdCategoriaNavigationIdCategoria = table.Column<int>(type: "int", nullable: false),
                    IdMarcaNavigationIdMarca = table.Column<int>(type: "int", nullable: false),
                    IdTipoTalleNavigationIdTipoTalle = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articulo", x => x.IdArticulo);
                    table.ForeignKey(
                        name: "FK_Articulo_Categoria_IdCategoriaNavigationIdCategoria",
                        column: x => x.IdCategoriaNavigationIdCategoria,
                        principalSchema: "Articulo",
                        principalTable: "Categoria",
                        principalColumn: "IdCategoria",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Articulo_Marca_IdMarcaNavigationIdMarca",
                        column: x => x.IdMarcaNavigationIdMarca,
                        principalSchema: "Articulo",
                        principalTable: "Marca",
                        principalColumn: "IdMarca",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Articulo_TipoTalle_IdTipoTalleNavigationIdTipoTalle",
                        column: x => x.IdTipoTalleNavigationIdTipoTalle,
                        principalSchema: "Articulo",
                        principalTable: "TipoTalle",
                        principalColumn: "IdTipoTalle",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Talle",
                schema: "Articulo",
                columns: table => new
                {
                    IdTalle = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Medida = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdTipoTalle = table.Column<int>(type: "int", nullable: false),
                    IdTipoTalleNavigationIdTipoTalle = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Talle", x => x.IdTalle);
                    table.ForeignKey(
                        name: "FK_Talle_TipoTalle_IdTipoTalleNavigationIdTipoTalle",
                        column: x => x.IdTipoTalleNavigationIdTipoTalle,
                        principalSchema: "Articulo",
                        principalTable: "TipoTalle",
                        principalColumn: "IdTipoTalle",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sucursal",
                schema: "Venta",
                columns: table => new
                {
                    IdSucursal = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Domicilio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ciudad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cuit = table.Column<int>(type: "int", nullable: false),
                    CuitNavigationIdTienda = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sucursal", x => x.IdSucursal);
                    table.ForeignKey(
                        name: "FK_Sucursal_Tienda_CuitNavigationIdTienda",
                        column: x => x.CuitNavigationIdTienda,
                        principalSchema: "Venta",
                        principalTable: "Tienda",
                        principalColumn: "IdTienda",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Empleado",
                schema: "Venta",
                columns: table => new
                {
                    IdEmpleado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LegajoEmpleado = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Usuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contraseña = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdSucursal = table.Column<int>(type: "int", nullable: false),
                    IdSucursalNavigationIdSucursal = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleado", x => x.IdEmpleado);
                    table.ForeignKey(
                        name: "FK_Empleado_Sucursal_IdSucursalNavigationIdSucursal",
                        column: x => x.IdSucursalNavigationIdSucursal,
                        principalSchema: "Venta",
                        principalTable: "Sucursal",
                        principalColumn: "IdSucursal",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inventario",
                schema: "Articulo",
                columns: table => new
                {
                    IdInventarioArticulo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    IdSucursal = table.Column<int>(type: "int", nullable: false),
                    Codigo = table.Column<int>(type: "int", nullable: false),
                    IdColor = table.Column<int>(type: "int", nullable: false),
                    IdMedida = table.Column<int>(type: "int", nullable: false),
                    CodigoNavigationIdArticulo = table.Column<int>(type: "int", nullable: false),
                    IdColorNavigationIdColor = table.Column<int>(type: "int", nullable: false),
                    IdTalleNavigationIdTalle = table.Column<int>(type: "int", nullable: true),
                    IdSucursalNavigationIdSucursal = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventario", x => x.IdInventarioArticulo);
                    table.ForeignKey(
                        name: "FK_Inventario_Articulo_CodigoNavigationIdArticulo",
                        column: x => x.CodigoNavigationIdArticulo,
                        principalSchema: "Articulo",
                        principalTable: "Articulo",
                        principalColumn: "IdArticulo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inventario_Color_IdColorNavigationIdColor",
                        column: x => x.IdColorNavigationIdColor,
                        principalSchema: "Articulo",
                        principalTable: "Color",
                        principalColumn: "IdColor",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inventario_Sucursal_IdSucursalNavigationIdSucursal",
                        column: x => x.IdSucursalNavigationIdSucursal,
                        principalSchema: "Venta",
                        principalTable: "Sucursal",
                        principalColumn: "IdSucursal",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inventario_Talle_IdTalleNavigationIdTalle",
                        column: x => x.IdTalleNavigationIdTalle,
                        principalSchema: "Articulo",
                        principalTable: "Talle",
                        principalColumn: "IdTalle");
                });

            migrationBuilder.CreateTable(
                name: "PuntoDeVenta",
                schema: "Venta",
                columns: table => new
                {
                    IdPuntoDeVenta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroPtoVenta = table.Column<int>(type: "int", nullable: false),
                    IdSucursal = table.Column<int>(type: "int", nullable: false),
                    IdSucursalNavigationIdSucursal = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PuntoDeVenta", x => x.IdPuntoDeVenta);
                    table.ForeignKey(
                        name: "FK_PuntoDeVenta_Sucursal_IdSucursalNavigationIdSucursal",
                        column: x => x.IdSucursalNavigationIdSucursal,
                        principalSchema: "Venta",
                        principalTable: "Sucursal",
                        principalColumn: "IdSucursal",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                schema: "Venta",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LegajoEmpleado = table.Column<int>(type: "int", nullable: false),
                    IdRol = table.Column<int>(type: "int", nullable: false),
                    IdRolNavigationIdRol = table.Column<int>(type: "int", nullable: false),
                    LegajoEmpleadoNavigationIdEmpleado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.IdUsuario);
                    table.ForeignKey(
                        name: "FK_Usuario_Empleado_LegajoEmpleadoNavigationIdEmpleado",
                        column: x => x.LegajoEmpleadoNavigationIdEmpleado,
                        principalSchema: "Venta",
                        principalTable: "Empleado",
                        principalColumn: "IdEmpleado",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Usuario_Rol_IdRolNavigationIdRol",
                        column: x => x.IdRolNavigationIdRol,
                        principalSchema: "Venta",
                        principalTable: "Rol",
                        principalColumn: "IdRol",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Venta",
                schema: "Venta",
                columns: table => new
                {
                    IdVenta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Monto = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroPtoVenta = table.Column<int>(type: "int", nullable: false),
                    DniCliente = table.Column<int>(type: "int", nullable: false),
                    LegajoEmpleado = table.Column<int>(type: "int", nullable: false),
                    IdTipoDeComprobante = table.Column<int>(type: "int", nullable: false),
                    DniClienteNavigationIdCliente = table.Column<int>(type: "int", nullable: false),
                    IdTipoDeComprobanteNavigationIdTipoDeComprobante = table.Column<int>(type: "int", nullable: true),
                    IdEmpleadoNavigationIdEmpleado = table.Column<int>(type: "int", nullable: true),
                    IdPuntoDeVentaNavigationIdPuntoDeVenta = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venta", x => x.IdVenta);
                    table.ForeignKey(
                        name: "FK_Venta_Cliente_DniClienteNavigationIdCliente",
                        column: x => x.DniClienteNavigationIdCliente,
                        principalSchema: "Venta",
                        principalTable: "Cliente",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Venta_Empleado_IdEmpleadoNavigationIdEmpleado",
                        column: x => x.IdEmpleadoNavigationIdEmpleado,
                        principalSchema: "Venta",
                        principalTable: "Empleado",
                        principalColumn: "IdEmpleado");
                    table.ForeignKey(
                        name: "FK_Venta_PuntoDeVenta_IdPuntoDeVentaNavigationIdPuntoDeVenta",
                        column: x => x.IdPuntoDeVentaNavigationIdPuntoDeVenta,
                        principalSchema: "Venta",
                        principalTable: "PuntoDeVenta",
                        principalColumn: "IdPuntoDeVenta");
                    table.ForeignKey(
                        name: "FK_Venta_TipoDeComprobante_IdTipoDeComprobanteNavigationIdTipoDeComprobante",
                        column: x => x.IdTipoDeComprobanteNavigationIdTipoDeComprobante,
                        principalSchema: "Venta",
                        principalTable: "TipoDeComprobante",
                        principalColumn: "IdTipoDeComprobante");
                });

            migrationBuilder.CreateTable(
                name: "Comprobante",
                schema: "Venta",
                columns: table => new
                {
                    IdComprobante = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdVenta = table.Column<int>(type: "int", nullable: false),
                    IdVentaNavigationIdVenta = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comprobante", x => x.IdComprobante);
                    table.ForeignKey(
                        name: "FK_Comprobante_Venta_IdVentaNavigationIdVenta",
                        column: x => x.IdVentaNavigationIdVenta,
                        principalSchema: "Venta",
                        principalTable: "Venta",
                        principalColumn: "IdVenta",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LineaDeVenta",
                schema: "Venta",
                columns: table => new
                {
                    IdLineaDeVenta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    NetoGravado = table.Column<int>(type: "int", nullable: false),
                    PorcentajeIva = table.Column<int>(type: "int", nullable: false),
                    MontoIva = table.Column<int>(type: "int", nullable: false),
                    Subtotal = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    IdVenta = table.Column<int>(type: "int", nullable: false),
                    IdInventarioArticulo = table.Column<int>(type: "int", nullable: false),
                    IdInventarioArticuloNavigationIdInventarioArticulo = table.Column<int>(type: "int", nullable: false),
                    IdVentaNavigationIdVenta = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineaDeVenta", x => x.IdLineaDeVenta);
                    table.ForeignKey(
                        name: "FK_LineaDeVenta_Inventario_IdInventarioArticuloNavigationIdInventarioArticulo",
                        column: x => x.IdInventarioArticuloNavigationIdInventarioArticulo,
                        principalSchema: "Articulo",
                        principalTable: "Inventario",
                        principalColumn: "IdInventarioArticulo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LineaDeVenta_Venta_IdVentaNavigationIdVenta",
                        column: x => x.IdVentaNavigationIdVenta,
                        principalSchema: "Venta",
                        principalTable: "Venta",
                        principalColumn: "IdVenta");
                });

            migrationBuilder.CreateTable(
                name: "Pago",
                schema: "Venta",
                columns: table => new
                {
                    IdPago = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Monto = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Ticket = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdVenta = table.Column<int>(type: "int", nullable: false),
                    IdVentaNavigationIdVenta = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pago", x => x.IdPago);
                    table.ForeignKey(
                        name: "FK_Pago_Venta_IdVentaNavigationIdVenta",
                        column: x => x.IdVentaNavigationIdVenta,
                        principalSchema: "Venta",
                        principalTable: "Venta",
                        principalColumn: "IdVenta",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articulo_IdCategoriaNavigationIdCategoria",
                schema: "Articulo",
                table: "Articulo",
                column: "IdCategoriaNavigationIdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Articulo_IdMarcaNavigationIdMarca",
                schema: "Articulo",
                table: "Articulo",
                column: "IdMarcaNavigationIdMarca");

            migrationBuilder.CreateIndex(
                name: "IX_Articulo_IdTipoTalleNavigationIdTipoTalle",
                schema: "Articulo",
                table: "Articulo",
                column: "IdTipoTalleNavigationIdTipoTalle");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_IdCondicionTributariaNavigationIdCondicionTributaria",
                schema: "Venta",
                table: "Cliente",
                column: "IdCondicionTributariaNavigationIdCondicionTributaria");

            migrationBuilder.CreateIndex(
                name: "IX_Comprobante_IdVentaNavigationIdVenta",
                schema: "Venta",
                table: "Comprobante",
                column: "IdVentaNavigationIdVenta");

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_IdSucursalNavigationIdSucursal",
                schema: "Venta",
                table: "Empleado",
                column: "IdSucursalNavigationIdSucursal");

            migrationBuilder.CreateIndex(
                name: "IX_Inventario_CodigoNavigationIdArticulo",
                schema: "Articulo",
                table: "Inventario",
                column: "CodigoNavigationIdArticulo");

            migrationBuilder.CreateIndex(
                name: "IX_Inventario_IdColorNavigationIdColor",
                schema: "Articulo",
                table: "Inventario",
                column: "IdColorNavigationIdColor");

            migrationBuilder.CreateIndex(
                name: "IX_Inventario_IdSucursalNavigationIdSucursal",
                schema: "Articulo",
                table: "Inventario",
                column: "IdSucursalNavigationIdSucursal");

            migrationBuilder.CreateIndex(
                name: "IX_Inventario_IdTalleNavigationIdTalle",
                schema: "Articulo",
                table: "Inventario",
                column: "IdTalleNavigationIdTalle");

            migrationBuilder.CreateIndex(
                name: "IX_LineaDeVenta_IdInventarioArticuloNavigationIdInventarioArticulo",
                schema: "Venta",
                table: "LineaDeVenta",
                column: "IdInventarioArticuloNavigationIdInventarioArticulo");

            migrationBuilder.CreateIndex(
                name: "IX_LineaDeVenta_IdVentaNavigationIdVenta",
                schema: "Venta",
                table: "LineaDeVenta",
                column: "IdVentaNavigationIdVenta");

            migrationBuilder.CreateIndex(
                name: "IX_Pago_IdVentaNavigationIdVenta",
                schema: "Venta",
                table: "Pago",
                column: "IdVentaNavigationIdVenta");

            migrationBuilder.CreateIndex(
                name: "IX_PuntoDeVenta_IdSucursalNavigationIdSucursal",
                schema: "Venta",
                table: "PuntoDeVenta",
                column: "IdSucursalNavigationIdSucursal");

            migrationBuilder.CreateIndex(
                name: "IX_Sucursal_CuitNavigationIdTienda",
                schema: "Venta",
                table: "Sucursal",
                column: "CuitNavigationIdTienda");

            migrationBuilder.CreateIndex(
                name: "IX_Talle_IdTipoTalleNavigationIdTipoTalle",
                schema: "Articulo",
                table: "Talle",
                column: "IdTipoTalleNavigationIdTipoTalle");

            migrationBuilder.CreateIndex(
                name: "IX_Tienda_IdCondicionTributariaNavigationIdCondicionTributaria",
                schema: "Venta",
                table: "Tienda",
                column: "IdCondicionTributariaNavigationIdCondicionTributaria");

            migrationBuilder.CreateIndex(
                name: "IX_TipoDeComprobante_IdCondicionTributariaNavigationIdCondicionTributaria",
                schema: "Venta",
                table: "TipoDeComprobante",
                column: "IdCondicionTributariaNavigationIdCondicionTributaria");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_IdRolNavigationIdRol",
                schema: "Venta",
                table: "Usuario",
                column: "IdRolNavigationIdRol");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_LegajoEmpleadoNavigationIdEmpleado",
                schema: "Venta",
                table: "Usuario",
                column: "LegajoEmpleadoNavigationIdEmpleado");

            migrationBuilder.CreateIndex(
                name: "IX_Venta_DniClienteNavigationIdCliente",
                schema: "Venta",
                table: "Venta",
                column: "DniClienteNavigationIdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Venta_IdEmpleadoNavigationIdEmpleado",
                schema: "Venta",
                table: "Venta",
                column: "IdEmpleadoNavigationIdEmpleado");

            migrationBuilder.CreateIndex(
                name: "IX_Venta_IdPuntoDeVentaNavigationIdPuntoDeVenta",
                schema: "Venta",
                table: "Venta",
                column: "IdPuntoDeVentaNavigationIdPuntoDeVenta");

            migrationBuilder.CreateIndex(
                name: "IX_Venta_IdTipoDeComprobanteNavigationIdTipoDeComprobante",
                schema: "Venta",
                table: "Venta",
                column: "IdTipoDeComprobanteNavigationIdTipoDeComprobante");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comprobante",
                schema: "Venta");

            migrationBuilder.DropTable(
                name: "LineaDeVenta",
                schema: "Venta");

            migrationBuilder.DropTable(
                name: "Pago",
                schema: "Venta");

            migrationBuilder.DropTable(
                name: "Usuario",
                schema: "Venta");

            migrationBuilder.DropTable(
                name: "Inventario",
                schema: "Articulo");

            migrationBuilder.DropTable(
                name: "Venta",
                schema: "Venta");

            migrationBuilder.DropTable(
                name: "Rol",
                schema: "Venta");

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
                schema: "Venta");

            migrationBuilder.DropTable(
                name: "Empleado",
                schema: "Venta");

            migrationBuilder.DropTable(
                name: "PuntoDeVenta",
                schema: "Venta");

            migrationBuilder.DropTable(
                name: "TipoDeComprobante",
                schema: "Venta");

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
                name: "Sucursal",
                schema: "Venta");

            migrationBuilder.DropTable(
                name: "Tienda",
                schema: "Venta");

            migrationBuilder.DropTable(
                name: "CondicionTributaria",
                schema: "Venta");
        }
    }
}

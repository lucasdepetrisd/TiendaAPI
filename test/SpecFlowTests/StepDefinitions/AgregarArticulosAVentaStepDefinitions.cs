using Application.Contracts.UseCasesServices;
using Application.DTOs.Ventas;
using Application.Profiles;
using Application.Services.UseCasesServices;
using AutoMapper;
using Domain.Models.Admin;
using Domain.Models.Articulo;
using Domain.Models.Ventas;
using Domain.Repositories;
using Domain.Repositories.ViewRepositories;
using Moq;

namespace SpecFlowTests.StepDefinitions
{
    [Binding]
    public class AgregarArticulosAVentaStepDefinitions
    {
        private LineaDeVentaDTO _lineaDeVentaDTO = null!;
        private Venta _venta = null!;
        private Articulo _articulo = null!;

        private readonly Mock<ICrudRepository<Sesion>> _sesionRepositoryMock = new Mock<ICrudRepository<Sesion>>();
        private readonly Mock<ICrudRepository<LineaDeVenta>> _lineaDeVentaRepositoryMock = new Mock<ICrudRepository<LineaDeVenta>>();
        private readonly Mock<ICrudRepository<PuntoDeVenta>> _puntoDeVentaRepositoryMock = new Mock<ICrudRepository<PuntoDeVenta>>();
        private readonly Mock<ICrudRepository<Inventario>> _inventarioRepositoryMock = new Mock<ICrudRepository<Inventario>>();
        private readonly Mock<IUsuarioRepository> _usuarioRepositoryMock = new Mock<IUsuarioRepository>();
        private readonly Mock<ICrudRepository<Cliente>> _clienteRepositoryMock = new Mock<ICrudRepository<Cliente>>();
        private readonly Mock<ITiendaRepository> _tiendaRepositoryMock = new Mock<ITiendaRepository>();
        private readonly Mock<ICrudRepository<Venta>> _ventaRepositoryMock = new Mock<ICrudRepository<Venta>>();
        private readonly Mock<IMapper> _mapperMock = new Mock<IMapper>();

        private readonly Mock<IPagoService> _pagoServiceMock = new Mock<IPagoService>();
        private readonly Mock<ILineaDeVentaService> _lineaDeVentaServiceMock = new Mock<ILineaDeVentaService>();

        [Before]
        public void Setup()
        {
            _ventaRepositoryMock.Setup(repo => repo.AddAsync(It.IsAny<Venta>())).Returns(Task.CompletedTask);

            var myProfile = new AutomapperProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            var mapper = new Mapper(configuration);
            _mapperMock.Setup(m => m.Map<LineaDeVentaDTO>(It.IsAny<LineaDeVenta>())).Returns((LineaDeVenta ldv) => mapper.Map<LineaDeVentaDTO>(ldv));
        }

        [Given(@"una venta en proceso en un punto de venta de la sucursal ""([^""]*)""")]
        public void GivenUnaVentaEnProcesoEnUnPuntoDeVentaDeLaSucursal(string nombreSucursalPtoVenta)
        {
            PuntoDeVenta puntoDeVenta = new PuntoDeVenta { IdPuntoDeVenta = 1, Sucursal = new Sucursal { Nombre = nombreSucursalPtoVenta } };
            Usuario usuario = new Usuario { IdUsuario = 1, Empleado = new Empleado { IdEmpleado = 1, Sucursal = puntoDeVenta.Sucursal } };
            Cliente defaultCliente = new Cliente { IdCliente = 0, Nombre = "Consumidor Final", CondicionTributaria = new CondicionTributaria { IdCondicionTributaria = IdCondicionTributaria.ConsumidorFinal } };
            CondicionTributaria condicionTributaria = new CondicionTributaria { IdCondicionTributaria = IdCondicionTributaria.ResponsableInscripto };

            _venta = new Venta(usuario, puntoDeVenta, defaultCliente, condicionTributaria);

            _ventaRepositoryMock.Setup(repo => repo.GetByIdAsync(0)).ReturnsAsync(_venta);
        }

        [Given(@"un articulo con codigo ""([^""]*)"" con los siguientes datos:")]
        public void GivenUnArticuloConCodigoConLosSiguientesDatos(string codigo, Table table)
        {
            var descripcion = table.Rows[0]["Descripcion"];
            var marca = table.Rows[0]["Marca"];
            var categoria = table.Rows[0]["Categoria"];
            var precio = decimal.Parse(table.Rows[0]["Precio"]);
            var porcentajeIva = decimal.Parse(table.Rows[0]["PorcentajeIVA"]);
            var margenGanancia = decimal.Parse(table.Rows[0]["MargenGanancia"]);

            _articulo = new Articulo
            {
                Codigo = codigo,
                Descripcion = descripcion,
                Marca = new Marca { Descripcion = marca },
                Categoria = new Categoria { Descripcion = categoria },
                Costo = precio,
                PorcentajeIVA = porcentajeIva,
                MargenGanancia = margenGanancia
            };
        }

        [Given(@"el inventario disponible para una combinacion de talles y colores para la sucursal ""([^""]*)"" es la siguiente:")]
        public void GivenElInventarioDisponibleParaUnaCombinacionDeTallesYColoresParaLaSucursalEsLaSiguiente(string nombreSucursal, Table table)
        {
            var sucursal = new Sucursal { Nombre = nombreSucursal };

            foreach (var row in table.Rows)
            {
                var idInventario = int.Parse(row["idInventario"]);
                var color = row["Color"];
                var talle = row["Talle"];
                var cantidad = int.Parse(row["Cantidad"]);

                var inventarioItem = new Inventario
                {
                    IdInventario = idInventario,
                    Color = new Color { Nombre = color },
                    Talle = new Talle { Medida = talle },
                    Articulo = _articulo,
                    Cantidad = cantidad,
                    Sucursal = sucursal
                };

                _inventarioRepositoryMock.Setup(repo => repo.GetByIdAsync(inventarioItem.IdInventario)).ReturnsAsync(inventarioItem);
            }
        }

        [When(@"agrego a la venta con cantidad (.*) el inventario de id (.*):")]
        public async void WhenAgregoALaVentaConCantidadElInventarioDeId(int cantidad, int idInventario)
        {
            var ventaService = new VentaService(
                _ventaRepositoryMock.Object,
                _lineaDeVentaRepositoryMock.Object,
                _puntoDeVentaRepositoryMock.Object,
                _clienteRepositoryMock.Object,
                _sesionRepositoryMock.Object,
                _inventarioRepositoryMock.Object,
                _usuarioRepositoryMock.Object,
                _tiendaRepositoryMock.Object,
                _mapperMock.Object,
                _lineaDeVentaServiceMock.Object,
                _pagoServiceMock.Object
            );

            _lineaDeVentaDTO = await ventaService.AgregarLineaDeVenta(_venta.IdVenta, cantidad, idInventario);
        }

        [Then(@"la linea de venta sera de la siguiente manera:")]
        public void ThenLaLineaDeVentaSeraDeLaSiguienteManera(Table table)
        {
            var cantidad = int.Parse(table.Rows[0]["Cantidad"]);
            var codigo = table.Rows[0]["Codigo"];
            var descripcion = table.Rows[0]["Descripcion"];
            var talle = table.Rows[0]["Talle"];
            var color = table.Rows[0]["Color"];
            var netoGravado = decimal.Parse(table.Rows[0]["NetoGravado"]);
            var montoIva = decimal.Parse(table.Rows[0]["MontoIVA"]);
            var subtotal = decimal.Parse(table.Rows[0]["Subtotal"]);

            // Asserting the properties of the linea de venta DTO
            Assert.Equal(cantidad, _lineaDeVentaDTO.Cantidad);
            Assert.Equal(codigo, _lineaDeVentaDTO.Inventario.Articulo.Codigo);
            Assert.Equal(descripcion, _lineaDeVentaDTO.Inventario.Articulo.Descripcion);
            Assert.Equal(talle, _lineaDeVentaDTO.Inventario.Talle.Medida);
            Assert.Equal(color, _lineaDeVentaDTO.Inventario.Color.Nombre);
            Assert.Equal(netoGravado, _lineaDeVentaDTO.NetoGravado);
            Assert.Equal(montoIva, _lineaDeVentaDTO.MontoIVA);
            Assert.Equal(subtotal, _lineaDeVentaDTO.Subtotal);
        }

        [Then(@"el total de la venta sera (.*)\.")]
        public void ThenElTotalDeLaVentaSera_(int total)
        {
            Assert.Equal(total, _lineaDeVentaDTO.Venta.Monto);
        }
    }
}


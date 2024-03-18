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
    public class IniciarVentaStepDefinitions
    {
        private int _sesionId = 1;
        private Cliente _defaultCliente = null!;
        private VentaDTO _ventaDTO = null!;
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
            var puntoDeVenta = new PuntoDeVenta { IdPuntoDeVenta = 1, Sucursal = new Sucursal { IdSucursal = 1, Nombre = "Sucursal" } };
            var usuario = new Usuario { IdUsuario = 1, Empleado = new Empleado { IdEmpleado = 1, Sucursal = puntoDeVenta.Sucursal } };
            //var defaultCliente = new Cliente { IdCliente = 0, Nombre = "Consumidor Final", CondicionTributaria = new CondicionTributaria { IdCondicionTributaria = IdCondicionTributaria.ConsumidorFinal } };
            var tienda = new Tienda { CondicionTributaria = new CondicionTributaria { IdCondicionTributaria = IdCondicionTributaria.ResponsableInscripto } };
            var sesion = new Sesion { IdSesion = _sesionId, FechaFin = null, IdPuntoDeVenta = puntoDeVenta.IdPuntoDeVenta, IdUsuario = usuario.IdUsuario };
            var ventaDTO = new VentaDTO();

            _sesionRepositoryMock.Setup(repo => repo.GetByIdAsync(_sesionId)).ReturnsAsync(sesion);
            _puntoDeVentaRepositoryMock.Setup(repo => repo.GetByIdAsync(sesion.IdPuntoDeVenta)).ReturnsAsync(puntoDeVenta);
            _usuarioRepositoryMock.Setup(repo => repo.GetByIdAsync(sesion.IdUsuario)).ReturnsAsync(usuario);
            _tiendaRepositoryMock.Setup(repo => repo.GetFirstOrDefault()).ReturnsAsync(tienda);
            _ventaRepositoryMock.Setup(repo => repo.AddAsync(It.IsAny<Venta>())).Returns(Task.CompletedTask);

            var myProfile = new AutomapperProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            var mapper = new Mapper(configuration);
            _mapperMock.Setup(m => m.Map<VentaDTO>(It.IsAny<Venta>())).Returns((Venta v) => mapper.Map<VentaDTO>(v));
        }

        [Given(@"el cliente por defecto ya existe en el sistema con la siguiente información")]
        public void GivenElClienteYaExisteEnElSistemaConLaSiguienteInformacion(Table table)
        {
            var clienteInfo = table.Rows[0];

            string nombre = clienteInfo["Nombre"];
            string condicionTributaria = clienteInfo["Condición Tributaria"];

            Enum.TryParse(condicionTributaria, out IdCondicionTributaria condTributariaEnum);

            _defaultCliente = new Cliente
            {
                Nombre = nombre,
                CondicionTributaria = new CondicionTributaria { IdCondicionTributaria = condTributariaEnum }
            };

            _clienteRepositoryMock.Setup(repo => repo.GetByIdAsync(0)).ReturnsAsync(_defaultCliente);
        }

        [When(@"inicio la venta con el ID de sesion (.*)\.")]
        public async void WhenInicioLaVentaConElIDDeSesion_(int sesionId)
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

            _ventaDTO = await ventaService.IniciarVenta(sesionId);
        }

        [Then(@"se inicia la venta exitosamente\.")]
        public void ThenSeIniciaLaVentaExitosamente_()
        {
            Assert.NotNull(_ventaDTO);

            Assert.Equal(EstadoVenta.Pendiente.ToString(), _ventaDTO.Estado);
        }

        [Then(@"se asocia al cliente con la condición tributaria ""([^""]*)""\.")]
        public void ThenSeAsociaAlClienteConLaCondicionTributaria_(string condicionTributaria)
        {
            Assert.Equal(condicionTributaria, _ventaDTO.Cliente.CondicionTributaria!.Nombre);
        }

        [Then(@"se asocia la venta al tipo de comprobante ""([^""]*)""\.")]
        public void ThenSeAsociaLaVentaAlTipoDeComprobante_(string tipoComprobante)
        {
            Assert.Equal(tipoComprobante, _ventaDTO.TipoDeComprobante.Nombre);
        }
    }
}

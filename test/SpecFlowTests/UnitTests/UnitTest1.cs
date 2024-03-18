using Domain.Models.Admin;
using Domain.Models.Articulo;
using Domain.Models.Ventas;

namespace UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void TipoDeComprobanteFacturaBConEmisorRIYReceptorCF()
        {
            string nombreComprobante = "Factura B";

            CondicionTributaria condicionTributariaEmisor = new CondicionTributaria { IdCondicionTributaria = IdCondicionTributaria.ResponsableInscripto };
            CondicionTributaria condicionTributariaReceptor = new CondicionTributaria { IdCondicionTributaria = IdCondicionTributaria.ConsumidorFinal };

            TipoDeComprobante tipoComp = new TipoDeComprobante(condicionTributariaEmisor, condicionTributariaReceptor);

            Assert.Equal(nombreComprobante, tipoComp.Nombre);
        }

        [Fact]
        public void CalcularSubtotalMedianteLineaDeVenta()
        {
            int cantidadComprar = 1;

            Articulo articulo = new Articulo
            {
                Costo = 120_000,
                PorcentajeIVA = 21,
                MargenGanancia = 50
            };

            Inventario inventario = new Inventario
            {
                Articulo = articulo,
                Cantidad = 10,
            };

            LineaDeVenta ldv = new LineaDeVenta(cantidadComprar, inventario);

            decimal subtotal = ldv.CalcularSubtotal();

            Assert.Equal(217_800, subtotal);
        }
    }
}
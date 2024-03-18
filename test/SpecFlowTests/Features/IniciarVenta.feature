Feature: Iniciar Venta
	Como vendedor
	Quiero iniciar una Venta
	Para habilitar la carga de artículos

@venta
Scenario: Se asigna automáticamente al cliente como "Consumidor Final" y al tipo de comprobante como "Factura B" al iniciar la venta.
	Given el cliente por defecto ya existe en el sistema con la siguiente información
        | Nombre           | Condición Tributaria  |
        | Consumidor Final | ConsumidorFinal       |
	When inicio la venta con el ID de sesion 1.
	Then se inicia la venta exitosamente.
	And se asocia al cliente con la condición tributaria "ConsumidorFinal".
	And se asocia la venta al tipo de comprobante "Factura B".

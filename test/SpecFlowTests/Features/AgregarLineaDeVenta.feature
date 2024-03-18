Feature: Agregar articulos a venta
  Como vendedor
  Quiero agregar artículos a las ventas
  Para registrar las compras de los clientes y conocer el total de la venta

Scenario: Agregar articulo a la venta con exito
    Given una venta en proceso en un punto de venta de la sucursal "Centro"
    And un articulo con codigo "1234" con los siguientes datos:
      | Descripcion      | Marca  | Categoria  | Precio | PorcentajeIVA | MargenGanancia |
      | Zapatillas altas | Adidas | Zapatillas | 1000   |      21       |      30        |
    And el inventario disponible para una combinacion de talles y colores para la sucursal "Centro" es la siguiente:
      | idInventario  | Color  | Talle   | Cantidad |
      |       1       | Blanco | 38      | 10       |
      |       2       | Negro  | 40      | 5        |
      |       3       | Rojo   | 38      | 8        |
    When agrego a la venta con cantidad 1 el inventario de id 3:
    Then la linea de venta sera de la siguiente manera:
      | Cantidad | Codigo | Descripcion      | Talle | Color | NetoGravado | MontoIVA | Subtotal |
      | 1        | 1234   | Zapatillas altas | 38    | Rojo  | 1300        | 273      | 1573     |
    And el total de la venta sera 1573.
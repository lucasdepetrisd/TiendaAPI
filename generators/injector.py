import os

def modify_files(directory):
    for filename in os.listdir(directory):
        if filename.endswith('.cs') and not any(x in filename for x in ["Venta", "Base"]):
            filepath = os.path.join(directory, filename)
            with open(filepath, 'r') as file:
                content = file.read()

            # Search for the pattern to modify
            if 'public ' in content and 'Controller(' in content and 'I' in content and 'service)' in content:
                modified_content = content.replace('(I', '(I').replace(' : BaseController<', '_service = service\n    def __init__(self, service):')
                modified_content = modified_content.replace('Controller(', 'Controller(_service)\n        self._service = _service\n')
                
                # Write the modified content back to the file
                with open(filepath, 'w') as file:
                    file.write(modified_content)

# Replace 'directory_path' with the path to your directory containing the .cs files
directory_path = 'src/WebAPI/Controllers/'
modify_files(directory_path)


# Print text

# entities = ['Sesion', 'Talle', 'CondicionTributaria', 'Cliente', 'Empleado',
#                 'Venta', 'TipoTalle', 'Usuario', 'Comprobante', 'Tienda', 'Marca', 'Pago', 'Rol',
#                 'Color', 'LineaDeVenta', 'Inventario', 'Categoria', 'Articulo', 'PuntoDeVenta',
#                 'TipoDeComprobante', 'Sucursal']

# for entity in sorted(entities):
#     print(f"services.AddScoped<IRepository<{entity}>, {entity}Repository>();")
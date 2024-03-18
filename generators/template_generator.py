# Function to create a new C# file based on a template
def create_cs_file(file_name):
    template_file = "template.cs"
    new_file_name = f"{file_name}Repository.cs"

    with open(template_file, "r") as template:
        template_content = template.read()

    with open(new_file_name, "w") as new_file:
        new_file.write(template_content.replace("$classname$", file_name).replace("$classnamelower$", file_name.lower()))

# List of strings
strings_list = ['Sesion', 'Talle', 'CondicionTributaria', 'Cliente', 'Empleado',
                'Venta', 'TipoTalle', 'Usuario', 'Comprobante', 'Tienda', 'Marca', 'Pago', 'Rol',
                'Color', 'LineaDeVenta', 'Inventario', 'Categoria', 'Articulo', 'PuntoDeVenta',
                'TipoDeComprobante', 'Sucursal']  # Add your list of strings here

# Create a new C# file for each string
for string in strings_list:
    create_cs_file(string)

print("Files created successfully!")

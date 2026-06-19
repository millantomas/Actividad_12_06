
partial class Program
{
    static List<string> productosVenta = new List<string>();
    static List<double> preciosVenta = new List<double>();

    const double MontoMinimoDescuento = 1000.0;
    const double PorcentajeDescuento = 10.0;

    static void SistemaVentas()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine("       SISTEMA DE VENTAS (POS)          ");
            Console.WriteLine("========================================");
            Console.WriteLine("1. Registrar Producto a la Venta");
            Console.WriteLine("2. Mostrar Carrito y Calcular Total");
            Console.WriteLine("3. Vaciar Carrito (Nueva Venta)");
            Console.WriteLine("4. Salir");
            Console.WriteLine("========================================");
            Console.Write("Seleccione una opción: ");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    RegistrarProducto();
                    break;
                case "2":
                    MostrarReporteVenta();
                    break;
                case "3":
                    VaciarCarrito();
                    break;
                case "4":
                    Console.WriteLine("\nCerrando el sistema de ventas...");
                    return;
                default:
                    Console.WriteLine("\nOpción no válida. Intente de nuevo.");
                    PresionarTecla();
                    break;
            }
        }
    }

    static void RegistrarProducto()
    {
        Console.Clear();
        Console.WriteLine("--- REGISTRAR ARTÍCULO ---");

        Console.Write("Nombre del producto: ");
        string nombre = Console.ReadLine();

        //validacion para evitar nulos o vacios
        if (string.IsNullOrWhiteSpace(nombre))
        {
            Console.WriteLine("\nError: El nombre del producto no puede estar vacío.");
            PresionarTecla();
            return;
        }

        double precio = 0;
        while (true)
        {
            Console.Write($"Precio de '{nombre}': ");
            //validacion para evitar que ingresen numeros negativos
            if (double.TryParse(Console.ReadLine(), out precio) && precio > 0)
            {
                break;
            }
            Console.WriteLine("Por favor, ingrese un precio numérico mayor a 0.");
        }

        productosVenta.Add(nombre);
        preciosVenta.Add(precio);

        Console.WriteLine($"\n¡'{nombre}' añadido al carrito con éxito!");
        PresionarTecla();
    }

    static void MostrarReporteVenta()
    {
        Console.Clear();
        Console.WriteLine("========================================");
        Console.WriteLine("          RESUMEN DE LA COMPRA          ");
        Console.WriteLine("========================================");

        if (productosVenta.Count == 0)
        {
            Console.WriteLine("El carrito está vacío. No hay artículos registrados.");
            PresionarTecla();
            return;
        }

        for (int i = 0; i < productosVenta.Count; i++)
        {
            Console.WriteLine($"- {productosVenta[i]}: ${preciosVenta[i]:F2}");
        }

        Console.WriteLine("----------------------------------------");

        double totalBruto = preciosVenta.Sum();
        Console.WriteLine($"Total Bruto: ${totalBruto:F2}");

        double descuento = 0;
        if (totalBruto > MontoMinimoDescuento)
        {
            descuento = totalBruto * (PorcentajeDescuento / 100);
            Console.WriteLine($"Descuento Aplicado ({PorcentajeDescuento}%): -${descuento:F2}");
        }
        else
        {
            Console.WriteLine($"Descuento Aplicado: $0.00 (No supera los ${MontoMinimoDescuento})");
        }

        double totalNeto = totalBruto - descuento;
        Console.WriteLine($"TOTAL A PAGAR: ${totalNeto:F2}");

        Console.WriteLine("----------------------------------------");

        int idxMasCaro = ObtenerIndiceProductoMasCaro();
        Console.WriteLine($"Artículo más caro: '{productosVenta[idxMasCaro]}' (${preciosVenta[idxMasCaro]:F2})");
        Console.WriteLine("========================================");

        PresionarTecla();
    }

    static int ObtenerIndiceProductoMasCaro()
    {
        double precioMaximo = preciosVenta[0];
        int indiceMaximo = 0;

        for (int i = 1; i < preciosVenta.Count; i++)
        {
            if (preciosVenta[i] > precioMaximo)
            {
                precioMaximo = preciosVenta[i];
                indiceMaximo = i;
            }
        }
        return indiceMaximo;
    }

    static void VaciarCarrito()
    {
        productosVenta.Clear();
        preciosVenta.Clear();
        Console.WriteLine("\nEl carrito ha sido vaciado. Listo para una nueva venta.");
        PresionarTecla();
    }
}
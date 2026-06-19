
partial class Program
{
    static List<string> listaTitulos = new List<string>();
    static List<string> listaAutores = new List<string>();

    static void SistemaBiblioteca()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine("        SISTEMA DE BIBLIOTECA           ");
            Console.WriteLine("========================================");
            Console.WriteLine("1. Registrar Nuevo Libro");
            Console.WriteLine("2. Buscar Libro");
            Console.WriteLine("3. Ver Catálogo Completo");
            Console.WriteLine("4. Ver Total de Libros Disponibles");
            Console.WriteLine("5. Salir");
            Console.WriteLine("========================================");
            Console.Write("Seleccione una opción: ");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    RegistrarLibro();
                    break;
                case "2":
                    BuscarLibro();
                    break;
                case "3":
                    MostrarCatalogo();
                    break;
                case "4":
                    MostrarContadorTotal();
                    break;
                case "5":
                    Console.WriteLine("\nCerrando el sistema de biblioteca...");
                    return;
                default:
                    Console.WriteLine("\nOpción no válida. Intente de nuevo.");
                    PresionarTecla();
                    break;
            }
        }
    }

    static void RegistrarLibro()
    {
        Console.Clear();
        Console.WriteLine("--- REGISTRAR NUEVO LIBRO ---");

        Console.Write("Ingrese el título del libro: ");
        string titulo = Console.ReadLine();

        Console.Write("Ingrese el autor del libro: ");
        string autor = Console.ReadLine();


        if (!string.IsNullOrWhiteSpace(titulo) && !string.IsNullOrWhiteSpace(autor))
        {
            listaTitulos.Add(titulo);
            listaAutores.Add(autor);
            Console.WriteLine("\n¡Libro registrado con éxito en el inventario!");
        }
        //validacion para evitar que tanto el autor como el libro esten vacios o sean nulos
        else
        {
            Console.WriteLine("\nError: El título y el autor no pueden estar vacíos.");
        }

        PresionarTecla();
    }

    static void BuscarLibro()
    {
        Console.Clear();
        Console.WriteLine("--- MOTOR DE BÚSQUEDA ---");
        Console.Write("Ingrese el título o autor a buscar: ");
        string busqueda = Console.ReadLine();

        bool encontrado = false;

        for (int i = 0; i < listaTitulos.Count; i++)
        {
            // verficai si la busqueda coincide con el título O con el autor
            bool coincideTitulo = listaTitulos[i].Contains(busqueda, StringComparison.OrdinalIgnoreCase);
            bool coincideAutor = listaAutores[i].Contains(busqueda, StringComparison.OrdinalIgnoreCase);

            if (coincideTitulo || coincideAutor)
            {
                Console.WriteLine($"- Encontrado -> Título: \"{listaTitulos[i]}\" | Autor: {listaAutores[i]}");
                encontrado = true;
            }
        }

        if (!encontrado)
        {
            Console.WriteLine("\nNo se encontraron libros que coincidan con la búsqueda.");
        }

        PresionarTecla();
    }

    static void MostrarCatalogo()
    {
        Console.Clear();
        Console.WriteLine("--- CATÁLOGO DE LA BIBLIOTECA ---");

        if (listaTitulos.Count == 0)
        {
            Console.WriteLine("El catálogo está vacío. No hay libros registrados.");
        }
        else
        {
            // recorremos las listas usando el índice para mostrar los datos emparejados
            for (int i = 0; i < listaTitulos.Count; i++)
            {
                Console.WriteLine($"{i + 1}. \"{listaTitulos[i]}\" - {listaAutores[i]}");
            }
        }

        PresionarTecla();
    }

    static void MostrarContadorTotal()
    {
        Console.Clear();
        Console.WriteLine("--- INDICADOR DE VOLUMEN TOTAL ---");

        // contamos cuántos elementos tiene cualquiera de las listas ya que estan pseudo sincronizadas al tener la necesidad de dos datos por cada libro (autor y titulo)
        int totalLibros = listaTitulos.Count;

        Console.WriteLine($"Actualmente hay {totalLibros} libros disponibles en la biblioteca.");
        Console.WriteLine("========================================");

        PresionarTecla();
    }

    static void PresionarTecla()
    {
        Console.WriteLine("\nPresione cualquier tecla para continuar...");
        Console.ReadKey();
    }
}

partial class Program
{
    static List<string> listaNombres = new List<string>();
    static List<string> listaTelefonos = new List<string>();

    static void AgendaContactos()
    {
        while (true)
        {
            //El menu lo genere con ia porque soy un queso con los espaciados lol
            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine("          AGENDA DE CONTACTOS           ");
            Console.WriteLine("========================================");
            Console.WriteLine("1. Agregar Contacto");
            Console.WriteLine("2. Mostrar Todos los Contactos");
            Console.WriteLine("3. Buscar Contacto por Nombre");
            Console.WriteLine("4. Eliminar Contacto");
            Console.WriteLine("5. Salir");
            Console.WriteLine("========================================");
            Console.Write("Seleccione una opción: ");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    AgregarContacto();
                    break;
                case "2":
                    MostrarContactos();
                    break;
                case "3":
                    BuscarContacto();
                    break;
                case "4":
                    EliminarContacto();
                    break;
                case "5":
                    Console.WriteLine("\nSaliendo de la agenda...");
                    return;
                default:
                    Console.WriteLine("\nOpción no válida. Intente de nuevo.");
                    PresionarTeclaParaContinuar();
                    break;
            }
        }
    }

    static void AgregarContacto()
    {
        Console.Clear();
        Console.WriteLine("--- AGREGAR CONTACTO ---");

        Console.Write("Ingrese el nombre: ");
        string nombre = Console.ReadLine();

        Console.Write("Ingrese el teléfono: ");
        string telefono = Console.ReadLine();

        // validacion para evitar registros vacios
        if (!string.IsNullOrWhiteSpace(nombre) && !string.IsNullOrWhiteSpace(telefono))
        {
            listaNombres.Add(nombre);
            listaTelefonos.Add(telefono);
            Console.WriteLine("\n¡Contacto agregado con éxito!");
        }
        else
        {
            Console.WriteLine("\nError: El nombre o el teléfono no pueden estar vacíos.");
        }

        PresionarTeclaParaContinuar();
    }

    static void MostrarContactos()
    {
        Console.Clear();
        Console.WriteLine("--- LISTA DE CONTACTOS ---");

        if (listaNombres.Count == 0)
        {
            Console.WriteLine("La agenda está vacía.");
        }
        else
        {
            for (int i = 0; i < listaNombres.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Nombre: {listaNombres[i]} | Tel: {listaTelefonos[i]}");
            }
        }

        PresionarTeclaParaContinuar();
    }

    static void BuscarContacto()
    {
        Console.Clear();
        Console.WriteLine("--- BUSCAR CONTACTO ---");
        Console.Write("Ingrese el nombre a buscar: ");
        string busqueda = Console.ReadLine();

        bool encontrado = false;

        for (int i = 0; i < listaNombres.Count; i++)
        {
            // usando el oridinalignorecase podemos hacer una comparacion ignorando mayusculas o minusculas
            if (listaNombres[i].Contains(busqueda, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"- Encontrado -> Nombre: {listaNombres[i]} | Tel: {listaTelefonos[i]}");
                encontrado = true;
            }
        }

        if (!encontrado)
        {
            Console.WriteLine("\nNo se encontraron contactos que coincidan con la búsqueda.");
        }

        PresionarTeclaParaContinuar();
    }

    static void EliminarContacto()
    {
        Console.Clear();
        Console.WriteLine("--- ELIMINAR CONTACTO ---");
        Console.Write("Ingrese el nombre exacto del contacto a eliminar: ");
        string nombreAEliminar = Console.ReadLine();

        // buscamos el indice exacto del contacto que queremos eliminar
        int indice = listaNombres.FindIndex(n => n.Equals(nombreAEliminar, StringComparison.OrdinalIgnoreCase));

        if (indice != -1)
        {
            // al eliminar el mismo índice en ambas listas mantenemos la sincronía
            listaNombres.RemoveAt(indice);
            listaTelefonos.RemoveAt(indice);
            Console.WriteLine($"\nEl contacto '{nombreAEliminar}' ha sido eliminado correctamente.");
        }
        else
        {
            Console.WriteLine("\nContacto no encontrado. Asegúrese de escribir el nombre exacto.");
        }

        PresionarTeclaParaContinuar();
    }

    static void PresionarTeclaParaContinuar()
    {
        Console.WriteLine("\nPresione cualquier tecla para continuar...");
        Console.ReadKey();
    }
}
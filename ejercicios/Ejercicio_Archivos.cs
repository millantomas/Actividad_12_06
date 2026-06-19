
partial class Program
{
    static void AgendaArchivo()
    {
        List<string> listaNombres = new List<string>();
        List<string> listaNumeros = new List<string>();
        string nombreArchivo = "agenda.txt";

        Console.WriteLine("1. Registrar nuevo contacto");
        Console.WriteLine("2. Mostrar todos los contactos");
        Console.WriteLine("Seleccione una opción: ");

        string? opcion = Console.ReadLine();
        Console.Clear();

        switch (opcion)
        {
            case "1":
                Console.WriteLine("Ingrese el nombre del contacto: ");
                string? nombre = Console.ReadLine();

                Console.WriteLine("Ingrese el numero del contacto: ");
                string? numero = Console.ReadLine();

                listaNombres.Add(nombre);
                listaNumeros.Add(numero);

                string linea = $"{nombre} - {numero}\n";
                File.AppendAllText(nombreArchivo, linea);

                Console.WriteLine("Contacto guardado con exito");
                break;

            case "2":
                Console.WriteLine("Lista de contactos");

                if (File.Exists(nombreArchivo))
                {
                    List<string> lineasGuardadas = File.ReadAllLines(nombreArchivo).ToList();

                    foreach (string l in lineasGuardadas)
                    {
                        Console.WriteLine(l);
                    }
                }
                else
                {
                    Console.WriteLine("La agenda esta vacia (el archivo aun no existe).");
                }
                break;

            default:
                Console.WriteLine("Opción no válida.");
                break;
        }
    }
}
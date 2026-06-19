partial class Program
{
    const int CantidadAlumnos = 5;
    const double NotaMinima = 6.0;

    static void SistemaNotas()
    {
        string[] nombres = new string[CantidadAlumnos];
        double[] notas = new double[CantidadAlumnos];

        Console.WriteLine("Sistema de Gestión de Notas\n");

        CapturarDatos(nombres, notas);

        MostrarReporte(nombres, notas);

        Console.WriteLine("\nPresione cualquier tecla para salir...");
        Console.ReadKey();
    }

    static void CapturarDatos(string[] nombres, double[] notas)
    {
        for (int i = 0; i < CantidadAlumnos; i++)
        {
            Console.Write($"Ingrese el nombre del alumno {i + 1}: ");
            nombres[i] = Console.ReadLine();
            notas[i] = LeerNotaValida(nombres[i]);
            Console.WriteLine("----------------------------------------");
        }
    }

    static double LeerNotaValida(string nombreAlumno)
    {
        while (true)
        {
            Console.Write($"Ingrese la nota de {nombreAlumno}: ");
            if (double.TryParse(Console.ReadLine(), out double nota) && nota >= 0 && nota <= 10)
            {
                return nota;
            }
            Console.WriteLine("Por favor, ingrese una nota válida (entre 0 y 10).");
        }
    }

    static double CalcularPromedioNotas(double[] notas) => notas.Average();

    static int ObtenerIndiceNotaAlta(double[] notas)
    {
        double max = notas[0];
        int indice = 0;
        for (int i = 1; i < notas.Length; i++)
        {
            if (notas[i] > max) { max = notas[i]; indice = i; }
        }
        return indice;
    }

    static int ObtenerIndiceNotaBaja(double[] notas)
    {
        double min = notas[0];
        int indice = 0;
        for (int i = 1; i < notas.Length; i++)
        {
            if (notas[i] < min) { min = notas[i]; indice = i; }
        }
        return indice;
    }

    static int ContarAprobados(double[] notas) => notas.Count(n => n >= NotaMinima);

    static void MostrarReporte(string[] nombres, double[] notas)
    {
        Console.Clear();
        Console.WriteLine("Reporte academico\n");

        for (int i = 0; i < CantidadAlumnos; i++)
        {
            string estado = notas[i] >= NotaMinima ? "Aprobado" : "Desaprobado";
            Console.WriteLine($"- {nombres[i]}: {notas[i]:F1} [{estado}]");
        }

        int idxAlta = ObtenerIndiceNotaAlta(notas);
        int idxBaja = ObtenerIndiceNotaBaja(notas);
        int aprobados = ContarAprobados(notas);

        Console.WriteLine("\n");
        Console.WriteLine("Estadisticas \n");
        Console.WriteLine($"Promedio General del Curso: {CalcularPromedioNotas(notas):F2}");
        Console.WriteLine($"Nota más Alta: {notas[idxAlta]:F1} ({nombres[idxAlta]})");
        Console.WriteLine($"Nota más Baja: {notas[idxBaja]:F1} ({nombres[idxBaja]})");
        Console.WriteLine($"Alumnos Aprobados: {aprobados} de {CantidadAlumnos}");
        Console.WriteLine($"Alumnos Reprobados: {CantidadAlumnos - aprobados}");
    }
}
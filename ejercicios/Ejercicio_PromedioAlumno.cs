partial class Program
{
    static void PromedioAlumno()
    {
        Console.WriteLine("Ingrese el nombre del alumno");
        string alumno = Console.ReadLine() ?? "Sin valor asignado";

        double[] notas = PedirNotas();
        double promedio = CalcularPromedio(notas);

        MostrarResultado(promedio, alumno);
    }

    private static void MostrarResultado(double promedio, string alumno)
    {
        string estado = promedio >= 6 ? "aprobado!" : "desaprobado!";
        Console.WriteLine($"El promedio del alumno {alumno} es {promedio:F2} asi que esta {estado}");
    }

    private static double[] PedirNotas()
    {
        double[] notas = new double[3];

        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine($"Ingrese la nota numero {i + 1}");
            double num;
            while (!double.TryParse(Console.ReadLine(), out num) || num < 0 || num > 10)
            {
                Console.WriteLine("Nota inválida. Debe ser un número entre 0 y 10. Intente de nuevo:");
            }

            notas[i] = num;
        }
        return notas;
    }

    private static double CalcularPromedio(double[] nums)
    {
        return nums.Sum() / 3;
    }
}

partial class Program
{
    static void Main()
    {
        Console.WriteLine("Ingrese el nombre del alumno");
        string? alumno = Console.ReadLine();

        double[] notas = PedirNotas();
        double promedio = CalcularPromedio(notas);

        if (promedio >= 6)
        {
            Console.WriteLine($"El promedio del alumno {alumno} es {promedio:F2} asi que esta aprobado!");

        }
        else
        {
            Console.WriteLine($"El promedio del alumno {alumno} es {promedio:F2} asi que esta desaprobado!");

        }
    }

    private static double[] PedirNotas()
    {
        double[] notas = new double[3];

        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine($"Ingrese la nota numero {i + 1}");
            notas[i] = double.Parse(Console.ReadLine()!);
        }

        return notas;
    }

    private static double CalcularPromedio(double[] nums)
    {
        double result = nums.Sum();
        return result / nums.Length;
    }
}
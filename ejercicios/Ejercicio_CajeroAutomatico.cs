partial class Program
{
    static void CajeroAutomatico()
    {
        Console.WriteLine("Cajero automatico");

        int opcion = 0;
        double saldo = 0;
        do
        {
            Console.WriteLine("1.Consultar saldo");
            Console.WriteLine("2.Depositar dinero");
            Console.WriteLine("3.Extraer dinero");
            Console.WriteLine("4.Salir");


            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                opcion = 0; // Esto forzará a caer en el 'default'
            }
            switch (opcion)
            {
                case 1:
                    MostrarSaldo(saldo);
                    break;
                case 2:
                    DepositarDinero(ref saldo);
                    break;
                case 3:
                    ExtraerDinero(ref saldo);
                    break;
                case 4:
                    Console.WriteLine("Gracias por usar nuestros servicios!");
                    break;
                default:
                    Console.WriteLine("Opcion invalida");
                    break;
            }
        } while (opcion != 4);
    }

    private static void MostrarSaldo(double saldo)
    {
        Console.WriteLine($"Su saldo actual es de {saldo:C}");
    }

    private static void DepositarDinero(ref double saldo)
    {
        double deposito = 0;
        do
        {
            Console.WriteLine("Ingrese el dinero a depositar (o ingrese 0 para cancelar):");
            deposito = LeerDoubleSeguro();
            if (deposito == 0)
            {
                Console.WriteLine("Operacion cancelada. Volviendo al menu principal");
                return;
            }
            if (deposito < 0)
            {
                Console.WriteLine("Monto invalido. El monto ingresado tiene que ser mayor a 0.");
            }
        } while (deposito < 0);
        saldo += deposito;
        Console.WriteLine($"Se deposito con exito! Su saldo actual es de {saldo:C}");
    }

    private static void ExtraerDinero(ref double saldo)
    {
        if (saldo <= 0)
        {
            Console.WriteLine("Error: no posee fondos suficientes para realizar una extraccion. Su saldo es $0,00");
            return;
        }
        double cantidadARetirar = 0;
        do
        {
            Console.WriteLine($"Ingrese el dinero a retirar (o ingrese 0 para cancelar):");
            cantidadARetirar = LeerDoubleSeguro();
            if (cantidadARetirar == 0)
            {
                Console.WriteLine("Operacion cancelada. Volviendo al menu principal");
                return;
            }
            if (cantidadARetirar < 0 || cantidadARetirar > saldo)
            {
                Console.WriteLine($"Monto invalido. Debe ser un numero mayor a 0 y menor o igual a su saldo actual ({saldo:C})");
            }
        } while (cantidadARetirar < 0 || cantidadARetirar > saldo);
        saldo -= cantidadARetirar;
        Console.WriteLine($"Se retiro con exito! su saldo actual es de {saldo:C}");
    }

    private static double LeerDoubleSeguro()
    {
        double numero;
        while (!double.TryParse(Console.ReadLine(), out numero))
        {
            Console.WriteLine("Entrada invalida. Por favor, ingrese un numero valido:");
        }
        return numero;
    }
}
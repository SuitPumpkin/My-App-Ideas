using System;
using System.Text.RegularExpressions;
class Program
{
    
    /// <summary>
    /// Funcion principal
    /// </summary>
    static int Main()
    {
        while (true)
        {
            switch (Menu())
            {
                case "1":
                    Console.WriteLine("---------------");
                    Console.Write("Hola! Ingresa tu numero binario: ");
                    string binarioStr = Console.ReadLine();
                    Console.WriteLine("---------------");
                    if (Validar(binarioStr, 1) == false)
                    {
                        Console.WriteLine("El valor ingresado no es un binario de 8 bits\n");
                        break;
                    }
                    var dec = BinToDec(binarioStr);
                    Console.WriteLine($"El binario \"{binarioStr}\" en decimal es: {dec}\n");
                    break;
                case "2":
                    Console.WriteLine("---------------");
                    Console.Write("Hola! Ingresa tu numero decimal: ");
                    string decimalStr = Console.ReadLine();
                    Console.WriteLine("---------------");
                    if (Validar(decimalStr, 2) == false)
                    {
                        Console.WriteLine("El valor ingresado no es un decimal\n");
                        break;
                    }
                    var bin = DecToBin(decimalStr);
                    Console.WriteLine($"El decimal \"{decimalStr}\" en binario es: {bin}\n");
                    break;
                case "3":
                    return 0;
                default:
                    Console.WriteLine("---------------");
                    Console.WriteLine("Opcion no valida. Intenta de nuevo.\n");
                    break;
            }
        }
    }
    /// <summary>
    /// Valida el input del usuario
    /// </summary>
    static bool Validar(string input, int type)
    {
        switch (type)
        {
            case 1:
                return input != null && Regex.IsMatch(input, "^[01]+$") && input.Length <= 8;
            case 2:
                return int.TryParse(input, out int n) && n >= 0;
            default:
                break;
        }
        return false;
    }
    /// <summary>
    /// Muestra el menú con las opciones disponibles
    /// </summary>
    static string Menu()
    {
        Console.WriteLine("--- Bin2Dec ---");
        Console.WriteLine("1. Binario a Decimal");
        Console.WriteLine("2. Decimal a Binario");
        Console.WriteLine("3. Salir");
        Console.WriteLine("---------------");
        Console.Write("Elige una opcion: ");
        string opcion = Console.ReadLine();
        return opcion;
    }
    /// <summary>
    /// Convierte un binario a decimal
    /// </summary>
    static int BinToDec(string binarioStr)
    {
        int Decimal = 0;
        int longitud = binarioStr.Length;
        for (int i = 0; i < longitud; i++)
        {
            int num = int.Parse(binarioStr[longitud - i - 1].ToString());
            Decimal += num * (int)Math.Pow(2, i);
        }
        return Decimal;
    }
    /// <summary>
    /// Convierte un decimal a binario
    /// </summary>
    static string DecToBin(string numeroDecimalStr)
    {
        int numeroDecimal = int.Parse(numeroDecimalStr);
        if (numeroDecimal == 0) return "0";
        string binario = "";
        while (numeroDecimal > 0)
        {
            binario = (numeroDecimal % 2) + binario;
            numeroDecimal /= 2;
        }
        return binario;
    }

}
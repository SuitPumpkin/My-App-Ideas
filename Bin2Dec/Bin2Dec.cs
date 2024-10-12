using System;
using System.Text.RegularExpressions;
class Program
{
    static int Main()
    {
        Console.WriteLine("Hola! Ingresa tu número binario: ");
        string Binario = Console.ReadLine();
        var dec = BinToDec(Binario);
        Console.WriteLine($"El binario \"{Binario}\" en decimal es: {dec}");
        // EXTRA
        Console.WriteLine("Hola! Ingresa tu número decimal: ");
        string Decimal = Console.ReadLine();
        var bin = DecToBin(int.parse(Decimal));
        Console.WriteLine($"El decimal \"{Decimal}\" en binario es: {bin}");
    }
    static int BinToDec(string Binario)
    {
        if (Binario != null && Regex.IsMatch(Binario, "^[01]+$"))
        {
            int Decimal = 0;
            int longitud = Binario.Length;
            for (int i = 0; i < longitud; i++)
            {
                int num = int.Parse(Binario[longitud - i - 1].ToString());
                Decimal += num * (int)Math.Pow(2, i);
            }
            return Decimal;
        }
        else { return 0; }
    }
    static string DecToBin(string numeroDecimalStr)
    {
        if (int.TryParse(numeroDecimalStr, out int numeroDecimal))
        {
            if (numeroDecimal == 0) return "0";
            string binario = "";
            while (numeroDecimal > 0)
            {
                binario = (numeroDecimal % 2) + binario;
                numeroDecimal /= 2;
            }
            return binario;
        }
        else { return ""; }
    }

}
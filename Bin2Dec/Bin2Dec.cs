using System;
using System.Text.RegularExpressions;
class Program
{
    static void Main()
    {
        Console.WriteLine("Hola! Ingresa tu número binario: ");
        string Binario = Console.ReadLine();
        if (Binario != null && Regex.IsMatch(Binario, "^[01]+$"))
        {
            int Decimal = 0;
            int longitud = Binario.Length;
            for (int i = 0; i < longitud; i++)
            {
                int num = int.Parse(Binario[longitud - i - 1].ToString());
                Decimal += num * (int)Math.Pow(2, i);
            }
            Console.WriteLine($"El binario \"{Binario}\" en decimal es: {Decimal}");
        }
        else
        {
            Console.WriteLine("El texto ingresado no es un binario válido!!");
        }
    }
}
using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        
        Console.WriteLine("Введіть колір у HEX-форматі:");
        string input = Console.ReadLine();

        
        string pattern = @"^#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$";

        
        if (Regex.IsMatch(input, pattern))
        {
            Console.WriteLine("Введений рядок є правильним HEX-кольором.");
        }
        else
        {
            Console.WriteLine("Введений рядок не є правильним HEX-кольором.");
        }
    }
}

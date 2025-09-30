using System;
internal class Program
{
    static void Main()
    {
        Console.WriteLine("Enter number: ");
        int number = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter n: ");
        int n = int.Parse(Console.ReadLine());
        if (n > number.ToString().Length)
        {
            Console.WriteLine("-");
        }
        else
        {
            int nDigit = (number / (int)Math.Pow(10, n - 1)) % 10;
            Console.WriteLine($"Result = {nDigit}");
        }

    }
}


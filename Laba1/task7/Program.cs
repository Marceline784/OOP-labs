using System;
internal class Program
{
    static void Main()
    {
        Console.WriteLine("Enter n: ");
        int n = int.Parse(Console.ReadLine());

        int lastDigit = n % 10;
        Console.WriteLine($"Last digit = {lastDigit}");
    }
}


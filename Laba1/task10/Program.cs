using System;
internal class Program
{
    static void Main()
    {
        Console.WriteLine("Enter n: ");
        int n = int.Parse(Console.ReadLine());
        bool result = n % 9 == 0 || n % 11 == 0 || n % 13 == 0;
        Console.WriteLine(result);
    }
}


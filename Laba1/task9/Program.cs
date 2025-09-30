using System;
internal class Program
{
    static void Main()
    {
        Console.WriteLine("Enter n: ");
        int n = int.Parse(Console.ReadLine());
        bool result = n > 20 && n % 2 != 0;
        Console.WriteLine(result);
    }
}


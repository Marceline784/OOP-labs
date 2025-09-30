using System;
internal class Program
{
    static void Main()
    {
        Console.WriteLine("Enter a: ");
        int a = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter b: ");
        int b = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter c: ");
        int c = int.Parse(Console.ReadLine());
        int biggest;
        if (a > b && a > c)
        {
            biggest = a;
        }
        else if (b > a && b > c)
        {
            biggest = b;
        }
        else
        {
            biggest = c;
        }
        Console.WriteLine($"Result = {biggest}");
    }
}


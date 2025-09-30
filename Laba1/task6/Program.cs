using System;
internal class Program
{
    static void Main()
    {
        Console.WriteLine("Enter a: ");
        float a = float.Parse(Console.ReadLine());
        Console.WriteLine("Enter b: ");
        float b = float.Parse(Console.ReadLine());
        Console.WriteLine("Enter h: ");
        float h = float.Parse(Console.ReadLine());
        Console.WriteLine($"a = {a}, b = {b}, h = {h}");
        float area = ((a + b) / 2f) * h;
        Console.WriteLine($"Average = {area}");

    }
}


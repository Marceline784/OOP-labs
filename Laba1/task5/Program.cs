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
        Console.WriteLine($"a = {a}, b = {b}, c = {c}");
        float average = (a + b + c) / 3f;
        Console.WriteLine($"Average = {average}");
    }
}


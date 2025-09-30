using System;
internal class Program
{
    static void Main()
    {
        Console.WriteLine("Enter a: ");
        float a = float.Parse(Console.ReadLine());
        Console.WriteLine("Enter b: ");
        float b = float.Parse(Console.ReadLine());
        Console.WriteLine("Enter c: ");
        float c = float.Parse(Console.ReadLine());
        int negCount = 0;
        if (a < 0)
        {
            negCount++;
        }
        if (b < 0)
        {
            negCount++;
        }
        if (c < 0)
        {
            negCount++;
        }
        if (negCount % 2 == 0)
        {
            Console.WriteLine("Positive");
        }
        else
        {
            Console.WriteLine("Negative");
        }
    }
}

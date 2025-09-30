using System;
internal class Program
{
    static void Main()
    {
        Console.WriteLine("Enter number: ");
        int n = int.Parse(Console.ReadLine());

        long factorial = 1;

        for (int i = 2; i <= n; i++)
        {
            factorial *= i; 
        }

        Console.WriteLine($"Result = {factorial}");
    }
}

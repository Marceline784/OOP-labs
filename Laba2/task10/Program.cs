using System;
    internal class Program
    {
        static void Main()
        {
        Console.WriteLine("Enter n: ");
        int n = int.Parse(Console.ReadLine());

        int[] numbers = new int[n];
        Console.WriteLine("Enter numbers: ");
        for (int i = 0; i < n; i++)
        {
            numbers[i] = int.Parse(Console.ReadLine());
        }
        Console.WriteLine("Enter the difference:");
        int difference = int.Parse(Console.ReadLine());
        bool found = false;
        Console.WriteLine($"Pairs of elements with difference {difference}:");
        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                
                if (Math.Abs(numbers[i] - numbers[j]) == difference)
                {
                    Console.WriteLine($"{{{numbers[i]}, {numbers[j]}}}");
                    found = true; 
                }
            }
        }
        if (!found)
        {
            Console.WriteLine($"No pairs found.");
        }
    }
    }


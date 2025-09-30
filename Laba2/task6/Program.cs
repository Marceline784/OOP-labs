using System;
    class Program
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
        // запам’ятовуємо початок та довжину найдовшої послідовності
        int biggestStart = 0;
        int biggestLen = 1;
        int start = 0;
        int len = 1;
        for (int i = 1; i < n; i++)
        {
            if (numbers[i] == numbers[i - 1]) 
            {
                len++;
            }
            else
            {
                
                start = i;  
                len = 1;  
            }
         
            if (len > biggestLen)
            {
                biggestLen = len;
                biggestStart = start;
            }
        }
        Console.WriteLine("Longest:");
        for (int i = biggestStart; i < biggestStart + biggestLen; i++)
        {
            Console.Write(numbers[i] + " ");
        }
    }
    }


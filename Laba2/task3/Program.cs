using System;
class Program
{
    static void Main()
    {
        int n;
     
        do
        {
            Console.WriteLine("Enter n/4: ");
            n = int.Parse(Console.ReadLine());
        }
        while (n % 4 != 0);
        int[] numbers = new int[n];
        Console.WriteLine("Enter numbers: ");
        for (int i = 0; i < n; i++)
        {
            numbers[i] = int.Parse(Console.ReadLine());
        }
       
        int[] row1 = new int[n/2];
        for (int i = 0; i < n / 4; i++)
        {
            
            row1[i] = numbers[(n / 4) - 1 - i];
           
            row1[(n / 4) + i] = numbers[n - 1 - i];   
        }
       
        int[] row2 = new int[n / 2];
        for (int i = 0; i < n / 2; i++)
        {
            row2[i] = numbers[(n / 4) + i];
        }
        int[] sum = new int[n / 2];
        for (int i = 0; i < n / 2; i++)
        {
            sum[i] = row1[i] + row2[i];
        }

        Console.WriteLine("Row 1: " + string.Join(" ", row1));
        Console.WriteLine("Row 2: " + string.Join(" ", row2));
        Console.WriteLine("Sum:   " + string.Join(" ", sum));

    }
}

using System;
    class Program
    {
        static void Main()
        {
        int n;

        do
        {
            Console.WriteLine("Enter n (>=2): ");
            n = int.Parse(Console.ReadLine());
        }
        while (n < 2);
        bool[] primes = new bool[n + 1];
        for (int i = 2; i <= n ; i++)
        {
            primes[i] = true;
        }
        for (int j = 2; j * j <= n; j++) { 
            if(primes[j]) 
            {
                for (int b = j*j; b <= n; b+=j)
                {
                    primes[b] = false; 
                }
            }
        }
        Console.WriteLine("Prime numbers:");
        for (int i = 2; i <= n; i++)
        {
            if (primes[i])
            {
                Console.Write(i + " ");
            }
        }
    }
    }


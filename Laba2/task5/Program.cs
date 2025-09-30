using System;
    class Program
    {
        static void Main()
        {

         Console.WriteLine("Enter 1 word: ");
        string input1 = Console.ReadLine();
        char[] arr1 = input1.ToCharArray();
 
        Console.WriteLine("Enter 2 word: ");
        string input2 = Console.ReadLine();
        char[] arr2 = input2.ToCharArray();
        Console.WriteLine("Result: ");
        int minlength = Math.Min(arr1.Length, arr2.Length);
       
        for (int i = 0;i < minlength; i++)
        {
            if (arr1[i] < arr2[i]) 
            {
                Console.WriteLine(input1);
                Console.WriteLine(input2);
                return; 
            }
            else if (arr1[i] > arr2[i]) 
            {
                Console.WriteLine(input2);
                Console.WriteLine(input1);
                return;
            }
           
        }
        if (arr1.Length < arr2.Length) 
        {
            Console.WriteLine(input1);
            Console.WriteLine(input2);
        }
        else if (arr1.Length > arr2.Length)
        {
            Console.WriteLine(input2);
            Console.WriteLine(input1);
        }
        else
        {
            Console.WriteLine("Words are equal");
            Console.WriteLine(input1);
            Console.WriteLine(input2);
        }



    }
    }

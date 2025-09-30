using System;
class Program
{
    static void Main()
    {
        Console.WriteLine("Enter 1 sentences: ");
        string input1 = Console.ReadLine();
        string[] words1 = input1.Split(" ");

        Console.WriteLine("Enter 2 sentences: ");
        string input2 = Console.ReadLine();
        string[] words2 = input2.Split(" ");

        int minlength = Math.Min(words1.Length, words2.Length);
        int leftCount = 0;
        int rightCount = 0;
        for (int i = 0; i < minlength; i++)
        {

            if (words1[i] == words2[i])
            {
                leftCount++; 
            }
            else
                break; 
        }
        
        for (int i = 0; i < minlength; i++)
        {

            if (words1[words1.Length - 1 - i] == words2[words2.Length - 1 - i])
            {
                rightCount++; 
            }
            else 
                break;

        }
        if (leftCount == 0 && rightCount == 0)
        {
            Console.WriteLine("No common words at the left and right");
        } else if (leftCount > 0)
        {
            Console.WriteLine($"The largest common end is at the left: {leftCount}");
        } else
        {
            Console.WriteLine($"The largest common end is at the right: {rightCount}");
        }
    }
}

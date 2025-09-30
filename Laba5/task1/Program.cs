using System;
class Chicken
{
    private string name;
    private int age;

    public Chicken(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }

    public string Name
    {
        get { return name; }
        set
        {
            if (value == null || value.Length == 0 || value.Contains(" "))
            {
                throw new ArgumentException("Name cannot be empty");
            }
            name = value;
        }
    }

    public int Age
    {
        get { return age; }
        set
        {
            if (value < 0 || value > 15)
            {
                throw new ArgumentException("Age should be between 0 and 15");
            }
            age = value;
        }
    }

    public double ProductPerDay
    {
        get { return CalculateProductPerDay(); }
    }

    private double CalculateProductPerDay()
    {
        if (this.Age < 6)
        {
            return 3;
        }
        else if (this.Age < 10)
        {
            return 2;
        }
        else
        {
            return 1;
        }
    }
}

class Program
{
    static void Main()
    {


        try
        {
            Console.Write("Enter name: ");
            string name = Console.ReadLine();

            Console.Write("Enter age: ");
            int age = int.Parse(Console.ReadLine());

            Chicken chicken = new Chicken(name, age);

            Console.WriteLine($"Chicken {chicken.Name} (age {chicken.Age}) can produce {chicken.ProductPerDay} eggs per day.");

        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }

    }
}



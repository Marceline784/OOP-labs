using System;
using System.Collections.Generic;
class Dough
{
    private string flourType;
    private string bakingTechnique;
    private double weight;

    public Dough(string flourType, string bakingTechnique, double weight)
    {
        this.FlourType = flourType;
        this.BakingTechnique = bakingTechnique;
        this.Weight = weight;
    }

    public string FlourType
    {
        get { return flourType; }
        set
        {
            if (value != "White" && value != "Wholegrain")
            {
                throw new Exception("Invalid type of dough");
            }
            flourType = value;
        }
    }

    public string BakingTechnique
    {
        get { return bakingTechnique; }
        set
        {
            if (value != "Crispy" && value != "Chewy" && value != "Homemade")
            {
                throw new Exception("Invalid type of dough");
            }
            bakingTechnique = value;
        }
    }

    public double Weight
    {
        get { return weight; }
        set
        {
            if (value < 1 || value > 200)
            {
                throw new Exception("Dough weight should be in range [1..200]");
            }
            weight = value;
        }
    }

    public double Calories
    {
        get
        {
            double baseCalories = 2;
            double flourModifier = 0;
            double techniqueModifier = 0;

            if (flourType == "White")
            {
                flourModifier = 1.5;
            }
            else if (flourType == "Wholegrain")
            {
                flourModifier = 1.0;
            }

            if (bakingTechnique == "Crispy")
            {
                techniqueModifier = 0.9;
            }
            else if (bakingTechnique == "Chewy")
            {
                techniqueModifier = 1.1;
            }
            else if (bakingTechnique == "Homemade")
            {
                techniqueModifier = 1.0;
            }

            return baseCalories * weight * flourModifier * techniqueModifier;
        }
    }

}

class Topping
{
    private string type;
    private double weight;
    public Topping(string type, double weight)
    {
        this.Type = type;
        this.Weight = weight;
    }

    public string Type
    {
        get { return type; }
        set
        {
            if (value != "Meat" && value != "Veggies" && value != "Cheese" && value != "Sauce")
            {
                throw new Exception($"Cannot place {value} on top of pizza");
            }
            type = value;
        }
    }

    public double Weight
    {
        get { return weight; }
        set
        {
            if (value < 1 || value > 50)
            {
                throw new Exception($"{type} weight should be in range [1..50]");
            }
            weight = value;
        }
    }
    public double Calories
    {
        get
        {
            double baseCalories = 2;
            double modifier = 0;

            if (type == "Meat")
                modifier = 1.2;
            else if (type == "Veggies")
                modifier = 0.8;
            else if (type == "Cheese")
                modifier = 1.1;
            else if (type == "Sauce")
                modifier = 0.9;

            return baseCalories * weight * modifier;
        }
    }
}

    class Pizza
{
    private string name;
    private Dough dough;
    private List<Topping> toppings;

    public Pizza(string name, Dough dough)
    {
        this.Name = name;
        this.Dough = dough;
        this.toppings = new List<Topping>();
    }

    public string Name
    {
        get { return name; }
        set
        {
            if (value == "" || value.Length > 15)
            {
                throw new Exception("Pizza name should be between 1 and 15 characters");
            }
            name = value;
        }
    }

    public Dough Dough
    {
        get { return dough; }
        set { dough = value; }
    }
    public void AddTopping(Topping topping)
    {
        if (toppings.Count >= 10)
        {
            throw new Exception("Number of toppings should be in range [0..10].");
        }
        toppings.Add(topping);
    }

    public double GetTotalCalories()
    {
        double total = dough.Calories;
        foreach (var topping in toppings)
        {
            total += topping.Calories;
        }
        return total;
    }


}

class Program
{
    static void Main()
    {
        try
        {
            string[] pizzaParts = Console.ReadLine().Split(' ');
            string pizzaName = pizzaParts[1]; 
            string[] doughParts = Console.ReadLine().Split(' ');
            Dough dough = new Dough(doughParts[1], doughParts[2], double.Parse(doughParts[3]));
            Pizza pizza = new Pizza(pizzaName, dough);

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] parts = input.Split(' ');
                Topping topping = new Topping(parts[1], double.Parse(parts[2]));
                pizza.AddTopping(topping);
            }

            Console.WriteLine($"{pizza.Name} - {pizza.GetTotalCalories():F2} Calories");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
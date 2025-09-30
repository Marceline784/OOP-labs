using System;
using System.Collections.Generic;

class Product
{
    private string name;
    private float cost;

    public string Name
    {
        get { return name; }
        set
        {
            if (value == null || value.Length == 0)
            {
                throw new ArgumentException("Name cannot be empty");
            }
            name = value;
        }
    }
    public float Cost
    {
        get { return cost; }
        set
        {
            if (value < 0)
            {
                throw new Exception("Cost cannot be negative");
            }
            cost = value;
        }
    }
    public Product(string name, float cost)
    {
        this.Name = name;
        this.Cost = cost;
    }
}
class Person
{
    private string name;
    private float money;
    private List<Product> bag;
    public string Name
    {
        get { return name; }
        set
        {
            if (value == null || value.Length == 0)
            {
                throw new Exception("Name cannot be empty");
            }
            name = value;
        }
    }
    public float Money
    {
        get { return money; }
        set
        {
            if (value < 0)
            {
                throw new Exception("Money cannot be negative");
            }
            money = value;
        }
    }
    public Person(string name, float money)
    {
        this.Name = name;
        this.Money = money;
        bag = new List<Product>();
    }
    public List<Product> Bag
    {
        get { return bag; }
    }

    public bool BuyProduct(Product product)
    {
        if (product.Cost <= money)
        {
            money -= product.Cost;
            bag.Add(product);
            Console.WriteLine($"{name} bought {product.Name}");
            return true;
        }
        else
        {
            Console.WriteLine($"{name} can't afford {product.Name}");
            return false;
        }
    }
}
class Program
    {
        static void Main()
        {
        try
        {
            string[] peopleInput = Console.ReadLine().Split(' ');
            List<Person> people = new List<Person>();

            foreach (var p in peopleInput)
            {
                string[] parts = p.Split('=');
                string name = parts[0];
                float money = float.Parse(parts[1]);
                people.Add(new Person(name, money));
            }

            string[] productInput = Console.ReadLine().Split(' ');
            List<Product> products = new List<Product>();

            foreach (var pr in productInput)
            {
                string[] parts = pr.Split('=');
                string name = parts[0];
                float cost = float.Parse(parts[1]);
                products.Add(new Product(name, cost));
            }

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] parts = command.Split(' ');
                string personName = parts[0];
                string productName = parts[1];

                Person buyer = null;
                Product productToBuy = null;

                foreach (var person in people)
                {
                    if (person.Name == personName)
                    {
                        buyer = person;
                        break;
                    }
                }

                foreach (var product in products)
                {
                    if (product.Name == productName)
                    {
                        productToBuy = product;
                        break;
                    }
                }

                if (buyer != null && productToBuy != null)
                {
                    buyer.BuyProduct(productToBuy);
                }
            }

            foreach (var person in people)
            {
                if (person.Bag.Count == 0)
                {
                    Console.WriteLine($"{person.Name} - Nothing bought");
                }
                else
                {
                    List<string> items = new List<string>();
                    foreach (var item in person.Bag)
                    {
                        items.Add(item.Name);
                    }
                    Console.WriteLine($"{person.Name} - {string.Join(", ", items)}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    }

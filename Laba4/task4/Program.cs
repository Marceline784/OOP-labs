using System;
using System.Collections.Generic;

abstract class BagBase
{
    public long Capacity { get; protected set; }
    public long CurrentAmount { get; protected set; }
    public List<Item> Items { get; protected set; }

    public BagBase(long capacity)
    {
        Capacity = capacity;
        CurrentAmount = 0;
        Items = new List<Item>();
    }

    public abstract bool AddItem(string name, long amount);
}
class Item
{
    public string Name { get; set; }
    public long Amount { get; set; }
    public string Type { get; set; } 

    public Item(string name, long amount, string type)
    {
        Name = name;
        Amount = amount;
        Type = type;
    }
    
}
class TreasureBag : BagBase
{
    public long GoldAmount { get; private set; }
    public long GemAmount { get; private set; }
    public long CashAmount { get; private set; }
    public TreasureBag(long capacity) : base(capacity)
    {
        GoldAmount = 0;
        GemAmount = 0;
        CashAmount = 0;
    }

    private string GetTypeByName(string name)
    {
        string lowerName = name.ToLower();

        if (lowerName == "gold")
        {
            return "Gold";
        }
        if (lowerName.Length >= 4 && lowerName.EndsWith("gem"))
        {
            return "Gem";
        }
        if (lowerName.Length == 3)
        {
            return "Cash";
        }
        return null;
    }
    public override bool AddItem(string name, long amount)
    {
        string type = GetTypeByName(name);

        if (type == null)
        {
            return false;
        }
        long newGold = GoldAmount;
        long newGem = GemAmount;
        long newCash = CashAmount;

        switch (type)
        {
            case "Gold":
                newGold += amount;
                break;
            case "Gem":
                newGem += amount;
                break;
            case "Cash":
                newCash += amount;
                break;
        }

        if (newGold < newGem || newGem < newCash)
        {
            return false;
        }

        if (CurrentAmount + amount > Capacity)
        {
            return false;
        }

        bool exists = false;
        for (int i = 0; i < Items.Count; i++)
        {
            if (Items[i].Name == name)
            {
                Items[i].Amount += amount;
                exists = true;
                break;
            }
        }
        if (!exists)
        {
            Items.Add(new Item(name, amount, type));
        }
        CurrentAmount += amount;

        if (type == "Gold")
        {
            GoldAmount += amount;
        }
        else if (type == "Gem")
        {
            GemAmount += amount;
        }
        else if (type == "Cash")
        {
            CashAmount += amount;
        }

        return true;
    }
}
    class Program
    {
        static void Main()
        {
        Console.WriteLine("Enter the bag capacity: ");
        long capacity = long.Parse(Console.ReadLine());
        Console.WriteLine("Enter the treasures: ");
        string[] input = Console.ReadLine().Split(' ');

        TreasureBag bag = new TreasureBag(capacity);
        for (int i = 0; i < input.Length; i += 2)
        {
            string name = input[i];
            long amount = long.Parse(input[i + 1]);
            bag.AddItem(name, amount);
        }

        for (int i = 0; i < bag.Items.Count - 1; i++)
        {
            for (int j = i + 1; j < bag.Items.Count; j++)
            {
                bool swap = false;

                int t1;
                if (bag.Items[i].Type == "Gold") {
                    t1 = 0;
                }
                else if (bag.Items[i].Type == "Gem") {
                    t1 = 1;
                }
                else {
                    t1 = 2; 
                }

                int t2;
                if (bag.Items[j].Type == "Gold") {
                    t2 = 0;
                }
                else if (bag.Items[j].Type == "Gem") {
                    t2 = 1;
                }
                else {
                    t2 = 2; 
                }

                if (t1 > t2) {
                    swap = true;
                }
                else if (t1 == t2)
                {
                    if (string.Compare(bag.Items[i].Name, bag.Items[j].Name) < 0)
                    {
                        swap = true;
                    }
                    else if (bag.Items[i].Name == bag.Items[j].Name)
                    {
                        
                        if (bag.Items[i].Amount > bag.Items[j].Amount)
                        {
                            swap = true;
                        }
                    }
                }

                if (swap)
                {
                    
                    Item temp = bag.Items[i];
                    bag.Items[i] = bag.Items[j];
                    bag.Items[j] = temp;
                }
            }
        }


        string[] typesOrder = { "Gold", "Gem", "Cash" };

        for (int t = 0; t < typesOrder.Length; t++)
        {
            string type = typesOrder[t];
            long total = 0;

            for (int i = 0; i < bag.Items.Count; i++)
            {
                if (bag.Items[i].Type == type)
                {
                    total += bag.Items[i].Amount;
                }
            }

            if (total == 0)
            {
                continue;
            }

            Console.WriteLine($"<{type}> ${total}");

            for (int i = 0; i < bag.Items.Count; i++)
            {
                if (bag.Items[i].Type == type)
                {
                    Console.WriteLine($"##{bag.Items[i].Name} - {bag.Items[i].Amount}");
                }
            }
        }

    }
}
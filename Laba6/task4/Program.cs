using System;
public abstract class Food
{
    public abstract int Happiness { get; }
}
public class Cram : Food
{
    public override int Happiness { get { return 2; } }
}

public class Lembas : Food
{
    public override int Happiness { get { return 3; } }
}

public class Apple : Food
{
    public override int Happiness { get { return 1; } }
}

public class Melon : Food
{
    public override int Happiness { get { return 1; } }
}

public class HoneyCake : Food
{
    public override int Happiness { get { return 5; } }
}

public class Mushrooms : Food
{
    public override int Happiness { get { return -10; } }
}

public class OtherFood : Food
{
    public override int Happiness { get { return -1; } }
}
public abstract class Mood
{
    public abstract string Name { get; }
}
public class Angry : Mood
{
    public override string Name { get { return "Angry"; } }
}

public class Sad : Mood
{
    public override string Name { get { return "Sad"; } }
}

public class Happy : Mood
{
    public override string Name { get { return "Happy"; } }
}
    public class Bliss : Mood
{
    public override string Name { get { return "Bliss"; } }
}

public class FoodFactory
{
    public Food GetFood(string foodName)
    {
        string name = foodName.ToLower();

        switch (name)
        {
            case "cram": return new Cram();
            case "lembas": return new Lembas();
            case "apple": return new Apple();
            case "melon": return new Melon();
            case "honeycake": return new HoneyCake();
            case "mushrooms": return new Mushrooms();
            default: return new OtherFood();
        }
    }
}
public class MoodFactory
{
    public Mood GetMood(int totalHappiness)
    {
        if (totalHappiness < -5) return new Angry();
        if (totalHappiness >= -5 && totalHappiness <= 0) return new Sad();
        if (totalHappiness >= 1 && totalHappiness <= 15) return new Happy();
        return new Bliss();
    }
}
class Program
    {
        static void Main()
        {
        string input = Console.ReadLine();
        string[] foods = input.Split(' ');

        FoodFactory foodFactory = new FoodFactory();
        MoodFactory moodFactory = new MoodFactory();

        int totalHappiness = 0;

        foreach (string foodName in foods)
        {
            string cleanName = foodName.Trim(',', ';', '.', '!', '?').ToLower();
            Food food = foodFactory.GetFood(cleanName);
            totalHappiness += food.Happiness; 
        }

        Mood mood = moodFactory.GetMood(totalHappiness);

        Console.WriteLine(totalHappiness);
        Console.WriteLine(mood.Name);
    }
    }
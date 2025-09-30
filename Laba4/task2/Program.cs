using System;
public enum Season
{
    Autumn = 1,
    Spring = 2,
    Winter = 3,
    Summer = 4
}

public enum DiscountType
{
    None,
    VIP,
    SecondVisit
}
public abstract class Calculator
{
    public abstract float CalculatePrice();
}
public class PriceCalculator : Calculator
{
    private float pricePerDay;
    private int numberOfDays;
    private Season season;
    private DiscountType discount;

    public PriceCalculator(float pricePerDay, int numberOfDays, Season season, DiscountType discount)
    {
        this.pricePerDay = pricePerDay;
        this.numberOfDays = numberOfDays;
        this.season = season;
        this.discount = discount;
    }

    public override float CalculatePrice()
    {
        float basePrice = pricePerDay * numberOfDays * (int)season;

        float discountMultiplier = 1.0f;

        switch (discount)
        {
            case DiscountType.VIP:
                discountMultiplier = 0.80f; 
                break;
            case DiscountType.SecondVisit:
                discountMultiplier = 0.90f; 
                break;
            case DiscountType.None:
                discountMultiplier = 1.0f;
                break;
        }

        return basePrice * discountMultiplier;
    }
}
class Program
    {
        static void Main()
        {
        Console.WriteLine("Enter price per day, number of days, season, discount type: ");
        string[] input = Console.ReadLine().Split();

        float pricePerDay = float.Parse(input[0]);
        int numberOfDays = int.Parse(input[1]);
        Season season = Enum.Parse<Season>(input[2]);

        DiscountType discount = DiscountType.None;
        if (input.Length == 4)
        {
            discount = Enum.Parse<DiscountType>(input[3]);
        }

        Calculator calculator = new PriceCalculator(pricePerDay, numberOfDays, season, discount);
        Console.WriteLine($"{calculator.CalculatePrice():F2}");
    }
    }


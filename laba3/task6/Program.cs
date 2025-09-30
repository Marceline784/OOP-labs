using System;
using System.Collections.Generic;
public class Engine
{
    public string Model { get; set; }
    public int Power { get; set; }
    public string Displacement { get; set; }
    public string Efficiency { get; set; }

    public Engine(string model, int power, string displacement = "n/a", string efficiency = "n/a")
    {
        Model = model;
        Power = power;
        Displacement = displacement;
        Efficiency = efficiency;
    }
  
}
public class Car
{
    public string Model { get; set; }
    public Engine Engine { get; set; }
    public string Weight { get; set; }
    public string Color { get; set; }
    public Car(string model, Engine engine, string weight = "n/a", string color = "n/a")
    {
        Model = model;
        Engine = engine;
        Weight = weight;
        Color = color;
    }
    public void PrintInfo()
    {
        Console.WriteLine($"{Model}:");
        Console.WriteLine($"  {Engine.Model}:");
        Console.WriteLine($"    Power: {Engine.Power}");
        Console.WriteLine($"    Displacement: {Engine.Displacement}");
        Console.WriteLine($"    Efficiency: {Engine.Efficiency}");
        Console.WriteLine($"  Weight: {Weight}");
        Console.WriteLine($"  Color: {Color}");
    }

}
class Program
    {
        static void Main()
        {
        //Console.Write("Enter number: ");
        //int n = int.Parse(Console.ReadLine());
        //List<Engine> engines = new List<Engine>();

        //for (int i = 0; i < n; i++)
        //{
        //    Console.WriteLine($"Engine {i + 1}:");
        //    Console.Write("Enter model: ");
        //    string model = Console.ReadLine();

        //    Console.Write("Enter power: ");
        //    int power = int.Parse(Console.ReadLine());

        //    Console.Write("Enter displacement (or leave empty): ");
        //    string displacement = Console.ReadLine();
        //    if (displacement == null || displacement == "")
        //    {
        //        displacement = "n/a";
        //    }

        //    Console.Write("Enter efficiency (or leave empty): ");
        //    string efficiency = Console.ReadLine();
        //    if (efficiency == null || efficiency == "")
        //    {
        //        efficiency = "n/a";
        //    }

        //    engines.Add(new Engine(model, power, displacement, efficiency));
        //}
        //Console.Write("Enter number: ");
        //int m = int.Parse(Console.ReadLine());
        //List<Car> cars = new List<Car>();

        //for (int i = 0; i < m; i++)
        //{
        //    Console.WriteLine($"Car {i + 1}:");
        //    Console.Write("Enter model: ");
        //    string carModel = Console.ReadLine();

        //    Console.Write("Enter engine model: ");
        //    string engineModel = Console.ReadLine();

        //    bool modelExists = false;
        //    foreach (Car c in cars)
        //    {
        //        if (c.Model == carModel)
        //        {
        //            modelExists = true;
        //            break;
        //        }
        //    }

        //    if (modelExists)
        //    {
        //        Console.WriteLine($"Car with model {carModel} already exists!");
        //        continue;
        //    }

        //    Engine engine = null;
        //    bool engineExists = false;
        //    foreach (Engine eng in engines)
        //    {
        //        if (eng.Model == engineModel)
        //        {
        //            engineExists = true;
        //            engine = eng;
        //            break;
        //        }
        //    }

        //    if (!engineExists)
        //    {
        //        Console.WriteLine($"Engine with model {engineModel} not found!");
        //        continue;
        //    }
        //    Console.Write("Enter weight (or leave empty): ");
        //    string weight = Console.ReadLine();
        //    if (weight == null || weight == "")
        //    {
        //        weight = "n/a";
        //    }

        //    Console.Write("Enter color (or leave empty): ");
        //    string color = Console.ReadLine();
        //    if (color == null || color == "")
        //    {
        //        color = "n/a";
        //    }

        //    cars.Add(new Car(carModel, engine, weight, color));
        //}
        List<Engine> engines = new List<Engine>()
        {
            new Engine("V8-101", 220, "50"),
            new Engine("V4-33", 140, "28", "B")
        };

       
        List<Car> cars = new List<Car>()
        {
            new Car("FordFocus", engines[1], "1300", "Silver"),
            new Car("FordMustang", engines[0]),
            new Car("VolkswagenGolf", engines[1], color: "Orange")
        };
        Console.WriteLine("\nCars info:");
        foreach (var car in cars)
        {
            car.PrintInfo();
            Console.WriteLine();
        }

    }
    }

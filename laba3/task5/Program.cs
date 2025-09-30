using System;
using System.Collections.Generic;
class Car
{
  
    public string Model { get; }
    public double Fuel { get; private set; }
    public double FuelPerKm { get; }
    public double Distance { get; private set; }

    
    public Car(string model, double fuel, double fuelPerKm)
    {
        Model = model;
        Fuel = fuel;
        FuelPerKm = fuelPerKm;
        Distance = 0;
    }
    public void Drive(double distance)
    {
        double neededFuel = distance * FuelPerKm;
        if (neededFuel <= Fuel)
        {
            Fuel -= neededFuel;
            Distance += distance;
        }
        else
        {
            Console.WriteLine("Insufficient fuel for the drive");
        }
    }
    public void ShowInfo()
    {
        Console.WriteLine($"{Model} {Fuel:F2} {Distance}");
    }
}

class Program
    {
        static void Main()
        {
        //List<Car> cars = new List<Car>();

        //Console.Write("Enter number: ");
        //int n = int.Parse(Console.ReadLine());

        //for (int i = 0; i < n; i++)
        //{
        //    Console.Write("Enter model: ");
        //    string model = Console.ReadLine();

        //    Console.Write("Enter fuel amount: ");
        //    double fuel = double.Parse(Console.ReadLine());

        //    Console.Write("Enter fuel consumption per km: ");
        //    double fuelPerKm = double.Parse(Console.ReadLine());

        //    bool modelExists = false;
        //    foreach (Car car in cars)
        //    {
        //        if (car.Model == model)
        //        {
        //            modelExists = true;
        //            break;
        //        }
        //    }

        //    if (!modelExists)
        //    {
        //        Car car = new Car(model, fuel, fuelPerKm);
        //        cars.Add(car);
        //    }
        //    else
        //    {
        //        Console.WriteLine($"Car with model {model} already exists!");
        //    }
        //}
        List<Car> cars = new List<Car>()
        {
            new Car("AudiA4", 23, 0.3),
            new Car("BMW-M2", 45, 0.42)
        };

        List<string> commands = new List<string>()
        {
            "Drive BMW-M2 56",
            "Drive AudiA4 5",
            "Drive AudiA4 13"
        };
        // string command;
        //while ((command = Console.ReadLine()) != "End")
        //{
        foreach (var command in commands)
        {
            string[] parts = command.Split();
            if (parts[0] == "Drive")
            {
                string carModel = parts[1];
                double distance = double.Parse(parts[2]);

                foreach (Car car in cars)
                {
                    if (car.Model == carModel)
                    {
                        car.Drive(distance);
                        break;
                    }
                }
            }
        }
        //}
        foreach (Car car in cars)
        {
            car.ShowInfo();
        }


    }
}


using System;
public class Human
{
    private string firstName;
    private string lastName;

    public Human(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public string FirstName
    {
        get { return firstName; }
        set
        {
            if (!char.IsUpper(value[0]))
                throw new ArgumentException($"Expected upper case letter! Argument: firstName");
            if (value.Length < 4)
                throw new ArgumentException($"Expected length at least 4 symbols! Argument: firstName");
            firstName = value;
        }
    }

    public string LastName
    {
        get { return lastName;}
        set
        {
            if (!char.IsUpper(value[0]))
                throw new ArgumentException($"Expected upper case letter! Argument: lastName");
            if (value.Length < 3)
                throw new ArgumentException($"Expected length at least 3 symbols! Argument: lastName");
            lastName = value;
        }
    }
}

public class Student : Human
{
    private string facultyNumber;

    public Student(string firstName, string lastName, string facultyNumber)
        : base(firstName, lastName)
    {
        FacultyNumber = facultyNumber;
    }

    public string FacultyNumber
    {
        get => facultyNumber;
        private set
        {
            if (value.Length < 5 || value.Length > 10)
                throw new ArgumentException("Invalid faculty number!");
            facultyNumber = value;
        }
    }


    public override string ToString()
    {
        return $"First Name: {FirstName}\nLast Name: {LastName}\nFaculty number: {FacultyNumber}";
    }
}

public class Worker : Human
{
    private decimal weekSalary;
    private double workHoursPerDay;

    public Worker(string firstName, string lastName, decimal weekSalary, double workHoursPerDay)
        : base(firstName, lastName)
    {
        WeekSalary = weekSalary;
        WorkHoursPerDay = workHoursPerDay;
    }

    public decimal WeekSalary
    {
        get { return weekSalary; }
        private set
        {
            if (value <= 10)
                throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
            weekSalary = value;
        }
    }

    public double WorkHoursPerDay
    {
        get
        {
            return workHoursPerDay;
        }
        private set
        {
            if (value < 1 || value > 12)
                throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
            workHoursPerDay = value;
        }
    }

    public decimal SalaryPerHour()
    {
        return WeekSalary / (decimal)(WorkHoursPerDay * 5); 
    }

    public override string ToString()
    {
        return $"First Name: {FirstName}\nLast Name: {LastName}\n" +
               $"Week Salary: {WeekSalary:F2}\nHours per day: {WorkHoursPerDay:F2}\n" +
               $"Salary per hour: {SalaryPerHour():F2}";
    }
}

class Program
    {
        static void Main()
        {
        try
        {
            string[] studentInput = Console.ReadLine().Split();
            Student student = new Student(studentInput[0], studentInput[1], studentInput[2]);

            string[] workerInput = Console.ReadLine().Split();
            Worker worker = new Worker(
                workerInput[0],
                workerInput[1],
                decimal.Parse(workerInput[2]),
                double.Parse(workerInput[3])
            );

            Console.WriteLine(student + "\n");
            Console.WriteLine(worker);
        }
        catch (ArgumentException ae)
        {
            Console.WriteLine(ae.Message);
        }
    }
    }


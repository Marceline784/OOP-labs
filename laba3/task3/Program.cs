using System;
using System.Collections.Generic; 
public class Person
{
    private string name;
    private int age;


    public string Name
    {
        get { return name; } 
        set { name = value; }
    }

    public int Age
    {
        get { return age; }
        set { age = value; }
    }
    public Person(string name, int age)
    {
        this.name = name;
        this.age = age;
    }
}
public class Family
{
    private List<Person> members = new List<Person>();
    public void AddMember(Person member)
    {
        members.Add(member);
    }

    public Person GetOldestMember()
    {
        Person eldest = members[0];
        for (int i = 0; i < members.Count; i++)
        {
            if (members[i].Age > eldest.Age)
            {
                eldest = members[i];
            }
        }
        return eldest;

    }
}
class Program
{
    static void Main()
    {
        Family family = new Family();
        Console.WriteLine("Enter people: ");
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Console.Write("Enter name: ");
            string name = Console.ReadLine();  

            Console.Write("Enter age: ");
            int age = int.Parse(Console.ReadLine());
           
            Person person = new Person(name, age);
            family.AddMember(person);
        }
        Person eldest = family.GetOldestMember();
        Console.WriteLine($"{eldest.Name} {eldest.Age}");
    }
}


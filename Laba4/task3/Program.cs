using System;
using System.Collections.Generic;
abstract class DepartmentBase
{
    public abstract bool AddPatient(string patient);
    public abstract List<string> GetAllPatients();
    public abstract List<string> GetPatientsInRoom(int roomNumber);
}
class Department : DepartmentBase
{
    public string Name { get; set; }
    private const int Rooms = 20;
    private const int BedsPerRoom = 3;
    private List<string> patients;

    public Department()
    {
        patients = new List<string>();
    }
    public override bool AddPatient(string patient)
    {
        if (patients.Count < Rooms * BedsPerRoom)
        {
            patients.Add(patient);
            return true;
        }
        return false;

    }
    public override List<string> GetAllPatients()
    {
        return new List<string>(patients);
    }
    public override List<string> GetPatientsInRoom(int roomNumber)
    {
        List<string> roomPatients = new List<string>();

        if (roomNumber < 1 || roomNumber > Rooms)
            return roomPatients;

        int startIndex = (roomNumber - 1) * BedsPerRoom;

        for (int i = startIndex; i < startIndex + BedsPerRoom && i < patients.Count; i++)
        {
            roomPatients.Add(patients[i]);
        }
        roomPatients.Sort();
        return roomPatients;
    }

}
class Doctor
{
    public string Name { get; set; }
    public List<string> Patients { get; set; }

    public Doctor(string name)
    {
        Name = name;
        Patients = new List<string>();
    }
}

class Program
{
    static void Main()
    {
        List<Department> departments = new List<Department>();
        List<Doctor> doctors = new List<Doctor>();

        Console.WriteLine("Type 'Output' when done: ");

        string line;
        while ((line = Console.ReadLine()) != "Output")
        {
            string[] parts = line.Split();
            string depName = parts[0];
            string doctorName = parts[1] + " " + parts[2];
            string patientName = parts[3];

            Department dep = null;
            for (int i = 0; i < departments.Count; i++)
            {
                if (departments[i].Name == depName)
                {
                    dep = departments[i];
                    break;
                }
            }

            if (dep == null)
            {
                dep = new Department { Name = depName };
                departments.Add(dep);
            }
            dep.AddPatient(patientName);

            Doctor doc = null;
            for (int i = 0; i < doctors.Count; i++)
            {
                if (doctors[i].Name == doctorName)
                {
                    doc = doctors[i];
                    break;
                }
            }

            if (doc == null)
            {
                doc = new Doctor(doctorName);
                doctors.Add(doc);
            }
            doc.Patients.Add(patientName);
        }

        Console.WriteLine("Enter department to output (End to stop):");

        while ((line = Console.ReadLine()) != "End")
        {
            string[] parts = line.Split();
            if (parts.Length == 1)
            {
                string name = parts[0];
                Department dep = null;
                for (int i = 0; i < departments.Count; i++)
                {
                    if (departments[i].Name == name)
                    {
                        dep = departments[i];
                        break;
                    }
                }

                if (dep != null)
                {
                    foreach (var p in dep.GetAllPatients())
                        Console.WriteLine(p);
                }
                else
                {
                    Doctor doc = null;
                    for (int i = 0; i < doctors.Count; i++)
                    {
                        if (doctors[i].Name == name)
                        {
                            doc = doctors[i];
                            break;
                        }
                    }

                    if (doc != null)
                    {
                        doc.Patients.Sort(); 
                        foreach (var p in doc.Patients)
                            Console.WriteLine(p);
                    }
                }
            }
            else if (parts.Length == 2) 
            {
                string depName = parts[0];
                int roomNumber = int.Parse(parts[1]);

                Department dep = null;
                for (int i = 0; i < departments.Count; i++)
                {
                    if (departments[i].Name == depName)
                    {
                        dep = departments[i];
                        break;
                    }
                }

                if (dep != null)
                {
                    foreach (var p in dep.GetPatientsInRoom(roomNumber))
                        Console.WriteLine(p);
                }
            }
        }
    }
}
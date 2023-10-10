using System;
using System.Collections.Generic;
using System.Linq;

class Vehicle
{
    public string RegistrationNumber { get; set; }
    public string Color { get; set; }
    public int NumberOfWheels { get; set; }

    public override string ToString()
    {
        return $"Reg No: {RegistrationNumber}, Color: {Color}, Wheels: {NumberOfWheels}";
    }
}

class Garage<T> : IEnumerable<T> where T : Vehicle
{
    private List<T> vehicles = new List<T>();

    public int Capacity { get; private set; }

    public Garage(int capacity)
    {
        Capacity = capacity;
    }

    public void Park(T vehicle)
    {
        if (vehicles.Count < Capacity)
        {
            vehicles.Add(vehicle);
            Console.WriteLine("Vehicle parked successfully.");
        }
        else
        {
            Console.WriteLine("The garage is full. Cannot park the vehicle.");
        }
    }

    public void Unpark(string registrationNumber)
    {
        T vehicle = vehicles.FirstOrDefault(v => v.RegistrationNumber.Equals(registrationNumber, StringComparison.OrdinalIgnoreCase));
        if (vehicle != null)
        {
            vehicles.Remove(vehicle);
            Console.WriteLine($"Vehicle with registration number {registrationNumber} has been unparked.");
        }
        else
        {
            Console.WriteLine($"Vehicle with registration number {registrationNumber} not found in the garage.");
        }
    }

    public void ListVehicles()
    {
        Console.WriteLine("Vehicles in the garage:");
        foreach (var vehicle in vehicles)
        {
            Console.WriteLine(vehicle);
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        return vehicles.GetEnumerator();
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Garage Application!");

        Console.Write("Enter the capacity of the garage: ");
        int capacity = int.Parse(Console.ReadLine());
        Garage<Vehicle> garage = new Garage<Vehicle>(capacity);

        bool running = true;
        while (running)
        {
            Console.WriteLine("\nMain Menu:");
            Console.WriteLine("1. Park a vehicle");
            Console.WriteLine("2. Unpark a vehicle");
            Console.WriteLine("3. List all vehicles");
            Console.WriteLine("4. Exit");

            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter registration number: ");
                    string regNo = Console.ReadLine();
                    Console.Write("Enter color: ");
                    string color = Console.ReadLine();
                    Console.Write("Enter number of wheels: ");
                    int wheels = int.Parse(Console.ReadLine());

                    Vehicle newVehicle = new Vehicle
                    {
                        RegistrationNumber = regNo,
                        Color = color,
                        NumberOfWheels = wheels
                    };
                    garage.Park(newVehicle);
                    break;

                case 2:
                    Console.Write("Enter registration number of the vehicle to unpark: ");
                    string regNumberToUnpark = Console.ReadLine();
                    garage.Unpark(regNumberToUnpark);
                    break;

                case 3:
                    garage.ListVehicles();
                    break;

                case 4:
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }

        Console.WriteLine("Thank you for using the Garage Application!");
    }
}



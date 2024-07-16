using System;
using System.Collections.Generic;

public class Vehicle
{
    public string Model { get; set; }
    public string Manufacturer { get; set; }
    public int Year { get; set; }
    public decimal RentalPrice { get; set; }

    public Vehicle(string model, string manufacturer, int year, decimal rentalPrice)
    {
        Model = model;
        Manufacturer = manufacturer;
        Year = year;
        RentalPrice = rentalPrice;
    }
}
public virtual void DisplayDetails()
{
    Console.WriteLine($"Model: {Model}, Manufacturer: {Manufacturer}, Year: {Year}, Rental Price: {RentalPrice:C}");
}
}

public class Car : Vehicle
{
    public int Seats { get; set; }
    public string EngineType { get; set; }
    public string Transmission { get; set; }
    public bool Convertible { get; set; }

    public Car(string model, string manufacturer, int year, decimal rentalPrice, int seats, string engineType, string transmission, bool convertible)
        : base(model, manufacturer, year, rentalPrice)
    {
        Seats = seats;
        EngineType = engineType;
        Transmission = transmission;
        Convertible = convertible;
    }
    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine($"Seats: {Seats}, Engine Type: {EngineType}, Transmission: {Transmission}, Convertible: {Convertible}");
    }
}

public class Truck : Vehicle
{
    public double Capacity { get; set; }
    public string TruckType { get; set; }
    public bool FourWheelDrive { get; set; }

    public Truck(string model, string manufacturer, int year, decimal rentalPrice, double capacity, string truckType, bool fourWheelDrive)
        : base(model, manufacturer, year, rentalPrice)
    {
        Capacity = capacity;
        TruckType = truckType;
        FourWheelDrive = fourWheelDrive;
    }

    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine($"Capacity: {Capacity} tons, Truck Type: {TruckType}, Four-Wheel Drive: {FourWheelDrive}");
    }
}
public class Motorcycle : Vehicle
{
    public int EngineCapacity { get; set; }
    public string FuelType { get; set; }
    public bool HasFairing { get; set; }

    public Motorcycle(string model, string manufacturer, int year, decimal rentalPrice, int engineCapacity, string fuelType, bool hasFairing)
        : base(model, manufacturer, year, rentalPrice)
    {
        EngineCapacity = engineCapacity;
        FuelType = fuelType;
        HasFairing = hasFairing;
    }

    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine($"Engine Capacity: {EngineCapacity} cc, Fuel Type: {FuelType}, Has Fairing: {HasFairing}");
    }
}



public override void DisplayDetails()
{
    base.DisplayDetails();
    Console.WriteLine($"Engine Capacity: {EngineCapacity} cc, Fuel Type: {FuelType}, Has Fairing: {HasFairing}");
}
}

public class RentalAgency
{
    private List<Vehicle> Fleet { get; set; }
    public decimal TotalRevenue { get; private set; }

    public RentalAgency()
    {
        Fleet = new List<Vehicle>();
        TotalRevenue = 0;
    }

    public void AddVehicle(Vehicle vehicle)
    {
        Fleet.Add(vehicle);
    }

    public void RentVehicle(string model, int days)
    {
        Vehicle vehicle = Fleet.Find(v => v.Model == model);
        if (vehicle != null)
        {
            TotalRevenue += vehicle.RentalPrice * days;
            Fleet.Remove(vehicle);
            Console.WriteLine($"Vehicle rented: {vehicle.Model} for {days} days. Total revenue: {TotalRevenue:C}");
        }
        else
        {
            Console.WriteLine("Vehicle not available.");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            RentalAgency agency = new RentalAgency();

            // Add 12 Cars
            agency.AddVehicle(new Car("Fortuner", "Toyota", 2021, 1100m, 5, "Petrol", "Manual", true));
            agency.AddVehicle(new Car("Baleno", "Maruti Suzuki", 2020, 1300m, 5, "Petrol", "Manual", false));
            agency.AddVehicle(new Car("City", "Honda", 2019, 1600m, 5, "Petrol", "Manual", false));
            agency.AddVehicle(new Car("Creta", "Hyundai", 2021, 2100m, 5, "Petrol", "Automatic", false));
            agency.AddVehicle(new Car("Nexon", "Tata", 2021, 1800m, 5, "Diesel", "Manual", false));
            agency.AddVehicle(new Car("Seltos", "Kia", 2020, 1900m, 5, "Petrol", "Manual", false));
            agency.AddVehicle(new Car("Innova Crysta", "Toyota", 2019, 2600m, 7, "Diesel", "Automatic", false));
            agency.AddVehicle(new Car("Scorpio", "Mahindra", 2021, 2300m, 7, "Diesel", "Manual", false));
            agency.AddVehicle(new Car("Ciaz", "Maruti Suzuki", 2020, 1400m, 5, "Petrol", "Manual", false));
            agency.AddVehicle(new Car("Venue", "Hyundai", 2021, 1700m, 5, "Petrol", "Automatic", false));
            agency.AddVehicle(new Car("EcoSport", "Ford", 2020, 1600m, 5, "Petrol", "Manual", false));
            agency.AddVehicle(new Car("Hector", "MG", 2021, 2200m, 5, "Petrol", "Automatic", false));

            // Add 11 Motorcycles
            agency.AddVehicle(new Motorcycle("Splendor", "Hero", 2019, 550m, 100, "Petrol", false));
            agency.AddVehicle(new Motorcycle("Pulsar", "Bajaj", 2020, 750m, 150, "Petrol", false));
            agency.AddVehicle(new Motorcycle("Apache", "TVS", 2021, 850m, 160, "Petrol", false));
            agency.AddVehicle(new Motorcycle("FZ", "Yamaha", 2019, 800m, 150, "Petrol", false));
            agency.AddVehicle(new Motorcycle("Activa", "Honda", 2020, 650m, 110, "Petrol", false));
            agency.AddVehicle(new Motorcycle("Jupiter", "TVS", 2021, 700m, 110, "Petrol", false));
            agency.AddVehicle(new Motorcycle("Bullet", "Royal Enfield", 2019, 1100m, 350, "Petrol", false));
            agency.AddVehicle(new Motorcycle("Gixxer", "Suzuki", 2020, 950m, 150, "Petrol", false));
            agency.AddVehicle(new Motorcycle("Duke", "KTM", 2021, 1300m, 200, "Petrol", false));
            agency.AddVehicle(new Motorcycle("CBR", "Honda", 2019, 1400m, 250, "Petrol", true));
            agency.AddVehicle(new Motorcycle("Ninja", "Kawasaki", 2020, 1600m, 300, "Petrol", true));

            // Add 12 Trucks
            agency.AddVehicle(new Truck("Bolero", "Mahindra", 2019, 3200m, 1.5, "Pickup", true));
            agency.AddVehicle(new Truck("Scorpio Getaway", "Mahindra", 2020, 3600m, 2.0, "Pickup", true));
            agency.AddVehicle(new Truck("Xenon", "Tata", 2021, 4200m, 2.5, "Pickup", true));
            agency.AddVehicle(new Truck("Yodha", "Tata", 2018, 2700m, 1.8, "Pickup", true));
            agency.AddVehicle(new Truck("Isuzu D-Max", "Isuzu", 2019, 4700m, 2.2, "Pickup", true));
            agency.AddVehicle(new Truck("Super Carry", "Maruti Suzuki", 2020, 3400m, 1.2, "Mini Truck", true));
            agency.AddVehicle(new Truck("Porter", "Ashok Leyland", 2021, 3500m, 1.5, "Mini Truck", true));
            agency.AddVehicle(new Truck("Eicher Pro", "Eicher", 2018, 5200m, 3.0, "Light Truck", true));
            agency.AddVehicle(new Truck("Tata Ace", "Tata", 2020, 3000m, 1.0, "Mini Truck", true));
            agency.AddVehicle(new Truck("Mahindra Maxximo", "Mahindra", 2019, 3100m, 1.0, "Mini Truck", true));
            agency.AddVehicle(new Truck("Piaggio Ape", "Piaggio", 2021, 2900m, 0.8, "Mini Truck", true));
            agency.AddVehicle(new Truck("Mahindra Jeeto", "Mahindra", 2022, 3300m, 1.2, "Mini Truck", true));

            Console.WriteLine("Fleet details:");
            agency.DisplayFleet();

            Console.WriteLine("\nRenting a car for 3 days...");
            agency.RentVehicle("Fortuner", 3);

            Console.WriteLine("\nFleet details after renting a car:");
            agency.DisplayFleet();

            Console.WriteLine($"\nTotal revenue: {agency.TotalRevenue:C}");
        }
    }
}
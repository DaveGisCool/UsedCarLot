using System;
using System.Collections.Generic;

namespace UsedCarLot
{
    class Car
    {
        public string Make { get; protected set; }
        public string Model { get; protected set; }
        public int Year { get; protected set; }
        public double Price { get; protected set; }
        public Car(string aMake, string aModel, int aYear, double aPrice)
        {
            Make = aMake;
            Model = aModel;
            Year = aYear;
            Price = aPrice;
            CarLot.PopulateLot(this);//auto-adds to Lot
        }
        public Car()
        {
            Make = "No Make Assigned";
            Model = "No Model Assigned";
            Year = 2000;
            Price = 0;
            CarLot.PopulateLot(this); } //auto-adds to Lot 
        public override string ToString()
        {  return $"{Make}  {Model}  {Year}  {Price}"; }
    }
    class Used : Car 
    {
        private double Mileage { get; set; }
        public Used(string aMake, string aModel, int aYear, double aPrice, double aMileage) : base(aMake, aModel, aYear, aPrice) 
        {  Mileage = aMileage; }
        public override string ToString()
        { return $"{Make}  {Model}  {Year}  {Price}  (Used) {Mileage}"; }
    }

    class CarLot //List all cars, Buy a car, Add a car
    {
        public static List<Car> cars = new List<Car>();
        
        public CarLot()
        {
        }
        public static void PopulateLot(Car theCar)
        {  cars.Add(theCar); }
        public static void BuyCar(int index) //remove car from list [List.RemoveAT(#)]
        {
            Console.WriteLine($"{CarLot.cars[index]}");
            Console.Write("Would you like to buy this car? ");
            string confirmBuy = Console.ReadLine().ToLower();
            if (confirmBuy == "y")
            {
                Console.WriteLine("Excellent! Our finance department will be in touch shortly.");  //remove car from list
                cars.Remove(cars[index]);
            }
            else
            { return; }
        }
        public static void AddCar() //add car to list (get user input)
        {
            Console.Write("Please enter the Make of the car to add: ");
            string newMake = Console.ReadLine();
            Console.Write("Please enter the Model of the car to add: ");
            string newModel = Console.ReadLine();
            Console.Write("Please enter the Year of the car to add: ");
            int newYear = Int32.Parse(Console.ReadLine());
            Console.Write("Please enter the Price of the car to add: ");
            double newPrice = Double.Parse(Console.ReadLine());
            Console.Write("Please enter the Mileage of the car to add: ");
            double newMileage = Double.Parse(Console.ReadLine());
            new Used(newMake, newModel, newYear, newPrice, newMileage);
        }
        public List<Car> ListCars() //menu
        {
            return cars;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int index;
            bool keepLooping = true;

            Console.WriteLine("Welcome to Grant Chirpus’ Used Car Emporium!\n");

            new Car("Nikolai", "Model S", 2017, 54999.90);
            new Car("Fourd", "Escapade", 2017, 31999.90);
            new Car("Chewie", "Vette", 2017, 44989.95);
            new Used("Hyonda", "Prior", 2015, 14795.50, 35987.6);
            new Used("GC", "Chirpus", 2013, 8500.00, 12345.0);
            new Used("GC", "Witherell", 2016, 14450.00, 3500.3);

            while (keepLooping)
            {

                for (index = 0; index < CarLot.cars.Count; index++)
                {
                    Console.WriteLine($"{index + 1}. {CarLot.cars[index]}");
                }
                Console.WriteLine($"{CarLot.cars.Count + 1}. Add a car ");
                Console.WriteLine($"{CarLot.cars.Count + 2}. Quit ");

                Console.Write("Which car would you like? ");
                int userChoice = Int32.Parse(Console.ReadLine());

                if (userChoice <= CarLot.cars.Count)
                {
                    CarLot.BuyCar(userChoice-1);
                }
                else if (userChoice == (CarLot.cars.Count + 1))
                {
                    CarLot.AddCar();
                }
                else if (userChoice == (CarLot.cars.Count + 2))
                {
                    Console.WriteLine("Have a great day!");
                    keepLooping = false;
                }
                else
                {
                    Console.WriteLine("That's not a valid selection.");
                    continue;
                }
            }
        }
    }
}

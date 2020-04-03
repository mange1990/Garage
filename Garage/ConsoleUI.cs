using System;
using System.Collections.Generic;
using System.Text;

namespace Garage1_0
{
    public class ConsoleUI : IUI
    {
        public void ShowMainMenu(GarageHandler garageHandler)
        {
            Console.WriteLine("Välkommen till garage programmet");
            Console.WriteLine("Navigera i menyn genom att ange en siffa mellan 1-5");
            Console.WriteLine($"Garaget har just nu kapacitet för {garageHandler.Garage.Capacity}");
            Console.WriteLine("1. Ändra garagets kapacitet");
            Console.WriteLine("2. Lägg till ett fordom");
            Console.WriteLine("3. Lista samtliga parkerade fordom i garaget");
            Console.WriteLine("4. Lista fordomstyper och hur många av varje fordom som finns parkerade i garaget just nu");
            Console.WriteLine("5. Sök efter fordom via registreringsnummer");
            Console.WriteLine("6. Sök efter fordom utifrån en eller flera egenskaper");
            Console.WriteLine("7. Ta bort ett fordom från garaget");
            Console.WriteLine("0. Avsluta programmet");

        }

        public int ChoiceVehicle(GarageHandler garageHandler)
        {
            Console.WriteLine("Ange vilket fordom du vill registrera i garaget");
            Console.WriteLine("1. Car");
            Console.WriteLine("2. Bus");
            Console.WriteLine("3. Boat");
            Console.WriteLine("4. MotorCycle");
            Console.WriteLine("5. Airplane");
            int vehicle = 0;
            int.TryParse(Console.ReadLine(), out vehicle);
            return vehicle;

        }

        public Vehicle AddVehicle(string vehicle)
        {
            Console.Write("Ange Registreringsnummer: ");
            string regNr = Console.ReadLine();

            Console.Write("Ange Färg: ");
            string color = Console.ReadLine();

            Console.Write("Ange antal hjul: ");
            int wheel = 0;
            int.TryParse(Console.ReadLine(), out wheel);

            Console.Write("Ange vikt: ");
            int weight = 0;
            int.TryParse(Console.ReadLine(), out weight);



            switch (vehicle)
            {
                case "Car":
                    Console.WriteLine("Ange bilmärke: ");
                    string carBrand = Console.ReadLine();
                    Car car = new Car(regNr, color, weight, carBrand);
                    return car;


            }
            return null;
        }

        public int NewCapacity(GarageHandler garageHandler)
        {
            Console.WriteLine($"Ange den nya kapaciteten: (Behöver vara större än {garageHandler.Garage.CountVehicle} som finns i garaget just nu");
            int capacity = 0;
            int.TryParse(Console.ReadLine(), out capacity);

            return capacity;
        }

        public void ShowWrongMessage(string wrongMessage)
        {
            Console.WriteLine(wrongMessage);
        }

        public ConsoleKey GetKey()
        {
            return Console.ReadKey(intercept: true).Key;
        }

        public Commando getCommand()
        {
            string commando = Console.ReadLine();

            switch (commando)
            {
                case "1":
                    return Commando.ChangeCapacity;
                case "2":
                    return Commando.AddVehicle;
                case "3":
                   return Commando.ListAllVehicles;
                case "4":
                    return Commando.ListVehicleTypeCount;
                case "5":
                    return Commando.SearchVehicleByRegNr;
                case "6":
                    return Commando.SearchVehicleByProperty;
                case "7":
                    return Commando.RemoveVehicle;
                case "0":
                    return Commando.Quit;
            }
            return 0;
        }

        public void ListAllVehicle(string vehiclesString)
        {
            Console.WriteLine("Här är alla fordom som finns i garaget just nu");
            Console.WriteLine(vehiclesString);            
            Console.ReadLine();
        }

        public void PrintMessage(string print)
        {
            Console.WriteLine(print);
            Console.ReadLine();
        }

        public VehicleTypes GetVehicleType()
        {
            Console.WriteLine("Ange vilket typ av fordom du vill registrera i garaget");
            Console.WriteLine($"1. Bil");
            Console.WriteLine($"2. Båt");
            Console.WriteLine($"3. Flygplan");
            Console.WriteLine($"4. Motorcykel");
            Console.WriteLine($"5. Bus");
            do
            {
                int vehicleType = 0;
                int.TryParse(Console.ReadLine(), out vehicleType);

                switch (vehicleType)
                {
                    case 1:
                        return VehicleTypes.Car;
                    case 2:
                        return VehicleTypes.Boat;
                    case 3:
                        return VehicleTypes.AirPlane;
                    case 4:
                        return VehicleTypes.Motorcycle;
                    case 5:
                        return VehicleTypes.Bus;
                }

                Console.WriteLine("Ange en siffra mellan 1-5 för att ange en fordomstyp");
            } while (true);



        }

        public Vehicle AddVehicleMenu(VehicleTypes vehicleType)
        {
            Console.Write("Ange Registreringsnummer: ");
            string regNr = Console.ReadLine();

            Console.Write("Ange Färg: ");
            string color = Console.ReadLine();

            Console.Write("Ange vikt: ");
            int weight = 0;
            int.TryParse(Console.ReadLine(), out weight);

            switch (vehicleType)
            {
                case VehicleTypes.Car:
                    Console.WriteLine("Ange bilmärke: ");
                    string carBrand = Console.ReadLine();
                    Car car = new Car(regNr, color, weight, carBrand);
                    return car;
                case VehicleTypes.AirPlane:
                    Console.Write("Ange antal hjul: ");
                    int wheel = 0;
                    int.TryParse(Console.ReadLine(), out wheel);
                    Console.Write("Ange max antal passagerare: ");
                    int numberOfSeats = 0;
                    int.TryParse(Console.ReadLine(), out numberOfSeats);
                    Airplane airplane = new Airplane(regNr, color, wheel, weight, numberOfSeats);
                    return airplane;
                case VehicleTypes.Bus:
                    Console.Write("Ange antal hjul: ");
                    wheel = 0;
                    int.TryParse(Console.ReadLine(), out wheel);
                    Console.Write("Ange bussens längd i meter: ");
                    int length = 0;
                    int.TryParse(Console.ReadLine(), out length);
                    Bus bus = new Bus(regNr, color, wheel, weight, length);
                    return bus;

            }



           

           
            return null;
        }

        public string GetRegNr()
        {
            Console.WriteLine("Ange registreringsnummer på fordomet");
            return Console.ReadLine();
        }

        public void PrintSuccessMessage(string message)
        {
            Console.WriteLine(message);
            Console.ReadLine();
        }

        public void PrintWrongMessage(string message)
        {
            Console.WriteLine(message);
            Console.ReadLine();
        }

        public void PrintVehicle(Vehicle vehicle)
        {
            Console.WriteLine(vehicle);
            Console.ReadLine();
        }

        public void ListVehicleTypeCount(string vehicleTypeCount)
        {
            Console.WriteLine(vehicleTypeCount);
            Console.ReadLine();
        }

        public int getCapacity()
        {
            Console.WriteLine("1. Ändra garagets kapacitet (Ange 0 för att gå tillbaka till huvudmenyn utan att ändra kapaciteten)");
            Console.Write("Ange den nya kapaciteten: ");
            string capacity = Console.ReadLine();
            return Int32.Parse(capacity);
        }

        public void clear()
        {
            Console.Clear();
           //Console.CursorVisible = false;
         //Console.SetCursorPosition(0, 0);
        }

        public void Quit()
        {
            Console.WriteLine("Programmet har avslutats");
        }

        public Dictionary<string, string> GetSearchPropertiesAndValues(List<string> properties)
        {
            Dictionary<string, string> propertiesValue = new Dictionary<string, string>();

            Console.WriteLine("Ange de egenskaper du vill söka efter. Tryck på enter om du inte vill söka efter egenskapen.");
            foreach (var property in properties)
            {
                Console.Write(property);
                string value = Console.ReadLine();
                if (value != "")
                    propertiesValue.Add(property, value);
            }
            return propertiesValue;
        }

        public void PrintVehicles(List<Vehicle> vehicles)
        {
            foreach (var vehicle in vehicles)
            {
                Console.WriteLine(vehicle);
            }
            Console.ReadLine();
        }
    }
} 

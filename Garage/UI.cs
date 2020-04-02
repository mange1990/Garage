using System;
using System.Collections.Generic;
using System.Text;

namespace Garage1_0
{
    public static class UI
    {
        internal static void ShowMainMenu(GarageHandler garageHandler)
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

        internal static int ChoiceVehicle(GarageHandler garageHandler)
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

        internal static Vehicle AddVehicle(string vehicle)
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

        internal static int NewCapacity(GarageHandler garageHandler)
        {
            Console.WriteLine($"Ange den nya kapaciteten: (Behöver vara större än {garageHandler.Garage.CountVehicle} som finns i garaget just nu");
            int capacity = 0;
            int.TryParse(Console.ReadLine(), out capacity);

            return capacity;
        }

        internal static void ShowWrongMessage(string wrongMessage)
        {
            Console.WriteLine(wrongMessage);
        }

        internal static ConsoleKey GetKey()
        {
            return Console.ReadKey(intercept: true).Key;
        }
    }
}

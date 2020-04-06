using System;
using System.Collections.Generic;
using System.Text;

namespace Garage1_0
{
    class ProgramHandler
    {
        private GarageHandler garageHandler = new GarageHandler();
        private IUI ui = new ConsoleUI();
        private bool garageInProcess = true;

        internal void start()
        {
            do
            {
                ui.clear();
                ui.ShowMainMenu(garageHandler);
                Commando commando = ui.getCommand();
                ui.clear();
                switch (commando)
                {
                    case Commando.ListAllVehicles:
                        ListAllVehicles();
                        break;
                    case Commando.AddVehicle:
                        AddVehicle();
                        break;
                    case Commando.RemoveVehicle:
                        RemoveVehicle();
                        break;
                    case Commando.SearchVehicleByRegNr:
                        SearchVehicleByRegNr();
                        break;
                    case Commando.ListVehicleTypeCount:
                        ListVehicleTypeCount();
                        break;
                    case Commando.ChangeCapacity:
                        ChangeCapacity();
                        break;
                    case Commando.SearchVehicleByProperty:
                        SearchVehicleByProperty();
                        break;
                    case Commando.Quit:
                        Quit();
                        break;
                }

            } while (garageInProcess);
        }

        private void SearchVehicleByProperty()
        {
            Dictionary<string, string> propertiesValues = ui.GetSearchPropertiesAndValues(garageHandler.getAllVehicleProperties());
            List<Vehicle> vehicles = garageHandler.SearchVehicleByProperty(propertiesValues);
            if (vehicles.Count == 0)
            {
                ui.PrintMessage("Inget fordom hittades med de angivna egenskaperna och värdena");
            }
            else
            {
                ui.PrintVehicles(vehicles);
            }
        }

        private void Quit()
        {
            garageInProcess = false;
            ui.Quit();
        }

        private void ChangeCapacity()
        {
            bool success = false;
            while (!success) {
                try
                {
                    int capacity = ui.getCapacity();
                    if (capacity == 0)
                        break;

                    while (!garageHandler.BuildGarage(capacity))
                    {
                        ui.PrintWrongMessage($"Kapaciteten får inte vara mindre att antalet parkerade bilar i garaget just nu. \n Ange en kapacitet större än {garageHandler.Garage.CountVehicle}");
                        capacity = ui.getCapacity();
                    }
                    ui.PrintSuccessMessage($"Kapaciteten för garaget har ändrats till {capacity}");
                    success = true;
                } catch (Exception e)
                {
                    ui.PrintWrongMessage("Kapaciteten måste vara en siffra");
                }
            }
        }

        private void ListVehicleTypeCount()
        {
            string str = garageHandler.ListVehicleTypeCount();

            if (str != "")
                ui.ListVehicleTypeCount(garageHandler.ListVehicleTypeCount());
            else
                ui.PrintMessage("Inga fordom finns i garaget");
        }

        private void SearchVehicleByRegNr()
        {
            string regNr = ui.GetRegNr();         
            Vehicle vehicle = garageHandler.GetVehicleByRegNr(regNr);

            if (vehicle != null)
                ui.PrintVehicle(vehicle);
            else
                ui.PrintWrongMessage("Fordomet hittades inte i garaget");
        }

        private void RemoveVehicle()
        {
            string regNr = ui.GetRegNr();

            if (garageHandler.Remove(regNr))
                ui.PrintSuccessMessage("Fordomet har tagits bort");
            else
                ui.PrintWrongMessage("Fordomet hittades inte i garaget");
        }

        private void AddVehicle()
        {
            VehicleTypes vehicleType = ui.GetVehicleType();
            Vehicle vehicle = ui.AddVehicleMenu(vehicleType);

            if (garageHandler.GetVehicleByRegNr(vehicle.RegNr) == null)
            {
                if (garageHandler.AddVehicle(vehicle))
                    ui.PrintSuccessMessage("Fordomet har lagts till i garaget");
                else
                    ui.PrintWrongMessage("Ett fel uppstod. Antingen är garaget fullt eller så finns ett fordom med det registreringsnummer");
            }
            else
                ui.PrintWrongMessage("Det finns redan ett fordom med det registreringsnumret");
            
        }

        private void ListAllVehicles()
        {
            string vehicleString = garageHandler.ListAllVehicle();
            if (vehicleString != "")
                ui.ListAllVehicle(vehicleString);
            else
                ui.PrintMessage("Inga Fordom finns i garaget");
        }




    }
}

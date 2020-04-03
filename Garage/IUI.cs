using System;
using System.Collections.Generic;

namespace Garage1_0
{
    public interface IUI
    {
        Vehicle AddVehicle(string vehicle);
        int ChoiceVehicle(GarageHandler garageHandler);
        ConsoleKey GetKey();
        int NewCapacity(GarageHandler garageHandler);
        void ShowMainMenu(GarageHandler garageHandler);
        void ShowWrongMessage(string wrongMessage);
        Commando getCommand();
        void ListAllVehicle(string v);
        VehicleTypes GetVehicleType();
        void clear();
        Vehicle AddVehicleMenu(VehicleTypes vehicleType);
        string GetRegNr();
        void PrintMessage(string print);
        void PrintSuccessMessage(string v);
        void PrintWrongMessage(string v);
        void PrintVehicle(Vehicle vehicle);
        void ListVehicleTypeCount(string v);
        int getCapacity();
        void Quit();
        Dictionary<string, string> GetSearchPropertiesAndValues(List<string> properties);
void PrintVehicles(List<Vehicle> vehicles);
    }
}
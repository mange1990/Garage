using System;
using System.Collections.Generic;
using System.Text;

namespace Garage1_0
{
    class GarageHandler
    {
        public Garage<Vehicle> Garage { get; private set; } = new Garage<Vehicle>(1);
        private bool GarageInProcess = true;


        public GarageHandler()
        {
            StartNewGarage();
        }



        private void StartNewGarage()
        {
            do
            {
                MainMenu();
                GetInput();

            } while (GarageInProcess);

        }

        private void GetInput()
        {
            var keyPressed = UI.GetKey();

            switch (keyPressed)
            {
              case ConsoleKey.NumPad1 :
                    BuildGarage();
                    break;
              case ConsoleKey.NumPad2:
                    addVehicle();
                    break;

             
            }


        }

        private void addVehicle()
        {
            int vehicle = UI.ChoiceVehicle(this);
            switch (vehicle)
            {
                case 1:
                    Garage.AddVehicle(UI.AddVehicle("Car"));
                    break;
                default:
                    break;
            }

        }

        private void BuildGarage()
        {
            int newCapacity = UI.NewCapacity(this);
            while(newCapacity < Garage.CountVehicle)
            {
                UI.ShowWrongMessage("Du måste ange en kapacitet som är större än antal bilar i garaget just nu");
                newCapacity = UI.NewCapacity(this);          
            }        
            Garage.buildNewCapacity(newCapacity);
        }

        private void MainMenu()
        {
            UI.ShowMainMenu(this);
        }
    }
}

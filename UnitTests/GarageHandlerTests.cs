using Garage1_0;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{

    [TestClass]
    public class GarageHandlerTests
    {

        [TestMethod]
        public void GetVehicleByRegNr_Found_ReturnVehicle()
        {
            GarageHandler g = new GarageHandler();
            g.BuildGarage(5);
            Bus bus1 = new Bus("gmg482", "Black", 8, 6948, 25);
            Bus bus2 = new Bus("krd124", "red", 6, 5928, 10);
            Car car1 = new Car("ABC148", "yellow", 1021, "Porsche");
            Car car2 = new Car("Gri492", "White", 1231, "Volvo");
            Vehicle expected1 = bus2;
            Vehicle expected2 = car2;

            g.AddVehicle(bus1);
            g.AddVehicle(bus2);
            g.AddVehicle(car1);
            g.AddVehicle(car2);

            Vehicle actua11 = g.GetVehicleByRegNr("kRD124");
            Vehicle actual2 = g.GetVehicleByRegNr("gRI492");

            Assert.AreEqual(expected1, actua11);
            Assert.AreEqual(expected2, actual2);

        }

        [TestMethod]
        public void GetVehicleByRegNr_NotFound_ReturnNull()
        {
            GarageHandler g = new GarageHandler();
            Bus bus1 = new Bus("gmg482", "Black", 8, 6948, 25);
            Bus bus2 = new Bus("krd124", "red", 6, 5928, 10);
            Car car1 = new Car("ABC148", "yellow", 1021, "Porsche");
            Car car2 = new Car("Gri492", "White", 1231, "Volvo");
            Vehicle expected1 = null;
            Vehicle expected2 = null;

            g.AddVehicle(bus1);
            g.AddVehicle(bus2);
            g.AddVehicle(car1);
            g.AddVehicle(car2);

            Vehicle actua11 = g.GetVehicleByRegNr("kRD123");
            Vehicle actual2 = g.GetVehicleByRegNr("grI491");

            Assert.AreEqual(expected1, actua11);
            Assert.AreEqual(expected2, actual2);

        }

        [TestMethod]
        public void ListVehicleTypeCount_FourVehicle_ReturnStringOfTypeAndCount()
        {
            GarageHandler g = new GarageHandler();
            g.BuildGarage(5);
            Bus bus1 = new Bus("gmg482", "Black", 8, 6948, 25);
            Bus bus2 = new Bus("krd124", "red", 6, 5928, 10);
            Car car1 = new Car("ABC148", "yellow", 1021, "Porsche");
            Car car2 = new Car("Gri492", "White", 1231, "Volvo");

            g.AddVehicle(bus1);
            g.AddVehicle(bus2);
            g.AddVehicle(car1);
            g.AddVehicle(car2);

            string actua1 = g.ListVehicleTypeCount();

            Assert.AreEqual($"Det finns 2 Bus i garaget just nu\nDet finns 2 Car i garaget just nu\n", actua1);


        }

    }
}

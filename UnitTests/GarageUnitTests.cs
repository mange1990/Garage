using Garage1_0;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTests
{
    [TestClass]
    public class GarageUnitTests
    {
        [TestMethod]
        public void CreateGarage_capacityOfFive_capacityIsFive()
        {
            const int expected = 5;
            Garage<Vehicle> g = new Garage<Vehicle>(expected);

            int actual = g.Capacity;

            Assert.AreEqual(expected, actual);
        }



        /*
        [TestMethod]
        public void CreateGarage_capacityWithZero_capacityIsZero()
        {
            const int expected = 0;
            Garage<Vehicle> g = new Garage<Vehicle>(expected);

            Assert.ThrowsException<ArgumentException>(g, "");
        }
        */
        /*
        [TestMethod]
        public void ListVehicle_()
        {
            const int expected = 5;
            Garage<Vehicle> g = new Garage<Vehicle>(expected);

            int actual = g.Capacity;

            Assert.AreEqual(expected, actual);
        }*/

        [TestMethod]
        public void AddVehicle_IsNotFull_True()
        {
            const bool expected = true;
            Garage<Vehicle> g = new Garage<Vehicle>(5);
            Car car = new Car("ABC124", "Black", 1000, "porsche");

            bool actual = g.AddVehicle(car);
            int count = g.CountVehicle;

            Assert.AreEqual(expected,actual);
            Assert.AreEqual(count, 1);
        }

        [TestMethod]
        public void AddVehicle_IsFull_false()
        {
            const bool expected = false;
            Garage<Vehicle> g = new Garage<Vehicle>(3);
            Car car1 = new Car("ABC124", "Black", 1000, "porsche");
            Car car2 = new Car("ABC125", "Black", 1000, "porsche");
            Car car3 = new Car("ABC126", "Black", 1000, "porsche");
            Car car4 = new Car("ABC127", "Black", 1000, "porsche");
            g.AddVehicle(car1);
            g.AddVehicle(car2);
            g.AddVehicle(car3);


            bool actual = g.AddVehicle(car4);
            int count = g.CountVehicle;

            Assert.AreEqual(expected, actual);
            Assert.AreEqual(count, 3);
        }

        [TestMethod]
        public void RemoveVehicle_VehicleFound_True()
        {
            const bool expected = true;
            Garage<Vehicle> g = new Garage<Vehicle>(5);
            Bus bus = new Bus("ABC124","red",6, 5928, 10);

            g.AddVehicle(bus);

            bool actual = g.RemoveVehicle(bus);

            Assert.AreEqual(expected, actual);
            Assert.AreEqual(g.CountVehicle, 0);
        }

        [TestMethod]
        public void RemoveVehicle_VehicleNotFound_false()
        {
            const bool expected = false;
            Garage<Vehicle> g = new Garage<Vehicle>(5);
            Bus bus1 = new Bus("ABC124", "red", 6, 5928, 10);
            Bus bus2 = new Bus("ABC125", "red", 6, 5928, 10);

            g.AddVehicle(bus1);

            bool actual = g.RemoveVehicle(bus2);

            Assert.AreEqual(expected, actual);
            Assert.AreEqual(g.CountVehicle, 1);
        }

        [TestMethod]
        public void RemoveVehicle_VehicleFound_true()
        {
            const bool expected = true;
            Garage<Vehicle> g = new Garage<Vehicle>(5);
            Bus bus1 = new Bus("ABC124", "red", 6, 5928, 10);
            Bus bus2 = new Bus("ABC125", "red", 6, 5928, 10);
            Bus bus3 = new Bus("ABC125", "red", 6, 5928, 10);
            Bus bus4 = new Bus("ABC125", "red", 6, 5928, 10);

            g.AddVehicle(bus1);
            g.AddVehicle(bus2);
            g.AddVehicle(bus3);
            g.AddVehicle(bus4);

            bool actual = g.RemoveVehicle(bus2);

            Assert.AreEqual(expected, actual);
            Assert.AreEqual(g.CountVehicle, 3);
            Assert.AreEqual(g.GetVehicleAtIndex(0), bus1);
            Assert.AreEqual(g.GetVehicleAtIndex(1), bus3);
            Assert.AreEqual(g.GetVehicleAtIndex(2), bus4);
        }

        [TestMethod]
        public void ListAllVehicle_TwoVehicle_ReturnString()
        {
            Garage<Vehicle> g = new Garage<Vehicle>(5);
            Bus bus = new Bus("ABC124", "red", 6, 5928, 10);
            Car car = new Car("ABC148", "yellow", 1021, "Porsche");
            string expected = "1: " + bus.ToString() + "\n2: " + car.ToString() + "\n";

            g.AddVehicle(bus);
            g.AddVehicle(car);

            string actual = g.ListAllVehicle();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ListAllVehicle_ZeroVehicle_ReturnString()
        {
            Garage<Vehicle> g = new Garage<Vehicle>(5);
          string expected = "";

            string actual = g.ListAllVehicle();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetVehicleByRegNr_Found_ReturnVehicle()
        {
            Garage<Vehicle> g = new Garage<Vehicle>(5);
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

            Vehicle actua11 = g.GetVehicleByRegNr("kRd124");
            Vehicle actual2 = g.GetVehicleByRegNr("grI492");

            Assert.AreEqual(expected1, actua11);
            Assert.AreEqual(expected2, actual2);

        }

        [TestMethod]
        public void GetVehicleByRegNr_NotFound_ReturnNull()
        {
            Garage<Vehicle> g = new Garage<Vehicle>(5);
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
            Garage<Vehicle> g = new Garage<Vehicle>(5);
            Bus bus1 = new Bus("gmg482", "Black", 8, 6948, 25);
            Bus bus2 = new Bus("krd124", "red", 6, 5928, 10);
            Car car1 = new Car("ABC148", "yellow", 1021, "Porsche");
            Car car2 = new Car("Gri492", "White", 1231, "Volvo");

            g.AddVehicle(bus1);
            g.AddVehicle(bus2);
            g.AddVehicle(car1);
            g.AddVehicle(car2);

            string actua1 = g.ListVehicleTypeCount();


            Assert.AreEqual("", actua1);
 

        }


    }
}

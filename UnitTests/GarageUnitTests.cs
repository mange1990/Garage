using Garage1_0;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class GarageUnitTests
    {
        [TestMethod]
        public void CreateGarage_capacityOfFive_capacityIsFive()
        {
            const int expected = 5;
            Garage g = new Garage(expected);

            int actual = g.Capacity;

            Assert.AreEqual(expected, actual);
        }

        public void CreateGarage_capacityWithZero_capacityIsZero()
        {
            const int expected = 0;
            Garage g = new Garage(expected);

            int actual = g.Capacity;

            Assert.AreEqual(expected, actual);
        }

    }
}

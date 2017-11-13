using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpaceTraderWPF;

namespace UnitTestProject2
{
    [TestClass]
    public class ShipTest
    {
        private Ship _testShip;

        [TestInitialize]
        public void SetupForTests()
        {
            _testShip = new Ship("My first Ship", 10000); 
        }

        [TestMethod]
        public void TestShipName()
        {
            Assert.AreEqual("My first Ship", _testShip.Name);
        }

        [TestMethod]
        public void TestShipCapacity()
        {
            // Make sure it matches the starting capacity.
            Assert.AreEqual(10000, _testShip.Capacity);

            // Make sure we can change the capacity.
            _testShip.Capacity = 1000000;
            Assert.AreEqual(1000000, _testShip.Capacity);
        }
    }
}

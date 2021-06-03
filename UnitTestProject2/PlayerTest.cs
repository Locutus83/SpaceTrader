using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpaceTraderWPF;

namespace UnitTestProject2
{
    [TestClass]
    public class PlayerTest
    {
        Player _testPlayer;

        [TestInitialize]
        public void SetupForTests()
        {
            _testPlayer = new Player("Player Name");
        }

        [TestMethod]
        public void TestPlayerName()
        {
            Assert.AreEqual("Player Name", _testPlayer.Name);

            _testPlayer.Name = "New Name";
            Assert.AreEqual("New Name", _testPlayer.Name);
        }

        [TestMethod]
        public void TestPlayerInitInventory()
        {
            Assert.AreEqual(0, _testPlayer.PlayerInventory.Count);
        }

        [TestMethod]
        public void TestPlayerUpdateInventory()
        {
            const double PlayerStartCash = 5000d;
            const double FuelPrice = 30d;
            const int FuelQnty = 100;
            const int DilithumQnty = 50;
            const double DilithiumPrice = 4d;

            Assert.IsTrue(_testPlayer.Buy(PlayerInventory.FUEL_NAME, FuelQnty, FuelPrice));
            Assert.AreEqual(1, _testPlayer.PlayerInventory.Count);
            Assert.AreEqual(0, _testPlayer.PlayerInventory.GetStorageUsed());
            Assert.AreEqual(FuelQnty, _testPlayer.PlayerInventory.GetFuelStorageUsed());
            Assert.AreEqual(PlayerStartCash - (FuelPrice * FuelQnty), _testPlayer.CashBalance);

            Assert.IsTrue(_testPlayer.Buy(PlayerInventory.DILITHIUM_NAME, DilithumQnty, DilithiumPrice));
            Assert.AreEqual(2, _testPlayer.PlayerInventory.Count);
            Assert.AreEqual(DilithumQnty, _testPlayer.PlayerInventory.GetStorageUsed());
            Assert.AreEqual(FuelQnty, _testPlayer.PlayerInventory.GetFuelStorageUsed());
            Assert.AreEqual(
                PlayerStartCash
                    - (FuelPrice * FuelQnty)
                    - (DilithiumPrice * DilithumQnty),
                _testPlayer.CashBalance);
        }

        [TestMethod]
        public void TestOverFuelStorageBuy()
        {
            Assert.IsFalse(_testPlayer.Buy(PlayerInventory.FUEL_NAME, 1000, 1d));
            Assert.AreEqual(1, _testPlayer.PlayerInventory.Count);
            Assert.AreEqual(0, _testPlayer.PlayerInventory.GetStorageUsed());
            Assert.AreEqual(0, _testPlayer.PlayerInventory.GetFuelStorageUsed());
            Assert.AreEqual(5000d, _testPlayer.CashBalance);
        }

        [TestMethod]
        public void TestOverStorageBuy()
        {
            Assert.IsFalse(_testPlayer.Buy(PlayerInventory.DILITHIUM_NAME, 1000000, 0d));
            Assert.AreEqual(0, _testPlayer.PlayerInventory.Count);
            Assert.AreEqual(0, _testPlayer.PlayerInventory.GetStorageUsed());
            Assert.AreEqual(0, _testPlayer.PlayerInventory.GetFuelStorageUsed());
            Assert.AreEqual(5000d, _testPlayer.CashBalance);
        }

        [TestMethod]
        public void TestPlayerOverExtendBalance()
        {
            Assert.IsFalse(_testPlayer.Buy(PlayerInventory.FUEL_NAME, 100, 60d));
            Assert.AreEqual(0, _testPlayer.PlayerInventory.Count);
            Assert.AreEqual(5000d, _testPlayer.CashBalance);
        }

        [TestMethod]
        public void TestPlayerBalance()
        {
            Assert.AreEqual(5000d, _testPlayer.CashBalance);
        }
    }
}

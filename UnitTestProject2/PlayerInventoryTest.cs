using System;
using SpaceTraderWPF;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject2
{
    [TestClass]
    public class PlayerInventoryTest
    {
        [TestMethod]
        public void TestPlayerInventoryBuy()
        {
            PlayerInventory pi = new PlayerInventory();
            pi.Buy(PlayerInventory.FUEL_NAME, 900, 30d);

            Assert.AreEqual(11, pi.Count);
            Inventory i = pi.InventoryItems[0];

            Assert.AreEqual(1000, i.Qnty);
            Assert.AreEqual(30d, i.AvgPricePaid);
            Assert.AreEqual(PlayerInventory.FUEL_NAME, i.ItemName);
        }

        [TestMethod]
        public void TestPlayerInventorySell()
        {
            PlayerInventory pi = new PlayerInventory();
            pi.Buy(PlayerInventory.FUEL_NAME, 900, 30d);

            pi.Sell(PlayerInventory.FUEL_NAME, 500, 40d);

            Inventory i = pi.InventoryItems[0];
            Assert.AreEqual(PlayerInventory.FUEL_NAME, i.ItemName);
            Assert.AreEqual(11, pi.Count);
            Assert.AreEqual(500, i.Qnty);
            Assert.AreEqual(30d, i.AvgPricePaid);
        }
    }
}

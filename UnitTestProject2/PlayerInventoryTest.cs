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
            pi.Buy("Fuel", 1000, 30d);

            Assert.AreEqual(1, pi.Count);
            Inventory i = pi.InventoryItems[0];

            Assert.AreEqual(1000, i.Qnty);
            Assert.AreEqual(30d, i.AvgPricePaid);
            Assert.AreEqual("Fuel", i.ItemName);
        }
    }
}

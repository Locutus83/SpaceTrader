﻿using System;
using SpaceTraderWPF;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject2
{
    [TestClass]
    public class InventoryTest
    {
        [TestMethod]
        public void TestPlayerInventoryInit()
        {
            Inventory i = new Inventory(PlayerInventory.FUEL_NAME);

            Assert.AreEqual(0, i.Qnty);
            Assert.AreEqual(0d, i.AvgPricePaid);
            Assert.AreEqual(0d, i.PricePaid);
            Assert.AreEqual(0, i.PurchaseHistory.Count);
            Assert.AreEqual(PlayerInventory.FUEL_NAME, i.ItemName);
        }

        [TestMethod]
        public void TestPurchaseRequestInit()
        {
            const int Qnty = 5;
            const double Price = 300d;
            Inventory i = new Inventory(PlayerInventory.FUEL_NAME, Qnty, Price);

            Assert.AreEqual(Qnty, i.Qnty);
            Assert.AreEqual(0d, i.AvgPricePaid);
            Assert.AreEqual(Price, i.PricePaid);
            Assert.AreEqual(0, i.PurchaseHistory.Count);
            Assert.AreEqual(PlayerInventory.FUEL_NAME, i.ItemName);
        }

        [TestMethod]
        public void TestPlayerPurchase()
        {
            Inventory pi = new Inventory(PlayerInventory.FUEL_NAME);

            const int Qnty = 5;
            const double Price = 300d;
            Inventory i = new Inventory(PlayerInventory.FUEL_NAME, Qnty, Price);

            Assert.IsTrue(pi.Buy(i));

            Assert.AreEqual(Qnty, pi.Qnty);
            Assert.AreEqual(Price, pi.AvgPricePaid);
            Assert.AreEqual(0, pi.PricePaid);
            Assert.AreEqual(Qnty, pi.PurchaseHistory.Count);
            Assert.AreEqual(PlayerInventory.FUEL_NAME, pi.ItemName);
        }

        [TestMethod]
        public void TestPlayerDoublePurchase()
        {
            Inventory pi = new Inventory(PlayerInventory.FUEL_NAME);

            const int Qnty1 = 5;
            const double Price1 = 300d;
            Inventory i1 = new Inventory(PlayerInventory.FUEL_NAME, Qnty1, Price1);

            Assert.IsTrue(pi.Buy(i1));

            Assert.AreEqual(Qnty1, pi.Qnty);
            Assert.AreEqual(Price1, pi.AvgPricePaid);
            Assert.AreEqual(0, pi.PricePaid);
            Assert.AreEqual(Qnty1, pi.PurchaseHistory.Count);
            Assert.AreEqual(PlayerInventory.FUEL_NAME, pi.ItemName);

            const int Qnty2 = 3;
            const double Price2 = 400d;
            Inventory i2 = new Inventory(PlayerInventory.FUEL_NAME, Qnty2, Price2);

            Assert.IsTrue(pi.Buy(i2));

            Assert.AreEqual(Qnty1 + Qnty2, pi.Qnty);
            Assert.AreEqual(((Price1 * Qnty1) + (Price2 * Qnty2)) / (Qnty1 + Qnty2), pi.AvgPricePaid);
            Assert.AreEqual(0, pi.PricePaid);
            Assert.AreEqual(Qnty1 + Qnty2, pi.PurchaseHistory.Count);
            Assert.AreEqual(PlayerInventory.FUEL_NAME, pi.ItemName);
        }

        [TestMethod]
        public void TestPlayerSale()
        {
            Inventory pi = new Inventory(PlayerInventory.FUEL_NAME);

            const int Qnty1 = 5;
            const double Price1 = 300d;
            Inventory i1 = new Inventory(PlayerInventory.FUEL_NAME, Qnty1, Price1);

            Assert.IsTrue(pi.Buy(i1));

            Assert.AreEqual(Qnty1, pi.Qnty);
            Assert.AreEqual(Price1, pi.AvgPricePaid);
            Assert.AreEqual(0, pi.PricePaid);
            Assert.AreEqual(Qnty1, pi.PurchaseHistory.Count);
            Assert.AreEqual(PlayerInventory.FUEL_NAME, pi.ItemName);

            const int Qnty2 = 3;
            const double Price2 = 400d;
            Inventory i2 = new Inventory(PlayerInventory.FUEL_NAME, Qnty2, Price2);

            Assert.IsTrue(pi.Sell(i2));

            Assert.AreEqual(Qnty1 - Qnty2, pi.Qnty);
            Assert.AreEqual(Price1, pi.AvgPricePaid);
            Assert.AreEqual(0, pi.PricePaid);
            Assert.AreEqual(Qnty1 - Qnty2, pi.PurchaseHistory.Count);
            Assert.AreEqual(PlayerInventory.FUEL_NAME, pi.ItemName);
        }
    }
}

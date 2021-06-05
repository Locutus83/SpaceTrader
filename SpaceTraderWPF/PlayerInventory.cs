using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceTraderWPF
{
    public class PlayerInventory
    {
        public const string FUEL_NAME = "Fuel";
        public const string DILITHIUM_NAME = "Dilithium";
        public const string WATER_NAME = "Water";
        public const string FOOD_NAME = "Food";
        public const string ORE_NAME = "Ore";
        public const string MEDICINE_NAME = "Medicine";
        public const string DRUGS_NAME = "Drugs";
        public const string ROBOTICS_NAME = "Robotics";
        public const string GOLD_NAME = "Gold";
        public const string SILVER_NAME = "Silver";
        public const string GEM_NAME = "Gems";

        public List<Inventory> InventoryItems { get; }
        public int Count => InventoryItems.Count;

        public PlayerInventory()
        {
            InventoryItems = new List<Inventory>
            {
                new Inventory(FUEL_NAME, 100),
                new Inventory(DILITHIUM_NAME),
                new Inventory(WATER_NAME),
                new Inventory(FOOD_NAME),
                new Inventory(ORE_NAME),
                new Inventory(MEDICINE_NAME),
                new Inventory(DRUGS_NAME),
                new Inventory(ROBOTICS_NAME),
                new Inventory(GOLD_NAME),
                new Inventory(SILVER_NAME),
                new Inventory(GEM_NAME)
            };
        }

        #region Actions

        public bool Buy(string name, int qnty, double price)
        {
            Inventory purchasedInventory = new Inventory(name, qnty, price);
            Inventory foundInventory = FindInventoryObjByName(name);

            return foundInventory.Buy(purchasedInventory);
        }

        public bool Sell(string name, int qnty, double price)
        {
            Inventory soldInventory = new Inventory(name, qnty, price);
            Inventory foundInventory = FindInventoryObjByName(name);

            if (foundInventory.Qnty < qnty)
            {
                return false;
            }

            return foundInventory.Sell(soldInventory);
        }

        #endregion

        #region Special Getters

        public int GetStorageUsed()
        {
            int storageSum = 0;
            foreach (Inventory item in InventoryItems)
            {
                if (!item.ItemName.Equals(FUEL_NAME, StringComparison.CurrentCultureIgnoreCase))
                {
                    storageSum += item.Qnty;
                }
            }

            return storageSum;
        }

        public int GetFuelStorageUsed()
        {
            return FindInventoryObjByName(FUEL_NAME).Qnty;
        }

        #endregion

        #region Helper Functions

        private Inventory FindInventoryObjByName(string name)
        {
            Inventory foundInventory = InventoryItems.Find(
                (inventory) => inventory.ItemName.Equals(name, StringComparison.CurrentCultureIgnoreCase)
            );

            if (foundInventory == null)
            {
                foundInventory = new Inventory(name);
                InventoryItems.Add(foundInventory);
            }

            return foundInventory;
        }

        #endregion
    }
}

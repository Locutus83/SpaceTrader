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

        public List<Inventory> InventoryItems { get; }
        public int Count => InventoryItems.Count;

        public PlayerInventory()
        {
            InventoryItems = new List<Inventory>();
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

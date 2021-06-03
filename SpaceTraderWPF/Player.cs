using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceTraderWPF
{
    public class Player
    {
        public string Name { get; set; }
        public Ship Ship { get; set; }
        public PlayerInventory PlayerInventory { get; }
        public double CashBalance { get; set; }

        public Player(string playerName)
        {
            Name = playerName;
            Ship = new Ship("Starter Enterprise");
            PlayerInventory = new PlayerInventory();
            CashBalance = 5000d;
        }

        #region Actions

        public bool Buy(string itemName, int qnty, double price)
        {
            if (qnty * price > CashBalance)
            {
                return false;
            }
            if (itemName.Equals(PlayerInventory.FUEL_NAME, StringComparison.OrdinalIgnoreCase) && qnty > Ship.FuelCapacity - PlayerInventory.GetFuelStorageUsed())
            {
                return false;
            }
            if (!itemName.Equals(PlayerInventory.FUEL_NAME, StringComparison.OrdinalIgnoreCase) && qnty > Ship.Capacity - PlayerInventory.GetStorageUsed())
            {
                return false;
            }

            CashBalance -= qnty * price;

            return PlayerInventory.Buy(itemName, qnty, price);
        }

        #endregion
    }
}

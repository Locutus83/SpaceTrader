using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceTraderWPF
{
    public class Ship
    {
        #region Defaults

        public const int DEFAULT_CAPACITY = 10000;
        public const int DEFAULT_FUEL_CAPACITY = 1000;

        #endregion

        public int Capacity { get; set; }
        public int FuelCapacity { get; set; }
        public string Name { get; set; }

        #region Constructors

        public Ship(string shipName, int startingCapacity = DEFAULT_CAPACITY, int startingFuelCapacity = DEFAULT_FUEL_CAPACITY)
        {
            Capacity = startingCapacity;
            FuelCapacity = startingFuelCapacity;
            Name = shipName;
        }

        #endregion
    }
}

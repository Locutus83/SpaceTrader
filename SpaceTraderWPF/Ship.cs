using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceTraderWPF
{
    public class Ship
    {
        public int Capacity { get; set; }
        public string Name { get; set; }

        public Ship(string shipName, int startingCapacity)
        {
            Capacity = startingCapacity;
            Name = shipName;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceTraderWPF
{
    public class Ship
    {
        private int _capacity;
        private string _name;

        public Ship(string shipName, int startingCapacity)
        {
            _capacity = startingCapacity;
            _name = shipName;
        }

        public int Capacity
        {
            get { return _capacity; }
            set { _capacity = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
    }
}

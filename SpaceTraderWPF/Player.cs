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
        public List<Inventory> PlayerInventory { get; }

        public Player(string playerName)
        {
            Name = playerName;
            PlayerInventory = new List<Inventory>();
        }
    }
}

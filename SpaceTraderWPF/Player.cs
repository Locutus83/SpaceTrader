using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceTraderWPF
{
    public class Player
    {
        private string _name;

        public Player(string playerName)
        {
            _name = playerName;
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
    }
}

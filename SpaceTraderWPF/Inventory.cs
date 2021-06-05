using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceTraderWPF
{
    public class Inventory
    {
        public string ItemName { get; private set; }
        public int Qnty { get; private set; }
        public double PricePaid { get; private set; }
        public Queue<double> PurchaseHistory { get; private set; }
        public double AvgPricePaid => PurchaseHistory.Count > 0 ? PurchaseHistory.Sum() / PurchaseHistory.Count : 0;

        public Inventory(string name, int initialQnty = 0)
        {
            Init(name, initialQnty, 0d);
        }

        /**
         * Use this when Buying or Selling
         */
        public Inventory(string name, int qnty, double price)
        {
            Init(name, qnty, price);
        }

        private void Init(string name, int qnty, double price)
        {
            ItemName = name;
            Qnty = qnty;
            PricePaid = price;
            PurchaseHistory = new Queue<double>();
        }

        #region Actions

        public bool Buy(Inventory purchaseRequest)
        {
            if (purchaseRequest.Qnty <= 0)
            {
                return false;
            }

            Qnty += purchaseRequest.Qnty;
            for (int i = 0; i < purchaseRequest.Qnty; i++)
            {
                PurchaseHistory.Enqueue(purchaseRequest.PricePaid);
            }

            return true;
        }

        public bool Sell(Inventory sellRequest)
        {
            if (sellRequest.Qnty > Qnty)
            {
                return false;
            }

            Qnty -= sellRequest.Qnty;
            for (int i = 0; i < sellRequest.Qnty; i++)
            {
                PurchaseHistory.Dequeue();
            }
            return true;
        }

        public bool Dump()
        {
            Qnty = 0;
            PurchaseHistory.Clear();
            return true;
        }

        public bool Loss(int qnty)
        {
            // Set qnty to all if loss is greater than what the player has.
            if (Qnty < qnty)
            {
                qnty = Qnty;
            }
            // If we are losing it all, this is technically a Dump.
            if (Qnty == qnty)
            {
                return Dump();
            }

            Qnty -= qnty;
            for (int i = 0; i < qnty; i++)
            {
                PurchaseHistory.Dequeue();
            }
            return true;
        }

        #endregion
    }
}

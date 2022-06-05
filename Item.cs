using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class Item
    {
        private static int totalItemCount = 1;

        protected readonly int itemID;
        protected readonly string itemName;
        protected readonly double itemPrice;

        public Item(string itemName, double itemPrice)
        {
            this.itemID = totalItemCount++;
            this.itemName = itemName;
            this.itemPrice = itemPrice;
        }

        public Item(Item item)
        {
            this.itemID = item.itemID;
            this.itemName = item.itemName;
            this.itemPrice = item.itemPrice;
        }

        public int ItemID
        {
            get
            {
                return this.itemID;
            }
        }

        public string ItemName
        {
            get
            {
                return this.itemName;
            }
        }

        public double ItemPrice
        {
            get
            {
                return this.itemPrice;
            }
        }

        public static int TotalItems()
        {
            return totalItemCount;
        }

        public override string ToString()
        {
            return string.Format("ID: {0}, Name: {1}, Price: {2}E", this.itemID, this.itemName, this.itemPrice);
        }

    }
}

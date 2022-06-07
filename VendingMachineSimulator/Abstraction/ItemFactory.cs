using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public sealed class ItemFactory
    {
        private static Dictionary<string, Item> cachedItems = new Dictionary<string, Item>();

        private static void LoadCachedItems()
        {
            cachedItems.Add("Cola", new Item("Cola", 1.00));
            cachedItems.Add("Chips", new Item("Chips", 0.50));
            cachedItems.Add("Candy", new Item("Candy", 0.65));
        }

        public static Item GetItem(string key)
        {
            if (cachedItems.Count == 0)
                LoadCachedItems();
            return cachedItems.ContainsKey(key) ? (Item)cachedItems[key] : null;
        }
    }
}

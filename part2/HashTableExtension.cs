using ItemClassLibrary;
using MyCollectionLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace part2
{
    public static class HashTableExtension
    {
        public static Item[] FindItems(this HashTable<Item> table, Func<Item, bool> searchFilter)
        {
            return table.Where(item => searchFilter(item))
                .Select(item => item)
                .ToArray();
        }

        public static int SumItemPrices(this HashTable<Item> table, Func<Item, bool> itemFilter)
        {
            return table.Where(item => itemFilter(item))
                .Select(item => item.Price)
                .Sum();
        }

        public static Item[] OrderItems(this HashTable<Item> table, Func<Item, object> sortFilter)
        {
            return table.OrderBy(item => sortFilter(item))
                .Select(item => item)
                .ToArray();
        }
    }
}

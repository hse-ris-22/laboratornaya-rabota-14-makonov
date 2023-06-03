using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItemClassLibrary;
using MyCollectionLibrary;

namespace AdditionalPart
{
    public static class HashTableExtension
    {
        /// <summary>
        /// Находит товары в хеш-таблице по заднному условию
        /// </summary>
        /// <param name="table">Хеш-таблица</param>
        /// <param name="searchFilter">Условие поиска</param>
        /// <returns>Массив товаров</returns>
        public static Item[] FindItems(this HashTable<Item> table, Func<Item, bool> searchFilter)
        {
            return table.Where(item => searchFilter(item))
                .Select(item => item)
                .ToArray();
        }

        /// <summary>
        /// Суммирует цены товаров по заданному условию
        /// </summary>
        /// <param name="table">Хеш-таблица</param>
        /// <param name="itemFilter">Условие суммирования</param>
        /// <returns>Сумма цен</returns>
        public static int SumItemPrices(this HashTable<Item> table, Func<Item, bool> itemFilter)
        {
            return table.Where(item => itemFilter(item))
                .Select(item => item.Price)
                .Sum();
        }

        /// <summary>
        /// Сортирует товары по заданному параметру
        /// </summary>
        /// <param name="table">Хеш-таблица</param>
        /// <param name="sortFilter">Условие сортировки (параметр)</param>
        /// <returns>Отсортированный массив товаров</returns>
        public static Item[] OrderItems(this HashTable<Item> table, Func<Item, object> sortFilter)
        {
            return table.OrderBy(item => sortFilter(item))
                .Select(item => item)
                .ToArray();
        }
    }
}

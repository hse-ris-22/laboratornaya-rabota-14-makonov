using ItemClassLibrary;
using MyCollectionLibrary;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace part2
{
    public static class Request
    {
        #region Запросы
        /// <summary>
        /// Находит все молочные продукты, которые есть в коллекции
        /// </summary>
        /// <param name="market">Рынок (хеш-таблица)</param>
        /// <returns>Массив молочных продуктов</returns>
        public static DairyProduct[] FindDairyProducts(HashTable<Item> market)
        {
            return market.Where(item => item is DairyProduct)
                .Select(item => (DairyProduct)item).ToArray();
        }

        /// <summary>
        /// Считает количество заданного по наименованию товара на рынке
        /// </summary>
        /// <param name="market">Рынок (хеш-таблица)</param>
        /// <param name="name">Наименование товара</param>
        /// <returns>Количество заданного товара</returns>
        public static int CountExactItemAmount(HashTable<Item> market, string name)
        {
            return market.Where(item => item.Name == name)
                .Select(item => item)
                .Count();
        }

        /// <summary>
        /// Находит самую дешевую игрушку на рынке
        /// </summary>
        /// <param name="market">Рынок (хеш-таблица)</param>
        /// <returns>Игрушка с самой низкой ценой</returns>
        public static Toy? FindCheapestToy(HashTable<Item> market)
        {
            return market.Where(item => item is Toy)
                .Select(item => item as Toy)
                .Min();
        }

        /// <summary>
        /// Находит самую дорогую игрушку на рынке
        /// </summary>
        /// <param name="market">Рынок (хеш-таблица)</param>
        /// <returns>Игрушка с самой большой ценой</returns>
        public static Toy? FindExpensiveToy(HashTable<Item> market)
        {
            return market.Where(item => item is Toy)
                .Select(item => item as Toy)
                .Max();
        }

        /// <summary>
        /// Находит наименования всех товаров рынка без дубликатов
        /// </summary>
        /// <param name="market">Рынок (хеш-таблица)</param>
        /// <returns>Массив товарных наименований</returns>
        public static string[] FindAllItemNames(HashTable<Item> market)
        {
            return market.Select(item => item.Name)
                .Distinct()
                .ToArray();
        }

        /// <summary>
        /// Находит пары продукт-количество
        /// </summary>
        /// <param name="market">Рынок (хеш-таблица)</param>
        /// <returns>Словарь с парами продукт-количество</returns>
        public static Dictionary<string, int> FindProductAmountPairs(HashTable<Item> market)
        {
            return market.Where(item => item is Product)
                .GroupBy(item => item.Name)
                .ToDictionary(col => col.Key, col => col.Count());
        }

        #endregion

        #region Вывод на консоль
        /// <summary>
        /// Выводит все молочные продукты, которые есть в коллекции
        /// </summary>
        /// <param name="market">Рынок (хеш-таблица)</param>
        [ExcludeFromCodeCoverage] // метод для вывода информации
        public static void PrintDairyProducts(HashTable<Item> market)
        {
            DairyProduct[] res = FindDairyProducts(market);

            if (res.Count() != 0)
            {
                foreach (DairyProduct dp in res)
                    Console.WriteLine(dp);
            }
            else
            {
                Console.WriteLine("На рынке нет молочных продуктов");
            }
        }

        /// <summary>
        /// Выводит количество заданного по наименованию товара на рынке
        /// </summary>
        /// <param name="market">Рынок (хеш-таблица)</param>
        [ExcludeFromCodeCoverage] // метод для вывода информации
        public static void PrintExactItemAmount(HashTable<Item> market)
        {
            Console.WriteLine("Введите наименование товара");
            string name = Console.ReadLine();
            int amount = CountExactItemAmount(market, name);
            if (amount != 0)
                Console.WriteLine($"На рынке количество товара {name} составляет {amount} ед.");
            else
                Console.WriteLine($"На рынке нет товара с наименованием '{name}'");
        }

        /// <summary>
        /// Выводит наименование и стоимость самой дорогой и самой дешевой игрушки на рынке
        /// </summary>
        /// <param name="market">Рынок (хеш-таблица)</param>
        [ExcludeFromCodeCoverage] // метод для вывода информации
        public static void PrintCheapAndExpensiveToy(HashTable<Item> market)
        {
            Toy? cheapestToy = FindCheapestToy(market);
            Toy? expensiveToy = FindExpensiveToy(market);

            if (cheapestToy is null && expensiveToy is null)
            {
                Console.WriteLine("На рынке нет игрушек");
            }
            else if (cheapestToy == expensiveToy)
            {
                Console.WriteLine($"На рынке всего одна игрушка: {cheapestToy.Name} Цена: {cheapestToy.Price}");
            }
            else
            {
                Console.WriteLine($"Самая дорогая игрушка на рынке: {expensiveToy.Name} Цена: {expensiveToy.Price}");
                Console.WriteLine($"Самая дешевая игрушка на рынке: {cheapestToy.Name} Цена: {cheapestToy.Price}");
            }
        }

        /// <summary>
        /// Выводит наименования всех товаров рынка без дубликатов
        /// </summary>
        /// <param name="market">Рынок (хеш-таблица)</param>
        [ExcludeFromCodeCoverage] // метод для вывода информации
        public static void PrintAllItemNames(HashTable<Item> market)
        {
            string[] res = FindAllItemNames(market);

            Console.WriteLine("Товары, которые есть на рынке:");
            foreach (string name in res)
            {
                Console.WriteLine(name);
            }
        }

        /// <summary>
        /// Выводит наименования всех продуктов на рынке и их количество
        /// </summary>
        /// <param name="market">Рынок (хеш-таблица)</param>
        [ExcludeFromCodeCoverage] // метод для вывода информации
        public static void PrintAllProductsWithAmounts(HashTable<Item> market)
        {
            var res = FindProductAmountPairs(market);

            if (res.Count() != 0)
            {
                foreach (var item in res)
                    Console.WriteLine($"{item.Key} - {item.Value}");
            }
            else
            {
                Console.WriteLine("На рынке нет продуктов");
            }
        }
        #endregion
    }
}

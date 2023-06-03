﻿using ItemClassLibrary;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace part1
{
    public static class LinqRequest
    {
        #region Запросы

        /// <summary>
        /// Находит все молочные продукты, которые есть в коллекции
        /// </summary>
        /// <param name="market">Рынок с отделами (очередь из словарей)</param>
        /// <returns>Массив молочных продуктов</returns>
        public static DairyProduct[] FindDairyProducts(Queue<Dictionary<int, Item>> market)
        {
            return (from department in market
                    from item in department.Values
                    where item is DairyProduct
                    select (DairyProduct)item).ToArray();
        }

        /// <summary>
        /// Считает количество заданного по наименованию товара на рынке
        /// </summary>
        /// <param name="market">Рынок с отделами (очередь из словарей)</param>
        /// <param name="name">Наименование товара</param>
        /// <returns>Количество заданного товара</returns>
        public static int CountExactItemAmount(Queue<Dictionary<int, Item>> market, string name)
        {
            return (from department in market
                    from item in department.Values
                    where item.Name == name
                    select item).Count();
        }

        /// <summary>
        /// Находит самую дешевую игрушку на рынке
        /// </summary>
        /// <param name="market">Рынок с отделами (очередь из словарей)</param>
        /// <returns>Игрушка с самой низкой ценой</returns>
        public static Toy? FindCheapestToy(Queue<Dictionary<int, Item>> market)
        {
            return (from department in market
                    from item in department.Values
                    where item is Toy
                    select item as Toy).Min();
        }

        /// <summary>
        /// Находит самую дорогую игрушку на рынке
        /// </summary>
        /// <param name="market">Рынок с отделами (очередь из словарей)</param>
        /// <returns>Игрушка с самой большой ценой</returns>
        public static Toy? FindExpensiveToy(Queue<Dictionary<int, Item>> market)
        {
            return (from department in market
                    from item in department.Values
                    where item is Toy
                    select item as Toy).Max();
        }

        /// <summary>
        /// Находит наименования товаров, которые есть в каждом отделе рынка
        /// </summary>
        /// <param name="market">Рынок с отделами (очередь из словарей)</param>
        /// <returns>Массив товарных наименований</returns>
        public static string[] FindItemIntersectionByName(Queue<Dictionary<int, Item>> market)
        {
            var res = from department in market
                      from item in department.Values
                      select item.Name;

            foreach (Dictionary<int, Item> department in market)
            {
                res = (from item in department.Values select item.Name).Intersect(res);
            }
            return res.ToArray();
        }

        /// <summary>
        /// Находит пары продукт-количество
        /// </summary>
        /// <param name="market">Рынок с отделами (очередь из словарей)</param>
        /// <returns>Словарь с парами продукт-количество</returns>
        public static Dictionary<string, int> FindProductAmountPairs(Queue<Dictionary<int, Item>> market)
        {
            return (from department in market
                    from item in department.Values
                    where item is Product
                    group item by item.Name).ToDictionary(gr => gr.Key, gr => gr.Count());
        }

        #endregion

        #region Вывод в консоль
        /// <summary>
        /// Выводит все молочные продукты, которые есть в коллекции
        /// </summary>
        /// <param name="market">Рынок с отделами (очередь из словарей)</param>
        [ExcludeFromCodeCoverage] // метод для вывода информации
        public static void PrintDairyProducts(Queue<Dictionary<int, Item>> market)
        {
            DairyProduct[] dairyProducts = FindDairyProducts(market);

            foreach (DairyProduct dp in dairyProducts)
            {
                Console.WriteLine(dp);
            }
        }

        /// <summary>
        /// Выводит количество заданного по наименованию товара на рынке
        /// </summary>
        /// <param name="market">Рынок с отделами (очередь из словарей)</param>
        [ExcludeFromCodeCoverage] // метод для вывода информации
        public static void PrintExactItemAmount(Queue<Dictionary<int, Item>> market)
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
        /// <param name="market">Рынок с отделами (очередь из словарей)</param>
        [ExcludeFromCodeCoverage] // метод для вывода информации
        public static void PrintCheapAndExpensiveToy(Queue<Dictionary<int, Item>> market)
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
        /// Выводит наименования товаров, которые есть в каждом отделе рынка
        /// </summary>
        /// <param name="market">Рынок с отделами (очередь из словарей)</param>
        [ExcludeFromCodeCoverage] // метод для вывода информации
        public static void PrintItemIntersection(Queue<Dictionary<int, Item>> market)
        {
            string[] res = FindItemIntersectionByName(market);

            if (res.Count() != 0)
            {
                Console.WriteLine("Товары, которые есть в каждом отделе:");
                foreach (string name in res)
                    Console.WriteLine(name);
            }
            else
            {
                Console.WriteLine("Общих товаров нет");
            }
        }

        /// <summary>
        /// Выводит наименования всех продуктов на рынке и их количество
        /// </summary>
        /// <param name="market">Рынок с отделами (очередь из словарей)</param>
        [ExcludeFromCodeCoverage] // метод для вывода информации
        public static void PrintAllProductsWithAmounts(Queue<Dictionary<int, Item>> market)
        {
            Dictionary<string, int> res = FindProductAmountPairs(market);

            if (res.Count() != 0)
            {
                foreach (KeyValuePair<string, int> item in res)
                {
                    Console.WriteLine($"{item.Key} - {item.Value}");
                }
            }
            else
            {
                Console.WriteLine("На рынке нет продуктов");
            }
        }
        #endregion

    }
}

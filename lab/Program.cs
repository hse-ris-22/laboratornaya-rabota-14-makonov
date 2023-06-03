using ItemClassLibrary;
using System.Diagnostics.CodeAnalysis;

namespace part1
{
    public class Program
    {
        [ExcludeFromCodeCoverage] //создает случайный элемент
        public static Item CreateRandomItem()
        {
            Random rnd = new Random();
            Item item = new Item();
            switch (rnd.Next(0, 4))
            {
                case 1:
                    item = new Product();
                    break;
                case 2:
                    item = new DairyProduct();
                    break;
                case 3:
                    item = new Toy();
                    break;
            }
            item.RandomInit();
            return item;
        }

        [ExcludeFromCodeCoverage] // заполняет коллекцию случайными элементами
        public static Dictionary<int, Item> CreateDictionary(int length)
        {
            Dictionary<int, Item> itemDictionary = new Dictionary<int, Item>(length);
            for (int i = 0; i < length; i++)
            {
                Item item = CreateRandomItem();
                while (itemDictionary.ContainsKey(item.id.number))
                    item = CreateRandomItem();
                itemDictionary.Add(item.id.number, item);
            }
            return itemDictionary;
        }

        [ExcludeFromCodeCoverage] // просто создает коллекцию 
        public static Queue<Dictionary<int, Item>> CreateQueue(int length)
        {
            Queue<Dictionary<int, Item>> queue = new Queue<Dictionary<int, Item>>(length);
            for (int i = 0; i < length; i++)
            {
                queue.Enqueue(CreateDictionary(7));
            }
            return queue;
        }

        [ExcludeFromCodeCoverage]
        static void Main(string[] args)
        {
            Queue<Dictionary<int, Item>> market = CreateQueue(3);
            int n = 1;
            foreach (var d in market)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{n++} отдел рынка:");
                Console.ResetColor();
                foreach (Item i in d.Values)
                {
                    Console.WriteLine(i);
                }
                Console.WriteLine();
            }
                        
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Запросы реализованные с помощью методов расширения");
            Console.WriteLine("\nЗапрос 1: Все найденные молочные продукты на рынке");
            Console.ResetColor();
            Request.PrintDairyProducts(market); 
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Запрос 2: количество товара с заданным наименованием");
            Console.ResetColor();
            Request.PrintExactItemAmount(market); 
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Запрос 3: самая дорогая и самая дешевая игрушка (наименование и цена)");
            Console.ResetColor();
            Request.PrintCheapAndExpensiveToy(market); 
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Запрос 4: товары, которые есть в каждом отделе");
            Console.ResetColor();
            Request.PrintItemIntersection(market); // 4 запрос

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nЗапрос 5: все продукты рынка и их количество");
            Console.ResetColor();
            Request.PrintAllProductsWithAmounts(market); // 5 запрос

            Console.ReadKey();
            //запросы, реализованные с помощью linq запросов
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\nЗапросы реализованные с помощью linq запросов");
            Console.WriteLine("\nЗапрос 1: Все найденные молочные продукты на рынке");
            Console.ResetColor();
            LinqRequest.PrintDairyProducts(market);
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Запрос 2: количество товара с заданным наименованием");
            Console.ResetColor();
            LinqRequest.PrintExactItemAmount(market);
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Запрос 3: самая дорогая и самая дешевая игрушка (наименование и цена)");
            Console.ResetColor();
            LinqRequest.PrintCheapAndExpensiveToy(market);
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Запрос 4: товары, которые есть в каждом отделе");
            Console.ResetColor();
            LinqRequest.PrintItemIntersection(market); // 4 запрос

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nЗапрос 5: все продукты рынка и их количество");
            Console.ResetColor();
            LinqRequest.PrintAllProductsWithAmounts(market); // 5 запрос
        }
    }
}
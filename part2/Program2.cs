using ItemClassLibrary;
using MyCollectionLibrary;
using part2;
using System.Diagnostics.CodeAnalysis;

public class Program2
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
    public static HashTable<Item> CreateHashTable(int amount)
    {
        Dictionary<int, Item> itemDictionary = new Dictionary<int, Item>();
        HashTable<Item> table = new HashTable<Item>();
        for (int i = 0; i < amount; i++)
        {
            table.Add(CreateRandomItem());
        }
        return table;
    }

    [ExcludeFromCodeCoverage]
    private static void Main(string[] args)
    {
        HashTable<Item> market = CreateHashTable(20);
        market.Display();

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nЗапросы реализованные с помощью методов расширения");
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
        Console.WriteLine("Запрос 4: наименования всех товаров рынка без дубликатов");
        Console.ResetColor();
        Request.PrintAllItemNames(market); 

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nЗапрос 5: все продукты рынка и их количество");
        Console.ResetColor();
        Request.PrintAllProductsWithAmounts(market); 

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
        Console.WriteLine("Запрос 4: наименования всех товаров рынка без дубликатов");
        Console.ResetColor();
        LinqRequest.PrintAllItemNames(market); 

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nЗапрос 5: все продукты рынка и их количество");
        Console.ResetColor();
        LinqRequest.PrintAllProductsWithAmounts(market);
    }
}
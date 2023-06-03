using AdditionalPart;
using ItemClassLibrary;
using MyCollectionLibrary;
using System.Diagnostics.CodeAnalysis;

internal class Program3
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
        HashTable<Item> market = CreateHashTable(10);

        market.Display();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\n\nМетоды расширения для хеш-таблицы");
        Console.WriteLine("\nПоиск товаров по заданному условию (по цене > 2000)");
        Console.ResetColor();
        Item[] res1 = market.FindItems(item => item.Price > 2000);
        foreach (Item item in res1)
        {
            Console.WriteLine(item);
        }

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nСуммирование цен определенных товаров (игрушек)");
        Console.ResetColor();
        int res2 = market.SumItemPrices(item => item is Toy);
        Console.WriteLine(res2);

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nСортировка товаров по заданному параметру (по имени)");
        Console.ResetColor();
        Item[] res3 = market.OrderItems(item => item.Name);
        foreach (Item item in res3)
        {
            Console.WriteLine(item);
        }
    }
}
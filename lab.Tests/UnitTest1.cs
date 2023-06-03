using part1;
using part2;
using ItemClassLibrary;
using MyCollectionLibrary;
using System.Xml;

namespace lab.Tests
{
    [TestClass]
    public class UnitTest1
    {
        #region ����� 1 (������� ��� ��������� Queue<Dictionary<int, Item>>)
        [TestMethod]
        public void FindDairyProductsQueueRequestTest()
        {
            Queue<Dictionary<int, Item>> q = new Queue<Dictionary<int, Item>>();
            Dictionary<int, Item> d1 = new Dictionary<int, Item>
            {
                { 9, new Toy() },
                { 1, new DairyProduct() },
                { 2, new DairyProduct() }
            };

            Dictionary<int, Item> d2 = new Dictionary<int, Item>
            {
                { 1, new DairyProduct() },
                { 2, new Toy() },
                { 3, new Item() }
            };
            q.Enqueue(d1);
            q.Enqueue(d2);
            Item[] arr = part1.Request.FindDairyProducts(q);
            Assert.AreEqual(3, arr.Length);
        }

        [TestMethod]
        public void FindDairyProductsQueueLinqRequestTest()
        {
            Queue<Dictionary<int, Item>> q = new Queue<Dictionary<int, Item>>();
            Dictionary<int, Item> d1 = new Dictionary<int, Item>
            {
                { 9, new Toy() },
                { 1, new DairyProduct() },
                { 2, new DairyProduct() }
            };
            Dictionary<int, Item> d2 = new Dictionary<int, Item>
            {
                { 1, new DairyProduct() },
                { 2, new Toy() },
                { 3, new Item() }
            };
            q.Enqueue(d1);
            q.Enqueue(d2);
            Item[] arr = part1.LinqRequest.FindDairyProducts(q);
            Assert.AreEqual(3, arr.Length);
        }

        [TestMethod]
        public void CountExactItemAmountQueueRequestTest()
        {
            Queue<Dictionary<int, Item>> q = new Queue<Dictionary<int, Item>>();
            Dictionary<int, Item> d1 = new Dictionary<int, Item>
            {
                { 9, new Toy() },
                { 1, new DairyProduct("������", 200, 120, 200, 5) },
                { 2, new DairyProduct("������", 300, 120, 200, 5) }
            };
            Dictionary<int, Item> d2 = new Dictionary<int, Item>
            {
                { 1, new DairyProduct("������", 100, 120, 200, 5) },
                { 2, new Toy() },
                { 3, new Item() }
            };
            q.Enqueue(d1);
            q.Enqueue(d2);
            int amount = part1.Request.CountExactItemAmount(q, "������");
            Assert.AreEqual(3, amount);
        }

        [TestMethod]
        public void CountExactItemAmountQueueLinqRequestTest()
        {
            Queue<Dictionary<int, Item>> q = new Queue<Dictionary<int, Item>>();
            Dictionary<int, Item> d1 = new Dictionary<int, Item>
            {
                { 9, new Toy() },
                { 1, new DairyProduct("������", 200, 120, 200, 5) },
                { 2, new DairyProduct("������", 300, 120, 200, 5) }
            };
            Dictionary<int, Item> d2 = new Dictionary<int, Item>
            {
                { 1, new DairyProduct("������", 100, 120, 200, 5) },
                { 2, new Toy() },
                { 3, new Item() }
            };
            q.Enqueue(d1);
            q.Enqueue(d2);
            int amount = part1.LinqRequest.CountExactItemAmount(q, "������");
            Assert.AreEqual(3, amount);
        }

        [TestMethod]
        public void FindCheapestToyQueueRequestTest()
        {
            Queue<Dictionary<int, Item>> q = new Queue<Dictionary<int, Item>>();
            Dictionary<int, Item> d1 = new Dictionary<int, Item>
            {
                { 9, new Toy(" ", 1000, 1, " ", 1) },
                { 1, new Toy(" ", 1200, 1, " ", 1) },
                { 2, new Toy(" ", 900, 1, " ", 1) }
            };
            Dictionary<int, Item> d2 = new Dictionary<int, Item>
            {
                { 9, new Toy(" ", 1000, 1, " ", 1) },
                { 1, new Toy(" ", 1200, 1, " ", 1) },
                { 2, new Toy(" ", 800, 1, " ", 1) }
            };
            q.Enqueue(d1);
            q.Enqueue(d2);
            Toy? actual = part1.Request.FindCheapestToy(q);
            Toy expected = new Toy(" ", 800, 1, " ", 1);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindCheapestToyQueueLinqRequestTest()
        {
            Queue<Dictionary<int, Item>> q = new Queue<Dictionary<int, Item>>();
            Dictionary<int, Item> d1 = new Dictionary<int, Item>
            {
                { 9, new Toy(" ", 1000, 1, " ", 1) },
                { 1, new Toy(" ", 1200, 1, " ", 1) },
                { 2, new Toy(" ", 900, 1, " ", 1) }
            };
            Dictionary<int, Item> d2 = new Dictionary<int, Item>
            {
                { 9, new Toy(" ", 1000, 1, " ", 1) },
                { 1, new Toy(" ", 1200, 1, " ", 1) },
                { 2, new Toy(" ", 800, 1, " ", 1) }
            };
            q.Enqueue(d1);
            q.Enqueue(d2);
            Toy? actual = part1.LinqRequest.FindCheapestToy(q);
            Toy expected = new Toy(" ", 800, 1, " ", 1);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindExpensiveToyQueueRequestTest()
        {
            Queue<Dictionary<int, Item>> q = new Queue<Dictionary<int, Item>>();
            Dictionary<int, Item> d1 = new Dictionary<int, Item>
            {
                { 9, new Toy(" ", 1000, 1, " ", 1) },
                { 1, new Toy(" ", 1200, 1, " ", 1) },
                { 2, new Toy(" ", 900, 1, " ", 1) }
            };
            Dictionary<int, Item> d2 = new Dictionary<int, Item>
            {
                { 9, new Toy(" ", 1000, 1, " ", 1) },
                { 1, new Toy(" ", 1200, 1, " ", 1) },
                { 2, new Toy(" ", 800, 1, " ", 1) }
            };
            q.Enqueue(d1);
            q.Enqueue(d2);
            Toy? actual = part1.Request.FindExpensiveToy(q);
            Toy expected = new Toy(" ", 1200, 1, " ", 1);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindExpensiveToyQueueLinqRequestTest()
        {
            Queue<Dictionary<int, Item>> q = new Queue<Dictionary<int, Item>>();
            Dictionary<int, Item> d1 = new Dictionary<int, Item>
            {
                { 9, new Toy(" ", 1000, 1, " ", 1) },
                { 1, new Toy(" ", 1200, 1, " ", 1) },
                { 2, new Toy(" ", 900, 1, " ", 1) }
            };
            Dictionary<int, Item> d2 = new Dictionary<int, Item>
            {
                { 9, new Toy(" ", 1000, 1, " ", 1) },
                { 1, new Toy(" ", 1200, 1, " ", 1) },
                { 2, new Toy(" ", 800, 1, " ", 1) }
            };
            q.Enqueue(d1);
            q.Enqueue(d2);
            Toy? actual = part1.LinqRequest.FindExpensiveToy(q);
            Toy expected = new Toy(" ", 1200, 1, " ", 1);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindItemIntersectionByNameQueueRequestTest()
        {
            Queue<Dictionary<int, Item>> q = new Queue<Dictionary<int, Item>>();
            Dictionary<int, Item> d1 = new Dictionary<int, Item>
            {
                { 9, new Toy("�����", 1000, 1, " ", 1) },
                { 1, new Toy("���������", 1200, 1, " ", 1) },
                { 2, new Toy("����", 900, 1, " ", 1) }
            };
            Dictionary<int, Item> d2 = new Dictionary<int, Item>
            {
                { 9, new Toy("�������", 1000, 1, " ", 1) },
                { 1, new Toy("�����", 1200, 1, " ", 1) },
                { 2, new Toy("�������", 800, 1, " ", 1) }
            };
            q.Enqueue(d1);
            q.Enqueue(d2);
            string[] items = part1.Request.FindItemIntersectionByName(q);
            Assert.AreEqual(1, items.Length);
        }

        [TestMethod]
        public void FindItemIntersectionByNameQueueLinqRequestTest()
        {
            Queue<Dictionary<int, Item>> q = new Queue<Dictionary<int, Item>>();
            Dictionary<int, Item> d1 = new Dictionary<int, Item>
            {
                { 9, new Toy("�����", 1000, 1, " ", 1) },
                { 1, new Toy("���������", 1200, 1, " ", 1) },
                { 2, new Toy("����", 900, 1, " ", 1) }
            };
            Dictionary<int, Item> d2 = new Dictionary<int, Item>
            {
                { 9, new Toy("�������", 1000, 1, " ", 1) },
                { 1, new Toy("�����", 1200, 1, " ", 1) },
                { 2, new Toy("�������", 800, 1, " ", 1) }
            };
            q.Enqueue(d1);
            q.Enqueue(d2);
            string[] items = part1.LinqRequest.FindItemIntersectionByName(q);
            Assert.AreEqual(1, items.Length);
        }

        [TestMethod]
        public void FindProductAmountPairsQueueRequestTest()
        {
            Queue<Dictionary<int, Item>> q = new Queue<Dictionary<int, Item>>();
            Dictionary<int, Item> d1 = new Dictionary<int, Item>
            {
                { 9, new DairyProduct("�����", 1000, 1, 1, 1) },
                { 1, new Product("�������", 900, 1, 1) },
                { 2, new DairyProduct("�����", 900, 1, 1, 1) }
            };
            Dictionary<int, Item> d2 = new Dictionary<int, Item>
            {
                { 9, new Product("�������", 100, 1, 1) },
                { 1, new Product("�������", 200, 1, 1) },
                { 2, new Product ("����", 1200, 1, 1) }
            };
            q.Enqueue(d1);
            q.Enqueue(d2);
            Dictionary<string, int> pairs = part1.Request.FindProductAmountPairs(q);
            Assert.IsTrue(pairs["�������"] == 3 && pairs["����"] == 1 && pairs["�����"] == 2 && pairs.Count == 3);
        }

        [TestMethod]
        public void FindProductAmountPairsQueueLinqRequestTest()
        {
            Queue<Dictionary<int, Item>> q = new Queue<Dictionary<int, Item>>();
            Dictionary<int, Item> d1 = new Dictionary<int, Item>
            {
                { 9, new DairyProduct("�����", 1000, 1, 1, 1) },
                { 1, new Product("�������", 900, 1, 1) },
                { 2, new DairyProduct("�����", 900, 1, 1, 1) }
            };
            Dictionary<int, Item> d2 = new Dictionary<int, Item>
            {
                { 9, new Product("�������", 100, 1, 1) },
                { 1, new Product("�������", 200, 1, 1) },
                { 2, new Product ("����", 1200, 1, 1) }
            };
            q.Enqueue(d1);
            q.Enqueue(d2);
            Dictionary<string, int> pairs = part1.LinqRequest.FindProductAmountPairs(q);
            Assert.IsTrue(pairs["�������"] == 3 && pairs["����"] == 1 && pairs["�����"] == 2 && pairs.Count == 3);
        }
        #endregion

        #region ����� 2 (������� ��� ��������� HashTable<Item>)
        [TestMethod]
        public void FindDairyProductsHashTableRequestTest()
        {
            HashTable<Item> ht = new HashTable<Item>
            {
                new DairyProduct("�", 1, 2, 3, 4),
                new DairyProduct("�", 5, 6, 7, 8),
                new DairyProduct("�", 9, 10, 11, 12)
            };

            Item[] arr = part2.Request.FindDairyProducts(ht);
            Assert.AreEqual(3, arr.Length);
        }

        [TestMethod]
        public void FindDairyProductsHashTableLinqRequestTest()
        {
            HashTable<Item> ht = new HashTable<Item>
            {
                new DairyProduct("�", 1, 2, 3, 4),
                new DairyProduct("�", 5, 6, 7, 8),
                new DairyProduct("�", 9, 10, 11, 12)
            };

            Item[] arr = part2.LinqRequest.FindDairyProducts(ht);
            Assert.AreEqual(3, arr.Length);
        }

        [TestMethod]
        public void CountExactItemAmountHashTableRequestTest()
        {
            HashTable<Item> ht = new HashTable<Item>
            {
                new DairyProduct("������", 1, 2, 3, 4),
                new DairyProduct("������", 5, 6, 7, 8),
                new Item(),
                new DairyProduct("������", 9, 10, 11, 12),
                new Toy(),
                new Product()
            };

            int amount = part2.Request.CountExactItemAmount(ht, "������");
            Assert.AreEqual(3, amount);
        }

        [TestMethod]
        public void CountExactItemAmountHashTableLinqRequestTest()
        {
            HashTable<Item> ht = new HashTable<Item>
            {
                new DairyProduct("������", 1, 2, 3, 4),
                new DairyProduct("������", 5, 6, 7, 8),
                new Item(),
                new DairyProduct("������", 9, 10, 11, 12),
                new Toy(),
                new Product()
            };

            int amount = part2.LinqRequest.CountExactItemAmount(ht, "������");
            Assert.AreEqual(3, amount);
        }

        [TestMethod]
        public void FindCheapestToyHashTableRequestTest()
        {
            HashTable<Item> ht = new HashTable<Item>
            {
                new Toy(" ", 1000, 1, " ", 1) ,
                new Toy(" ", 1200, 1, " ", 1),
                new Toy(" ", 900, 1, " ", 1),
                new Toy(" ", 1000, 1, " ", 1),
                new Toy(" ", 1200, 1, " ", 1),
                new Toy(" ", 800, 1, " ", 1)
            };

            Toy? actual = part2.Request.FindCheapestToy(ht);
            Toy expected = new Toy(" ", 800, 1, " ", 1);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindCheapestToyHashTableLinqRequestTest()
        {
            HashTable<Item> ht = new HashTable<Item>
            {
                new Toy(" ", 1000, 1, " ", 1) ,
                new Toy(" ", 1200, 1, " ", 1),
                new Toy(" ", 900, 1, " ", 1),
                new Toy(" ", 1000, 1, " ", 1),
                new Toy(" ", 1200, 1, " ", 1),
                new Toy(" ", 800, 1, " ", 1)
            };

            Toy? actual = part2.LinqRequest.FindCheapestToy(ht);
            Toy expected = new Toy(" ", 800, 1, " ", 1);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindExpensiveToyHashTableRequestTest()
        {
            HashTable<Item> ht = new HashTable<Item>
            {
                new Toy(" ", 1000, 1, " ", 1) ,
                new Toy(" ", 1200, 1, " ", 1),
                new Toy(" ", 900, 1, " ", 1),
                new Toy(" ", 1000, 1, " ", 1),
                new Toy(" ", 1200, 1, " ", 1),
                new Toy(" ", 800, 1, " ", 1)
            };

            Toy? actual = part2.Request.FindExpensiveToy(ht);
            Toy expected = new Toy(" ", 1200, 1, " ", 1);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindExpensiveToyHashTableLinqRequestTest()
        {
            HashTable<Item> ht = new HashTable<Item>
            {
                new Toy(" ", 1000, 1, " ", 1) ,
                new Toy(" ", 1200, 1, " ", 1),
                new Toy(" ", 900, 1, " ", 1),
                new Toy(" ", 1000, 1, " ", 1),
                new Toy(" ", 1200, 1, " ", 1),
                new Toy(" ", 800, 1, " ", 1)
            };

            Toy? actual = part2.LinqRequest.FindExpensiveToy(ht);
            Toy expected = new Toy(" ", 1200, 1, " ", 1);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindAllItemNamesHashTableRequestTest()
        {
            HashTable<Item> ht = new HashTable<Item>
            {
                new Item("���������", 1000, 1) ,
                new Item("���������", 1200, 1),
                new Toy("�����", 900, 1, " ", 1),
                new Toy("�����", 1000, 1, " ", 1),
                new Toy("�����", 1200, 1, " ", 1),
                new Product("��������", 800, 1, 1)
            };

            string[] items = part2.Request.FindAllItemNames(ht);
            Assert.AreEqual(3, items.Length);
        }

        [TestMethod]
        public void FindAllItemNamesHashTableLinqRequestTest()
        {
            HashTable<Item> ht = new HashTable<Item>
            {
                new Item("���������", 1000, 1) ,
                new Item("���������", 1200, 1),
                new Toy("�����", 900, 1, " ", 1),
                new Toy("�����", 1000, 1, " ", 1),
                new Toy("�����", 1200, 1, " ", 1),
                new Product("��������", 800, 1, 1)
            };

            string[] items = part2.LinqRequest.FindAllItemNames(ht);
            Assert.AreEqual(3, items.Length);
        }

        [TestMethod]
        public void FindProductAmountPairsHashTableRequestTest()
        {
            HashTable<Item> ht = new HashTable<Item>
            {
                new DairyProduct("�����", 1000, 1, 1, 1),
                new Product("�������", 900, 1, 1),
                new DairyProduct("�����", 900, 1, 1, 1),
                new Product("�������", 100, 1, 1),
                new Product("�������", 200, 1, 1),
                new Product ("����", 1200, 1, 1)
            };

            Dictionary<string, int> pairs = part2.Request.FindProductAmountPairs(ht);
            Assert.IsTrue(pairs["�������"] == 3 && pairs["����"] == 1 && pairs["�����"] == 2 && pairs.Count == 3);
        }

        [TestMethod]
        public void FindProductAmountPairsHashTableLinqRequestTest()
        {
            HashTable<Item> ht = new HashTable<Item>
            {
                new DairyProduct("�����", 1000, 1, 1, 1),
                new Product("�������", 900, 1, 1),
                new DairyProduct("�����", 900, 1, 1, 1),
                new Product("�������", 100, 1, 1),
                new Product("�������", 200, 1, 1),
                new Product ("����", 1200, 1, 1)
            };

            Dictionary<string, int> pairs = part2.LinqRequest.FindProductAmountPairs(ht);
            Assert.IsTrue(pairs["�������"] == 3 && pairs["����"] == 1 && pairs["�����"] == 2 && pairs.Count == 3);
        }
        #endregion

        #region ������ ���������� ��� ���-�������
        [TestMethod]
        public void FindItemsTest()
        {
            HashTable<Item> ht = new HashTable<Item>
            {
                new DairyProduct("�����", 120, 1, 1, 1),
                new Product("�������", 150, 1, 1),
                new DairyProduct("�����",270, 1, 1, 1),
                new Product("�������", 250, 1, 1),
                new Product("�������", 200, 1, 1),
                new Product ("����", 60, 1, 1)
            };
            Item[] items = ht.FindItems(item => item.Price > 200);
            Assert.AreEqual(2, items.Length);
        }

        [TestMethod]
        public void SumItemPricesTest()
        {
            HashTable<Item> ht = new HashTable<Item>
            {
                new DairyProduct("�����", 120, 1, 1, 1),
                new Product("�������", 150, 1, 1),
                new DairyProduct("�����",270, 1, 1, 1),
                new Product("�������", 250, 1, 1),
                new Product("�������", 200, 1, 1),
                new Product ("����", 60, 1, 1)
            };
            int sum = ht.SumItemPrices(item => item.Name == "�������");
            Assert.AreEqual(600, sum);
        }

        [TestMethod]
        public void OrderTest()
        {
            HashTable<Item> ht = new HashTable<Item>
            {
                new DairyProduct("�����", 120, 1, 1, 1),
                new Product("�������", 150, 1, 1),
                new Product ("����", 60, 1, 1)
            };

            Item[] items = ht.OrderItems(item => item.Price);
            Assert.IsTrue(items[0].Name == "����" && items[1].Name == "�����" && items[2].Name == "�������");
        }
        #endregion
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShopSystem
{

    public class ShoppingCart
    {
        private List<string> shopItemIDList = new List<string>();

        public void PrintIntroduction()
        {
            Console.Write("以下是商品列表:");
            Console.WriteLine();
            foreach (var Sample in ProductManagement.SampleList)
            {
                var item = Sample.Value;
                Console.Write(" *{0}* :{1} {2} {3}", item.id,StoreManagement.getStoreByID(item.storeID).name, item.name, item.price);
                Console.WriteLine();
            }
            Console.Write("，  0 結束");
            Console.WriteLine();
        }

        public double GetShopItemSum()
        {
            var sum = 0.0;
            foreach (var itemID in shopItemIDList)
            {
                var item = ProductManagement.getProductByID(itemID);
                if (item != null)
                    sum += item.price;
            }
            return sum;
        }

        public void PrintAllShoppingItem()
        {
            Console.Write("目前商品  \n");
            foreach (var Sampleitem in ProductManagement.SampleList)
            {
                var item = Sampleitem.Value;
                var count = shopItemIDList.Count(i => i == item.id.ToString());
                Console.Write("{0} 數量:{1} \n", item.name, count);
            }

            Console.Write("目前商品總金額 :{0}", GetShopItemSum());
            Console.WriteLine();
        }

        public void AddCartItem(string type)
        {
            var product = ProductManagement.getProductByID(type);
            if (product != null)
                shopItemIDList.Add(type);
        }

        public void AddCartItem(string type ,int count)
        {
            for (int i = 0; i < count; i++)
            {
                AddCartItem(type);
            }
        }
    }

    public class ProductManagement
    {
        static public Dictionary<int,Product> SampleList
        {
            get
            {
                var SampleList = new Dictionary<int, Product>();
                SampleList.Add(1, new Product(1, "二手蘋果手機", 8700,1));
                SampleList.Add(2, new Product(2, "C# cookbook", 568,1));
                SampleList.Add(3, new Product(3, "HP 筆電", 16888,1));
                SampleList.Add(4, new Product(4, "哈利波特影集", 2250,2));
                SampleList.Add(5, new Product(5, "無間道三部曲", 1090,2));
                return SampleList;
            }
        }

        static public Product getProductByID(string id)
        {
            try
            {
                return SampleList.FirstOrDefault(i => i.Key == int.Parse(id)).Value;
            }
            catch
            {
                return null;
            }
        }

    }

    public class Product
    {
        public int id;

        public int storeID;

        public string name;

        public double price;

        public Product(int id, string name, int price, int storeID)
        {
            this.id = id;
            this.name = name;
            this.price = price;
            this.storeID = storeID;
        }
    }

    public class Store
    {
        public int id;
        
        public string name;
        public Store(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
    }
    public class StoreManagement
    {
        static public Dictionary<int, Store> StoreList
        {
            get
            {
                var StoreList = new Dictionary<int, Store>();
                StoreList.Add(1, new Store(1, "OO商店"));
                StoreList.Add(2, new Store(2, "XX商店"));
                return StoreList;
            }
        }

        static public Store getStoreByID(int storeid)
        {
            try
            {
                return StoreList.FirstOrDefault(i => i.Key == storeid).Value;
            }
            catch
            {
                return null;
            }
        }

    }
}
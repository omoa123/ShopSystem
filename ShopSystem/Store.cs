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
            Console.Write("請輸入數字:");
            foreach (var Sample in ProductManagement.SampleList)
            {
                var item = Sample.Value;
                Console.Write(" *{0}* :{1} 、", item.id, item.name);
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
            Console.Write("目前商品  ");
            foreach (var itemID in shopItemIDList)
            {
                var item = ProductManagement.getProductByID(itemID);
                Console.Write("{0}、", item.name);
            }
            Console.WriteLine();

            Console.Write("目前商品總金額 :{0}", GetShopItemSum());
            Console.WriteLine();
        }

        public void AddCartItem(string type)
        {
            var product = ProductManagement.getProductByID(type);
            if (product != null)
                shopItemIDList.Add(type);
        }
    }

    public class ProductManagement
    {
        static public Dictionary<int,Product> SampleList
        {
            get
            {
                var SampleList = new Dictionary<int, Product>();
                SampleList.Add(1, new Product(1, "二手蘋果手機", 8700));
                SampleList.Add(2, new Product(2, "C# cookbook", 568));
                SampleList.Add(3, new Product(3, "HP 筆電", 16888));
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

        public string name;

        public double price;

        public Product(int id, string name, int price)
        {
            this.id = id;
            this.name = name;
            this.price = price;
        }
    }

}
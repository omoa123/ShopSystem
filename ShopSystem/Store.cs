using System;
using System.Collections.Generic;
using System.Linq;

namespace ShopSystem
{

    public class ShoppingCart
    {
        public List<Product> shopItemList = new List<Product>();

        public void PrintIntroduction()
        {
            Console.Write("請輸入數字:");
            foreach (var item in Product.SampleList)
            {
                Console.Write(" *{0}* :{1} 、", item.id, item.name);
            }
            Console.Write("，  0 結束");
            Console.WriteLine();
        }

        public double GetShopItemSum()
        {
            return shopItemList != null ? shopItemList.Sum(i => i.price) : 0;
        }

        public void PrintAllShoppingItem()
        {
            Console.Write("目前商品  ");
            foreach (var item in shopItemList)
            {
                Console.Write("{0}、", item.name);
            }
            Console.WriteLine();

            Console.Write("目前商品總金額 :{0}", GetShopItemSum());
            Console.WriteLine();
        }

        public void AddCartItem(string type)
        {
            var product = Product.getProductByID(type);
            if (product != null)
                shopItemList.Add(product);
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

        static public List<Product> SampleList
        {
            get
            {
                var SampleList = new List<Product>();
                SampleList.Add(new Product(1, "二手蘋果手機", 8700));
                SampleList.Add(new Product(2, "C# cookbook", 568));
                SampleList.Add(new Product(3, "HP 筆電", 16888));
                return SampleList;
            }
        }

        static public Product getProductByID(string id)
        {
            try
            {
                return SampleList.FirstOrDefault(i => i.id == int.Parse(id));
            }
            catch
            {
                return null;
            }
        }

    }

}
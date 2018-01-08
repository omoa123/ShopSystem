using System;
using System.Collections.Generic;
using System.Linq;

namespace ShopSystem
{
    public class Store
    {
        public ShoppingCart shoppingCart = new ShoppingCart();

        public void PrintIntroduction()
        {
            Console.Write("請輸入數字:");
            foreach (var item in shoppingCart.shopItemList)
            {
                Console.Write("{1}、Name :{0}", item.id, item.name);
            }
            Console.Write("，  0 結束");
            Console.WriteLine();
        }
        
        public void PrintAllShoppingItem()
        {
            Console.Write("目前商品");
            foreach (var item in shoppingCart.shopItemList)
            {
                Console.Write("Name :{0}", item.name);
            }
            Console.WriteLine();

            Console.Write("目前商品總金額 :{0}", shoppingCart.shopItemList.Sum(i => i.price));
            Console.WriteLine();
        }
    }

    public class ShoppingCart
    {
        public List<Product> shopItemList = new List<Product>();
     
        public void AddCartItem(string type)
        {
            shopItemList.Add(Product.getProductByID(type));
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

        static public Product getProductByID(string id)
        {
            switch (id)
            {
                case "1":
                    return new Product(1, "二手蘋果手機", 8700);
                case "2":
                    return new Product(2, "C# cookbook", 568);
                case "3":
                    return new Product(3, "HP 筆電", 16888);
                default:
                    return null;
            }
        }
    }

}
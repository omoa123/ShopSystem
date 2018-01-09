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
                Console.Write(" *{0}* :{1} {2} {3}", item.Id,StoreManagement.GetStoreByID(item.StoreID).Name, item.Name, item.Price);
                Console.WriteLine();
            }
            Console.Write(" *0*  結束");
            Console.WriteLine();
        }

        public double GetShopItemSum()
        {
            var sum = 0.0;
            foreach (var itemID in shopItemIDList)
            {
                var item = ProductManagement.GetProductByID(itemID);
                if (item != null)
                    sum += item.Price;
            }
            return sum;
        }

        public void PrintAllShoppingItem()
        {
            Console.Write("目前商品  \n");
            foreach (var Sampleitem in ProductManagement.SampleList)
            {
                var item = Sampleitem.Value;
                var count = shopItemIDList.Count(i => i == item.Id.ToString());
                Console.Write("{0} 數量:{1} \n", item.Name, count);
            }

            Console.Write("目前商品總金額 :{0}", GetShopItemSum());
            Console.WriteLine();
        }

        public void AddCartItem(string type)
        {
            var product = ProductManagement.GetProductByID(type);
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
}
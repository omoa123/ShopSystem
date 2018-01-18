using System;
using System.Collections.Generic;
using System.Linq;
using ShopSystem.Model;

namespace ShopSystem.Controller
{
    public class ShoppingCart
    {
        private List<string> _shopItemIdList = new List<string>();
        
        public Dictionary<int, Product> SampleList { get; set; }

        public delegate Product GetProductById(string id);
        private GetProductById _getProductById;

        public delegate Store GetStoreById(int storeid);
        private GetStoreById _getStoreById;

        public ShoppingCart(Dictionary<int, Product> sampleList, GetStoreById getStoreById, GetProductById getProductById)
        {
            SampleList = sampleList;
            _getStoreById = getStoreById;
            _getProductById = getProductById;
        }

        public void PrintIntroduction()
        {
            Console.Write("以下是商品列表:\n");
            foreach (var Sample in SampleList)
            {
                var item = Sample.Value;
                Console.Write(" *{0}* :{1} {2}\t{3}\n", item.Id, _getStoreById.Invoke(item.StoreId).Name, item.Name, item.Price);
            }
            Console.Write(" *0*  結束\n");
        }

        public double GetShopItemSum()
        {
            var sum = 0.0;
            foreach (var itemId in _shopItemIdList)
            {
                var item = _getProductById.Invoke(itemId);
                if (item != null)
                    sum += item.Price;
            }
            return sum;
        }

        public void PrintAllShoppingItem()
        {
            Console.Write("目前商品  \n");
            foreach (var Sampleitem in SampleList)
            {
                var item = Sampleitem.Value;
                var count = _shopItemIdList.Count(i => i == item.Id.ToString());
                Console.Write(" *{0}* :{1} {2}\t{3} \n", item.Id, _getStoreById.Invoke(item.StoreId).Name, item.Name, count);
                //Console.Write("{0} 數量:{1} \n", item.Name, count);
            }

            Console.Write("目前商品總金額 :{0}\n", GetShopItemSum());
        }

        public void AddCartItem(string type)
        {
            var product = _getProductById.Invoke(type);
            if (product != null)
                _shopItemIdList.Add(type);
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
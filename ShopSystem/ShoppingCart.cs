using System;
using System.Collections.Generic;
using System.Linq;

namespace ShopSystem
{
    public class ShoppingCart
    {
        private List<string> shopItemIDList = new List<string>();

        private Dictionary<int, Product> _SampleList;
        public Dictionary<int, Product> SampleList
        {
            get
            {
                return _SampleList;
            }
            set
            {
                _SampleList = value;
            }
        }

        public delegate Product GetProductByID(string id);
        private GetProductByID _GetProductByID;

        public delegate Store GetStoreByID(int storeid);
        private GetStoreByID _GetStoreByID;

        public ShoppingCart(Dictionary<int, Product> SampleList, GetStoreByID GetStoreByID, GetProductByID GetProductByID)
        {
            _SampleList = SampleList;
            _GetStoreByID = GetStoreByID;
            _GetProductByID = GetProductByID;
        }

        public void PrintIntroduction()
        {
            Console.Write("以下是商品列表:\n");
            foreach (var Sample in SampleList)
            {
                var item = Sample.Value;
                Console.Write(" *{0}* :{1} {2} {3}\n", item.Id, _GetStoreByID.Invoke(item.StoreID).Name, item.Name, item.Price);
            }
            Console.Write(" *0*  結束\n");
        }

        public double GetShopItemSum()
        {
            var sum = 0.0;
            foreach (var itemID in shopItemIDList)
            {
                var item = _GetProductByID.Invoke(itemID);
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
                var count = shopItemIDList.Count(i => i == item.Id.ToString());
                Console.Write("{0} 數量:{1} \n", item.Name, count);
            }

            Console.Write("目前商品總金額 :{0}\n", GetShopItemSum());
        }

        public void AddCartItem(string type)
        {
            var product = _GetProductByID.Invoke(type);
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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSystem.Tests
{
    [TestClass()]
    public class ShoppingCartTests
    {
        private static ShoppingCart ShoppingCartInit()
        {
            var StoreList = new Dictionary<int, Store>();
            StoreList.Add(1, new Store(1, "OO商店"));
            StoreList.Add(2, new Store(2, "XX商店"));
            var StoreManagement = new StoreManagement(StoreList);

            var SampleList = new Dictionary<int, Product>();
            SampleList.Add(1, new Product(1, "二手蘋果手機", 8700, 1));
            SampleList.Add(2, new Product(2, "C# cookbook", 568, 1));
            SampleList.Add(3, new Product(3, "HP 筆電", 16888, 1));
            SampleList.Add(4, new Product(4, "哈利波特影集", 2250, 2));
            SampleList.Add(5, new Product(5, "無間道三部曲", 1090, 2));

            var ProductManagement = new ProductManagement(SampleList);
            var shoppingCart = new ShoppingCart(SampleList, StoreManagement.GetStoreByID, ProductManagement.GetProductByID);

            return shoppingCart;
        }

        [TestMethod()]
        public void AddCartItemTest()
        {
            ShoppingCart shoppingCart = ShoppingCartInit();
            shoppingCart.AddCartItem("1");
            Assert.AreEqual(8700, shoppingCart.GetShopItemSum());
        }


        [TestMethod()]
        public void AddCartItemTest2()
        {
            ShoppingCart shoppingCart = ShoppingCartInit();
            shoppingCart.AddCartItem("2");
            shoppingCart.AddCartItem("3");
            Assert.AreEqual(17456, shoppingCart.GetShopItemSum());
        }

        [TestMethod()]
        public void AddCartItemTest3()
        {
            ShoppingCart shoppingCart = ShoppingCartInit();
            shoppingCart.AddCartItem("1",3);
            Assert.AreEqual(26100, shoppingCart.GetShopItemSum());
        }
    }
}
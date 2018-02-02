using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopSystem;
using ShopSystem.Controller;
using ShopSystem.Model;
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

            var productSampleList = new Dictionary<int, Product>();
            productSampleList.Add(1, new Product(1, "二手蘋果手機", 8700, 1));
            productSampleList.Add(2, new Product(2, "C# cookbook", 568, 1));
            productSampleList.Add(3, new Product(3, "HP 筆電\t", 16888, 1));
            productSampleList.Add(4, new Product(4, "哈利波特影集", 2250, 2));
            productSampleList.Add(5, new Product(5, "無間道三部曲", 1090, 2));
            var ProductManagement = new ProductManagement(productSampleList);
            var ShipmentList = new Dictionary<int, Shipment>();
            ShipmentList.Add(1, new Shipment(1, "宅急便", 60));
            ShipmentList.Add(2, new Shipment(2, "郵局", 40));
            ShipmentList.Add(3, new Shipment(3, "超商店到店", 50));
            var shipmentManagement = new ShipmentManagement(ShipmentList);
            var shoppingCart = new ShoppingCart(productSampleList, StoreList, ShipmentList, StoreManagement.GetStoreById, ProductManagement.GetProductById);

            return shoppingCart;
        }

        [TestMethod()]
        public void AddCartItemTest()
        {
            ShoppingCart shoppingCart = ShoppingCartInit();
            shoppingCart.AddCartItem(1,1,1);
            Assert.AreEqual(8700, shoppingCart.GetShopItemSum());
        }


        [TestMethod()]
        public void AddCartItemTest2()
        {
            ShoppingCart shoppingCart = ShoppingCartInit();
            shoppingCart.AddCartItem(1, 2, 1);
            shoppingCart.AddCartItem(1, 3, 1);
            Assert.AreEqual(17456, shoppingCart.GetShopItemSum());
        }

        [TestMethod()]
        public void AddCartItemTest3()
        {
            ShoppingCart shoppingCart = ShoppingCartInit();
            shoppingCart.AddCartItem(-1, 1, 3);
            shoppingCart.AddCartItem(-1, 3, 2);
            Assert.AreEqual(26100, shoppingCart.GetShopItemSum());
        }
    }
}
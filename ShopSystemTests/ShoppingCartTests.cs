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
        [TestMethod()]
        public void AddCartItemTest()
        {
            var shoppingCart = new ShoppingCart();
            shoppingCart.AddCartItem("1");
            Assert.AreEqual(8700, shoppingCart.GetShopItemSum());
        }

        [TestMethod()]
        public void AddCartItemTest2()
        {
            var shoppingCart = new ShoppingCart();
            shoppingCart.AddCartItem("2");
            shoppingCart.AddCartItem("3");
            Assert.AreEqual(17456, shoppingCart.GetShopItemSum());
        }
    }
}
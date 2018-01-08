using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputNumber = null;

            var shoppingCart = new ShoppingCart();
            while (inputNumber != "0")
            {
                shoppingCart.PrintIntroduction();
                shoppingCart.AddCartItem(inputNumber = Console.ReadLine());
                shoppingCart.PrintAllShoppingItem();
            }

            Console.Write("按下ENTER結束");
            Console.ReadLine();
        }
    }
}

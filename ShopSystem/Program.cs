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
            string number = null;

            var store = new Store();
            while (number != "0")
            {
                store.PrintIntroduction();
                store.shoppingCart.AddCartItem(Console.ReadLine());
                store.PrintAllShoppingItem();
            }

            Console.Write("按下ENTER結束");
            Console.ReadLine();
        }
    }
}

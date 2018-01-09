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
            string inputItemNumber = null;

            var shoppingCart = new ShoppingCart();

            shoppingCart.PrintIntroduction();

            while (inputItemNumber != "0")
            {
                Console.Write("請選擇商品代號:\n");

                inputItemNumber = Console.ReadLine();
                if (inputItemNumber == "0")
                    break;

                var product = ProductManagement.GetProductByID(inputItemNumber);
                if (product != null)
                {
                    var inputItemCount = -1;
                    while (inputItemCount < 0)
                    {
                        Console.Write("請選擇數量\n");
                        var r = Console.ReadLine();
                        try
                        {
                            inputItemCount = int.Parse(r);
                        }
                        catch
                        {
                            Console.Write("格式錯誤，重新輸入\n");
                        }
                    }
                    shoppingCart.AddCartItem(inputItemNumber, inputItemCount);
                    shoppingCart.PrintAllShoppingItem();
                }
                else {
                    Console.Write("查無商品，重新輸入\n");
                }
               
            }

            Console.Write("按下ENTER結束\n");
            Console.ReadLine();
        }
    }
}

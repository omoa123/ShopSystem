using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopSystem.Model;
using ShopSystem.Controller;

namespace ShopSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputItemNumber = null;

            var StoreList = new Dictionary<int, Store>();
            StoreList.Add(1, new Store(1, "OO商店"));
            StoreList.Add(2, new Store(2, "XX商店"));
            var StoreManagement = new StoreManagement(StoreList);
            var SampleList = new Dictionary<int, Product>();
            SampleList.Add(1, new Product(1, "二手蘋果手機", 8700, 1));
            SampleList.Add(2, new Product(2, "C# cookbook", 568, 1));
            SampleList.Add(3, new Product(3, "HP 筆電\t", 16888, 1));
            SampleList.Add(4, new Product(4, "哈利波特影集", 2250, 2));
            SampleList.Add(5, new Product(5, "無間道三部曲", 1090, 2));

            var ProductManagement = new ProductManagement(SampleList);
            var shoppingCart = new ShoppingCart(SampleList, StoreManagement.GetStoreByID, ProductManagement.GetProductById);

            shoppingCart.PrintIntroduction();

            while (inputItemNumber != "0")
            {
                Console.Write("請選擇商品代號:\n");

                inputItemNumber = Console.ReadLine();
                if (inputItemNumber == "0")
                    break;

                var product = ProductManagement.GetProductById(inputItemNumber);
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

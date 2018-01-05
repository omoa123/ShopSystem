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
            List<ShopItem> ShopItemList = new List<ShopItem>();

            while(number != "0")
            {
                Console.Write("請輸入數字: 1~3  0 結束");
                number = Console.ReadLine();
                var inputItem = new ShopItem();
                switch (number) {
                    case "1":
                        inputItem = new ShopItem() { id = 1,name = "二手蘋果手機",price = 8700 };
                        ShopItemList.Add(inputItem);
                        break;
                    case "2":
                        inputItem = new ShopItem() { id = 2, name = "C# cookbook", price = 568 };
                        ShopItemList.Add(inputItem);
                        break;
                    case "3":
                        inputItem = new ShopItem() { id = 3, name = "HP 筆電", price = 16888 };
                        ShopItemList.Add(inputItem);
                        break;
                    default:
                        break;                        
                }
                Console.Write("目前商品");
                PrintAll(ShopItemList);
            }

            Console.Write("按下ENTER結束");
            Console.ReadLine();
        }

        public static void PrintAll(List<ShopItem> ShopItemList)
        {
            foreach (var item in ShopItemList)
            {
                Console.Write("Name :{0}",item.name);
            }
            Console.WriteLine();

            Console.Write("目前商品總金額 :{0}", ShopItemList.Sum(i => i.price));
            Console.WriteLine();
        }

    }

    internal class ShopItem
    {
        public int id;

        public string name;

        public double price;
    }
}

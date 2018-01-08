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
                Console.Write("請輸入數字: 1、二手蘋果手機，2、C# cookbook，3、HP 筆電，  0 結束");
                number = Console.ReadLine();
                store.addCartItem(number);
                Console.Write("目前商品");
                store.PrintAll();
            }

            Console.Write("按下ENTER結束");
            Console.ReadLine();
        }
    }

    internal class ShopItem
    {
        public int id;

        public string name;

        public double price;
    }

    public class Store
    {
        private List<ShopItem> ShopItemList = new List<ShopItem>();

        public enum ItemType { 二手蘋果手機 = 1, cookbook = 2, HP筆電 = 3, 其他 = -1 };

        public void addCartItem(string type) {
            var t = ItemType.其他;
            switch (type)
            {
                case "1":
                    t = ItemType.二手蘋果手機;
                    break;
                case "2":
                    t = ItemType.cookbook;
                    break;
                case "3":
                    t = ItemType.HP筆電;
                    break;
                default:
                    break;
            }
            addCartItem(t);
        }

        public void addCartItem(ItemType type)
        {
            switch (type)
            {
                case ItemType.二手蘋果手機:
                    ShopItemList.Add(new ShopItem() { id = 1, name = "二手蘋果手機", price = 8700 });
                    break;
                case ItemType.cookbook:
                    ShopItemList.Add(new ShopItem() { id = 2, name = "C# cookbook", price = 568 });
                    break;
                case ItemType.HP筆電:
                    ShopItemList.Add(new ShopItem() { id = 3, name = "HP 筆電", price = 16888 });
                    break;
                default:
                    break;
            }
        }

        public void PrintAll()
        {
            foreach (var item in ShopItemList)
            {
                Console.Write("Name :{0}", item.name);
            }
            Console.WriteLine();

            Console.Write("目前商品總金額 :{0}", ShopItemList.Sum(i => i.price));
            Console.WriteLine();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopSystem.Model;
using ShopSystem.Controller;
using ShopSystem.Utils;

namespace ShopSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManagement ProductManagement;
            ShipmentManagement shipmentManagement;
            ShoppingCart shoppingCart;
            SystemInit(out ProductManagement, out shipmentManagement, out shoppingCart);

            shoppingCart.PrintIntroduction();

            string selectedProductId = null;
            while (selectedProductId != "0")
            {
                Console.Write("請選擇商品代號:\n");

                selectedProductId = Console.ReadLine();
                if (selectedProductId == "0")
                    break;

                var productId = selectedProductId.TryParseInt() ?? -1;
                var product = ProductManagement.GetProductById(productId);
                if (product != null)
                {
                    var selectedProductCount = -1;
                    var selectedShipment = -1;
                    while (selectedProductCount < 0)
                    {
                        Console.Write("請選擇數量\n");
                        selectedProductCount = Console.ReadLine().TryParseInt() ?? -1;

                        Console.Write("請選擇物流\n");
                        shoppingCart.PrintAllShipment();

                        selectedShipment = Console.ReadLine().TryParseInt() ?? -1;
                        var shipment = shipmentManagement.GetShipmentById(selectedShipment);
                        if (shipment != null)
                        {
                            shoppingCart.AddCartItem(selectedShipment, productId, selectedProductCount);
                        }
                        else
                        {
                            Console.Write("格式錯誤，重新輸入\n");
                        }
                    }
                    shoppingCart.PrintAllShoppingItem();
                }
                else
                {
                    Console.Write("查無商品，重新輸入\n");
                }

            }

            Console.Write("按下ENTER結束\n");
            Console.ReadLine();
        }

        private static void SystemInit(out ProductManagement ProductManagement, out ShipmentManagement shipmentManagement, out ShoppingCart shoppingCart)
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
            ProductManagement = new ProductManagement(productSampleList);
            var ShipmentList = new Dictionary<int, Shipment>();
            ShipmentList.Add(1, new Shipment(1, "宅急便", 60));
            ShipmentList.Add(2, new Shipment(2, "郵局", 40));
            ShipmentList.Add(3, new Shipment(3, "超商店到店", 50));
            shipmentManagement = new ShipmentManagement(ShipmentList);
            shoppingCart = new ShoppingCart(productSampleList, StoreList, ShipmentList, StoreManagement.GetStoreById, ProductManagement.GetProductById);
        }
    }
}

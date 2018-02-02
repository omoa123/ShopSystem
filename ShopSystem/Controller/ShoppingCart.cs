using System;
using System.Collections.Generic;
using System.Linq;
using ShopSystem.Model;
using ShopSystem.Utils;

namespace ShopSystem.Controller
{
    public class ShoppingCart
    {
        private List<CartItem> _shopItemList = new List<CartItem>();
        
        public Dictionary<int, Product> SampleList { get; set; }

        public Dictionary<int, Store> StoreList { get; set; }

        public Dictionary<int, Shipment> ShipmentList { get; set; }

        public delegate Product GetProductById(int id);
        private GetProductById _getProductById;

        public delegate Store GetStoreById(int storeid);
        private GetStoreById _getStoreById;

        public delegate Shipment GetShipmentById(int shipmentid);
        private GetShipmentById _getShipmentById;

        public ShoppingCart(Dictionary<int, Product> sampleList, Dictionary<int, Store> storeList, Dictionary<int, Shipment> shipmentList, GetStoreById getStoreById, GetProductById getProductById)
        {
            StoreList = storeList;
            SampleList = sampleList;
            ShipmentList = shipmentList;
            _getStoreById = getStoreById;
            _getProductById = getProductById;
            _getShipmentById = GetShipmentById1;
        }

        private Shipment GetShipmentById1(int id)
        {
            try
            {
                return ShipmentList.FirstOrDefault(i => i.Key == id).Value;
            }
            catch
            {
                return null;
            }
        }

        public void PrintIntroduction()
        {
            Console.Write("以下是商品列表:\n");
            foreach (var Sample in SampleList)
            {
                var item = Sample.Value;
                Console.Write(" *{0}* :{1} {2}\t{3}\n", item.Id, _getStoreById.Invoke(item.StoreId).Name, item.Name, item.Price);
            }
            Console.Write(" *0*  結束\n");
        }

        public double GetShopItemSum()
        {
            var sum = 0.0;
            foreach (var item in _shopItemList)
            {
                var product = _getProductById.Invoke(item.ProductId);
                if (product != null) {
                    //OO商店有行銷活動： 任一商品滿兩件打九折，滿三件打七折
                    if (item.StoreId == 1) {
                        if (item.Count>2) {
                            sum += product.Price * item.Count * 0.7;
                        } else if (item.Count > 1) {
                            sum += product.Price * item.Count * 0.9;
                        }
                        else {
                            sum += product.Price * item.Count;
                        }
                       
                    }
                    else {
                        sum += product.Price * item.Count;
                    }
                }
                    
            }
            return sum;
        }
        
        public double GetShippingFee()
        {
            var sum = 0.0;
            foreach (var storePair in StoreList)
            {
                var store = storePair.Value;
                foreach (var shipmentPair in ShipmentList)
                {
                    var shipment = shipmentPair.Value;

                    if (!_shopItemList.Any(x => x.StoreId == store.Id && x.ShipmentId == shipment.Id))
                        break;
                    //所有商店滿三件運費免費
                    if (_shopItemList.FirstOrDefault(x => x.StoreId == store.Id && x.ShipmentId == shipment.Id).Count > 3)
                    {

                    }
                    else {
                        //OO商店與宅急便有合作，所以當使用宅急便時一律運費八折
                        if (shipment.Name == "宅急便" && store.Name == "OO商店")
                        {
                            sum += shipment.Fee * 0.8;
                        }
                        else
                        {
                            sum += shipment.Fee;
                        }
                    }
                  
                }
            }
            return sum;
        }

        public void PrintAllShoppingItem()
        {
            Console.Write("目前商品  \n");
            foreach (var shipmentPair in ShipmentList)
            {
                var shipment = shipmentPair.Value;

                foreach (var shopItem in _shopItemList.Where(x=>x.ShipmentId == shipment.Id))
                {
                    var product = _getProductById(shopItem.ProductId);
                    Console.Write(" *{0}*\t :{1} {2}\t{3} \n", shipment.Name, _getStoreById.Invoke(shopItem.StoreId).Name, product.Name, shopItem.Count);
                }
            }
            
            Console.Write("總運費 :{0}\n", GetShippingFee());
            Console.Write("商品總金額 :{0}\n", GetShopItemSum());
            Console.Write("總金額 :{0}\n", GetShopItemSum() + GetShippingFee());
        }

        public void PrintAllShipment()
        {
            foreach (var Shipment in ShipmentList)
            {
                var item = Shipment.Value;
                var count = _shopItemList.Count(i => i.ProductId == item.Id);
                Console.Write(" *{0}* :{1} {2}\t \n", item.Id, _getShipmentById.Invoke(item.Id).Name, item.Name);
            }
        }

        public void AddCartItem(int shipmentId, int productId, int count)
        {
            var product = _getProductById(productId);

            var item = _shopItemList.FirstOrDefault(x => x.ProductId == productId && x.ShipmentId == shipmentId);
            if (item != null)
            {
                item.Count += count;
            }
            else
            {
                _shopItemList.Add(new CartItem {
                    ProductId = productId,
                    ShipmentId = shipmentId,
                    StoreId = _getStoreById(product.StoreId).Id,
                    Count = count,
                });
            }
        }
    }
}
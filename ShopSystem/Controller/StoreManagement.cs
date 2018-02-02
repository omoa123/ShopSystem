using System.Collections.Generic;
using System.Linq;
using ShopSystem.Model;
using ShopSystem.Utils;

namespace ShopSystem.Controller
{
    public class StoreManagement
    {
        private Dictionary<int, Store> _storeList;
        public Dictionary<int, Product> SampleList { get; set; }

        public StoreManagement(Dictionary<int, Store> storeList)
        {
            _storeList = storeList;
        }

        public Store GetStoreById(int storeid)
        {
            try
            {
                return _storeList.FirstOrDefault(i => i.Key == storeid).Value;
            }
            catch
            {
                return null;
            }
        }
        
    }
}
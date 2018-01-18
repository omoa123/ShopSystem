using System.Collections.Generic;
using System.Linq;
using ShopSystem.Model;

namespace ShopSystem.Controller
{
    public class StoreManagement
    {
        private Dictionary<int, Store> _storeList;


        public StoreManagement(Dictionary<int, Store> storeList)
        {
            _storeList = storeList;
        }


        public Store GetStoreByID(int storeid)
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
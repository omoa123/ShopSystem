using System.Collections.Generic;
using System.Linq;

namespace ShopSystem
{
    public class StoreManagement
    {
        private Dictionary<int, Store> _StoreList;


        public StoreManagement(Dictionary<int, Store> StoreList)
        {
            _StoreList = StoreList;
        }


        public Store GetStoreByID(int storeid)
        {
            try
            {
                return _StoreList.FirstOrDefault(i => i.Key == storeid).Value;
            }
            catch
            {
                return null;
            }
        }

    }
}
using System.Collections.Generic;
using System.Linq;

namespace ShopSystem
{
    public class StoreManagement
    {
        static public Dictionary<int, Store> StoreList
        {
            get
            {
                var StoreList = new Dictionary<int, Store>();
                StoreList.Add(1, new Store(1, "OO商店"));
                StoreList.Add(2, new Store(2, "XX商店"));
                return StoreList;
            }
        }

        static public Store GetStoreByID(int storeid)
        {
            try
            {
                return StoreList.FirstOrDefault(i => i.Key == storeid).Value;
            }
            catch
            {
                return null;
            }
        }

    }
}
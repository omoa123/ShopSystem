using System.Collections.Generic;
using System.Linq;

namespace ShopSystem
{
    public class ProductManagement
    {
        private Dictionary<int, Product> _SampleList;

        public Dictionary<int, Product> SampleList {
            get {
                return _SampleList;
            }
            set
            {
                _SampleList = value;
            }
        }

        public ProductManagement(Dictionary<int, Product> SampleList)
        {
            _SampleList = SampleList;
        }
        
        public Product GetProductByID(string id)
        {
            try
            {
                return _SampleList.FirstOrDefault(i => i.Key == int.Parse(id)).Value;
            }
            catch
            {
                return null;
            }
        }

    }
}
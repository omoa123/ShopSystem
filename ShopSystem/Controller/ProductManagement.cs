using System.Collections.Generic;
using System.Linq;
using ShopSystem.Model;

namespace ShopSystem.Controller
{
    public class ProductManagement
    {
        public Dictionary<int, Product> SampleList { get; set; }

        public ProductManagement(Dictionary<int, Product> sampleList)
        {
            SampleList = sampleList;
        }
        
        public Product GetProductById(string id)
        {
            try
            {
                return SampleList.FirstOrDefault(i => i.Key == int.Parse(id)).Value;
            }
            catch
            {
                return null;
            }
        }

    }
}
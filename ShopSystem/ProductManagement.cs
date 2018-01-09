using System.Collections.Generic;
using System.Linq;

namespace ShopSystem
{
    public class ProductManagement
    {
        static public Dictionary<int, Product> SampleList
        {
            get
            {
                var SampleList = new Dictionary<int, Product>();
                SampleList.Add(1, new Product(1, "二手蘋果手機", 8700, 1));
                SampleList.Add(2, new Product(2, "C# cookbook", 568, 1));
                SampleList.Add(3, new Product(3, "HP 筆電", 16888, 1));
                SampleList.Add(4, new Product(4, "哈利波特影集", 2250, 2));
                SampleList.Add(5, new Product(5, "無間道三部曲", 1090, 2));
                return SampleList;
            }
        }

        static public Product GetProductByID(string id)
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
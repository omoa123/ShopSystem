using System.Linq;

namespace ShopSystem.Model
{
    public class Product
    {
        public int Id;

        public int StoreId;

        public string Name;

        public double Price;

        public Product(int id, string name, int price, int storeId)
        {
            Id = id;
            Name = name;
            Price = price;
            StoreId = storeId;
        }
    }
}
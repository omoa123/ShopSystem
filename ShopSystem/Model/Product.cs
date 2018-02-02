using System.Linq;

namespace ShopSystem.Model
{
    public class Product
    {
        public int Id;

        public string Name;

        public double Price;

        public int StoreId;

        public Product(int id, string name, int price, int storeId)
        {
            Id = id;
            Name = name;
            Price = price;
            StoreId = storeId;
        }
    }
}
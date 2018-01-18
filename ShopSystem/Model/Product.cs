using System.Linq;

namespace ShopSystem.Model
{
    public class Product
    {
        public int Id;

        public int StoreID;

        public string Name;

        public double Price;

        public Product(int id, string name, int price, int storeID)
        {
            this.Id = id;
            this.Name = name;
            this.Price = price;
            this.StoreID = storeID;
        }
    }
}
using System.Linq;

namespace ShopSystem.Model
{
    public class Store
    {
        public int Id;
        
        public string Name;
        public Store(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
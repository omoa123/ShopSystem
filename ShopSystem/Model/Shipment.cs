using System.Linq;

namespace ShopSystem.Model
{
    public class Shipment
    {
        public int Id;
        
        public string Name;

        public double Fee;

        public Shipment(int id, string name, double fee)
        {
            Id = id;
            Name = name;
            Fee = fee;
        }
    }
}
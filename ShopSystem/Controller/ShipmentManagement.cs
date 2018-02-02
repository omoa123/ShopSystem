using System.Collections.Generic;
using System.Linq;
using ShopSystem.Model;

namespace ShopSystem.Controller
{
    public class ShipmentManagement
    {
        public Dictionary<int, Shipment> SampleList { get; set; }

        public ShipmentManagement(Dictionary<int, Shipment> sampleList)
        {
            SampleList = sampleList;
        }
        
        public Shipment GetShipmentById(int id)
        {
            try
            {
                return SampleList.FirstOrDefault(i => i.Key == id).Value;
            }
            catch
            {
                return null;
            }
        }

    }
}
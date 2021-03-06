﻿using System.Collections.Generic;
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
        
        public Product GetProductById(int id)
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
﻿using System.Linq;

namespace ShopSystem
{
    public class Store
    {
        public int Id;
        
        public string Name;
        public Store(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}
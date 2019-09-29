using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStoreAPI.Models
{
    public class Products
    {
        public string ProductID { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }

        public DateTime Expiry { get; set; }
        public bool Available { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}

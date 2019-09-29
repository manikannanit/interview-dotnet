using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStoreAPI.Models
{
    public class Orders
    {
        public string OrderNumber { get; set; }
        public string CustomerID { get; set; }

        public DateTime OrderDate { get; set; }
        public string Payment { get; set; }

        public int Quantity { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public string Status { get; set; }
    }
}

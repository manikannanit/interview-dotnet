using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStoreAPI.Models
{
    public class Orders
    {

        public int id { get; set; }
        public int customerId { get; set; }

        public List<Items> items { get; set; }

        //public string OrderNumber { get; set; }
        //public string CustomerID { get; set; }

        //public DateTime OrderDate { get; set; }
        //public string Payment { get; set; }

        //public int Quantity { get; set; }
        //public string Address { get; set; }
        //public string ContactNumber { get; set; }
        //public string Status { get; set; }
    }
    public class Items
    {
        public int productId { get; set; }
        public int quantity { get; set; }
    }

    }

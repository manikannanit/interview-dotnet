using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStoreAPI.Models
{
    public class Customers
    {

        public int id { get; set; }
        public string name { get; set; }       
    }   

    public class APIData
    {
        public List<Customers> customers { get; set; }
        public List<Models.Orders> orders { get; set; }
        public List<Models.Products> products { get; set; }
    }
    
}

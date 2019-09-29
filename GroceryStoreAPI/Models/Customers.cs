using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStoreAPI.Models
{
    public class Customers
    {
        public string CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string DOB { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public string EmailID { get; set; }
    }
}

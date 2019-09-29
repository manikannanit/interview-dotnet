using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GroceryStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {       
        
        static List<Models.Orders> orders = new List<Models.Orders>    {
                new Models.Orders
                {
                    OrderNumber ="00001",
                    CustomerID ="01",
                    Payment="CreditCard",
                    Quantity= 2,
                    Address ="",
                    Status ="Shipped",
                    ContactNumber ="1222332232",                    
                    OrderDate =System.DateTime.UtcNow

                },
                 new Models.Orders
                {
                    OrderNumber ="00002",
                    CustomerID ="02",
                    Payment="Paypal",
                    Quantity= 1,
                    Address ="",
                    Status ="Ready to Shipment",
                    ContactNumber ="8887667676",
                    OrderDate =System.DateTime.UtcNow
                }
            };

        public IEnumerable<Models.Orders> GetAllOrdersList()
        {
            return orders;
        }

        //[HttpGet("{OrderID}", Name = "GetOrder")]
        //public Models.Orders GetOrderID(DateTime ProductOrderDate)
        //{
        //    var selectedOrder = orders.SingleOrDefault(x => x.OrderDate == ProductOrderDate);                       
        //    return selectedOrder;
        //}


        [HttpGet("{CustomerID}", Name = "GetAllOrdersByCustomers")]
        public IEnumerable<Models.Orders> GetOrdersByCustomerID(string CustomerID, string OrderID)
        {
            var selectedOrder = orders.Where(x => x.CustomerID == CustomerID);
            return selectedOrder;            
        }        

        [HttpPost]
        public Models.Orders post([FromBody] Models.Orders order)
        {
            orders.Add(order);
            return order;
        }
    }

}

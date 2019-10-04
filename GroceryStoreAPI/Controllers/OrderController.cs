using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GroceryStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {       
        
        static List<Models.Orders> orders = new List<Models.Orders>    {
                new Models.Orders
                {
                    //OrderNumber ="00001",
                    //CustomerID ="01",
                    //Payment="CreditCard",
                    //Quantity= 2,
                    //Address ="",
                    //Status ="Shipped",
                    //ContactNumber ="1222332232",                    
                    //OrderDate =System.DateTime.UtcNow

                },
                 new Models.Orders
                {
                    //OrderNumber ="00002",
                    //CustomerID ="02",
                    //Payment="Paypal",
                    //Quantity= 1,
                    //Address ="",
                    //Status ="Ready to Shipment",
                    //ContactNumber ="8887667676",
                    //OrderDate =System.DateTime.UtcNow
                }
            };

        public IEnumerable<Models.Orders> GetAllOrdersList()
        {
            string data;
            using (StreamReader reader = new StreamReader(new FileStream(Path.GetFileName("../database.json"), FileMode.Open)))
            {
                data = reader.ReadToEnd();
            }
            var Orders = JsonConvert.DeserializeObject<Models.APIData>(data);
            var AllOrders = Orders.orders;
            return AllOrders;
        }


        [HttpGet("{CustomerID}", Name = "GetAllOrdersByCustomers")]
        public IEnumerable<Models.Orders> GetOrdersByCustomerID(int CustomerID)
        {
            string data;
            using (StreamReader reader = new StreamReader(new FileStream(Path.GetFileName("../database.json"), FileMode.Open)))
            {
                data = reader.ReadToEnd();
            }
            var Orders = JsonConvert.DeserializeObject<Models.APIData>(data);
            var AllOrdersByCustomer = Orders.orders.Where(x => x.customerId == CustomerID);
            return AllOrdersByCustomer;
        }

        [Route("api/Order/{OrderID}/{customerID}")]
        [HttpGet("{OrderID}", Name = "GetOrderByID")]
        public IEnumerable<Models.Orders> GetOrderByID(int OrderID)
        {
            string data;
            using (StreamReader reader = new StreamReader(new FileStream(Path.GetFileName("../database.json"), FileMode.Open)))
            {
                data = reader.ReadToEnd();
            }
            var Orders = JsonConvert.DeserializeObject<Models.APIData>(data);
            var OrderByID = Orders.orders.Where(x => x.id == OrderID);
            return OrderByID;
        }

        [HttpPost]
        public Models.Orders post([FromBody] Models.Orders order)
        {
            orders.Add(order);
            return order;
        }
    }

}

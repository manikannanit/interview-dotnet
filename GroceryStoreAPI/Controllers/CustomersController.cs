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
    public class CustomersController : ControllerBase
    {
        static List<Models.Customers> customers = new List<Models.Customers>    {
                new Models.Customers
                {
                    CustomerID ="01",
                    FirstName="Manikannan",
                    LastName= "Nagarajan",
                    Address ="",
                    DOB ="02/19/1982",
                    ContactNumber ="8043098677"

                },
                 new Models.Customers
                {
                     CustomerID ="02",
                    FirstName="Vijila",
                    LastName= "Manikannan",
                    Address ="",
                    DOB ="03-17-1986",
                    ContactNumber ="8043098600"
                }
            };

        [HttpGet(Name = "GetAllCustomers")]
        public IEnumerable<Models.Customers> GetAllCustmerList()
        {
            return customers;
        }

        //[HttpGet("{CustomerID}", Name = "Get")]
        //public IEnumerable<Models.Customers> GetCustmer()
        //{
        //    return customers.SingleOrDefault(x => x.CustomerID ==Name);

        //}

        
        [HttpGet("{CustomerID}", Name = "GetCustomer")]
        public Models.Customers GetCustmer(string CustomerID)
        {
           var selectedCustomer = customers.SingleOrDefault(x => x.CustomerID == CustomerID);

           // if (selectedCustomer != null)                
            return selectedCustomer;
        }

        [HttpPost]
        public Models.Customers post([FromBody] Models.Customers customer)
        {
            customers.Add(customer);
            return customer;
        }
    }




    // GET: api/Customers
    //[HttpGet]
    //    public IEnumerable<string> Get()
    //    {
    //        return new string[] { "value1", "value2" };
    //    }

    //    // GET: api/Customers/5
    //    [HttpGet("{id}", Name = "Get")]
    //    public string Get(int id)
    //    {
    //        return "value";
    //    }

    //    // POST: api/Customers
    //    [HttpPost]
    //    public void Post([FromBody] string value)
    //    {
    //    }

    //    // PUT: api/Customers/5
    //    [HttpPut("{id}")]
    //    public void Put(int id, [FromBody] string value)
    //    {
    //    }

    //    // DELETE: api/ApiWithActions/5
    //    [HttpDelete("{id}")]
    //    public void Delete(int id)
    //    {
    //    }
    }


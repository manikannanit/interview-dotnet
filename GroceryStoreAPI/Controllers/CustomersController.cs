using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Newtonsoft.Json;

namespace GroceryStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {

        //object customers = System.IO.File.ReadAllText("~/database.json"){


        static List<Models.Customers> customers = new List<Models.Customers>    {
                new Models.Customers
                {
                    //CustomerID ="01",
                    //FirstName="Manikannan",
                    //LastName= "Nagarajan",
                    //Address ="",
                    //DOB ="02/19/1982",
                    //ContactNumber ="8043098677"

                },
                 new Models.Customers
                {
                    // CustomerID ="02",
                    //FirstName="Vijila",
                    //LastName= "Manikannan",
                    //Address ="",
                    //DOB ="03-17-1986",
                    //ContactNumber ="8043098600"
                }
            };


        [HttpGet(Name = "GetAllCustmers")]
        public IEnumerable<Models.Customers> GetAllCustmers()
        {
            string data;
            using (StreamReader reader = new StreamReader(new FileStream(Path.GetFileName("../database.json"), FileMode.Open)))
            {
                data = reader.ReadToEnd();
            }
            var Customers = JsonConvert.DeserializeObject<Models.APIData>(data);
            var AllCustomers = Customers.customers;
            return AllCustomers;            
        }


        [HttpGet("{CustomerID}", Name = "GetAllCustomers")]       
        public IEnumerable<Models.Customers> GetAllCustmerList(int CustomerID)
        {
            string data;
            using (StreamReader reader = new StreamReader(new FileStream(Path.GetFileName("../database.json"), FileMode.Open)))
            {
                data = reader.ReadToEnd();
            }
            var Customers = JsonConvert.DeserializeObject<Models.APIData>(data);        
            var selectedOrder = Customers.customers.Where(x => x.id == CustomerID);
            return selectedOrder;         
        } 

        [HttpPost]
        public Models.Customers post([FromBody] Models.Customers customer)
        {

            string data;
            using (StreamReader reader = new StreamReader(new FileStream(Path.GetFileName("../database.json"), FileMode.Open)))
            {
                data = reader.ReadToEnd();
            }
            var Customers = JsonConvert.DeserializeObject<Models.APIData>(data);
            Customers.customers.Add(customer);
           
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


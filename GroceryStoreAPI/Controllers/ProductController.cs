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
    public class ProductController : ControllerBase
    {
        static List<Models.Products> products = new List<Models.Products>    {
                new Models.Products
                {
                   // ProductID ="0004",
                   // Name ="OnePlus7Pro",
                   // Brand="OnePlus",
                   //// Expiry= "NA",
                   // Available =true,
                   // Description ="Its a mobile with 256 GB memories",
                   // Price =699

                },
                 new Models.Products
                {
                    // ProductID="0003",
                    //Name ="Iphone 11",
                    //Brand="Apple",                   
                    //Available =true,
                    //Description ="Its a mobile with 56 MB Camera",
                    //Price =1200
                }
            };

        public IEnumerable<Models.Products> GetAllCustmerList()
        {
            return products;
        }              

        [HttpGet("{ProductID}", Name = "GetProduct")]
        public Models.Products GetCustmer(int ProductID)
        {
            var selectedproducts = products.SingleOrDefault(x => x.id == ProductID);                        
            return selectedproducts;
        }

        [HttpPost]
        public Models.Products post([FromBody] Models.Products product)
        {

            string data;
            using (StreamReader reader = new StreamReader(new FileStream(Path.GetFileName("../database.json"), FileMode.Open)))
            {
                data = reader.ReadToEnd();
            }
            var APIData = JsonConvert.DeserializeObject<Models.APIData>(data);
            APIData.products.Add(product);
            products.Add(product);
            return product;
        }
    }


    
}

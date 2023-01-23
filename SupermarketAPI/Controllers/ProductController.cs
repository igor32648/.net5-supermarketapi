using Microsoft.AspNetCore.Mvc;
using SupermarketAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupermarketAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private static List<Product> products = new List<Product>();
        private static int id = 0;

        [HttpPost]
        public IActionResult AddProduct([FromBody]Product product)
        {
            product.Id = id++;
            products.Add(product);
            Console.WriteLine(product.Name);
            return CreatedAtAction(
                nameof(GetProductById), new { Id = product.Id }, product);
        }

        [HttpGet]
        public IActionResult GetProducts() 
        {
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            Product product = products.FirstOrDefault(product => product.Id == id);
            if(product != null)
            {
                return Ok(product);
            }
            return NotFound();
        }
    }
}

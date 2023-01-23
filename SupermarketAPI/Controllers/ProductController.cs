using Microsoft.AspNetCore.Mvc;
using SupermarketAPI.Data;
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
        private ProductContext _context;

        public ProductController(ProductContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AddProduct([FromBody]Product product)
        {
            
            _context.Products.Add(product);
            _context.SaveChanges();
            Console.WriteLine(product.Name);
            return CreatedAtAction(
                nameof(GetProductById), new { Id = product.Id }, product);
        }

        [HttpGet]
        public IEnumerable<Product> GetProducts() 
        {
            return _context.Products;
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            Product product = _context.Products.FirstOrDefault(product => product.Id == id);
            if(product != null)
            {
                return Ok(product);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, 
            [FromBody] Product updatedProduct)
        {
            Product product = _context.Products.FirstOrDefault(product => product.Id == id);
            if(product == null)
            {
                return NotFound();
            }
            product.Name = updatedProduct.Name;
            product.Brand = updatedProduct.Brand;
            product.Category = updatedProduct.Category;
            product.Price = updatedProduct.Price;
            product.Weight = updatedProduct.Weight;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            Product product = _context.Products.FirstOrDefault(product => product.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            _context.Remove(product);
            _context.SaveChanges();
            return NoContent();
        }
    }
}

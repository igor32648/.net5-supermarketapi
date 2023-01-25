using Microsoft.AspNetCore.Mvc;
using SupermarketAPI.Data;
using SupermarketAPI.Data.Dtos;
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
        public IActionResult AddProduct([FromBody]CreateProductDto productDto)
        {
            Product product = new Product
            {
                Name = productDto.Name,
                Brand = productDto.Brand,
                Category = productDto.Category,
                Price = productDto.Price,
                Weight = productDto.Weight
            };
            
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
                ReadProductDto readProduct = new ReadProductDto
                {
                    Id = product.Id,
                    Name = product.Name,
                    Brand = product.Brand,
                    Category = product.Category,
                    Price = product.Price,
                    Weight = product.Weight
                };

                return Ok(readProduct);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, 
            [FromBody] UpdateProductDto updatedProduct)
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

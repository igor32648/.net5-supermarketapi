using AutoMapper;
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
        private AppDbContext _context;
        private IMapper _mapper;

        public ProductController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AddProduct([FromBody]CreateProductDto productDto)
        {
            Product product = _mapper.Map<Product>(productDto);
            
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
                ReadProductDto readProduct = _mapper.Map<ReadProductDto>(product);

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
            _mapper.Map(updatedProduct, product);
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

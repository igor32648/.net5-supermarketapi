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
    public class CategoryController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public CategoryController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AddCategory([FromBody] CreateCategoryDto categoryDto)
        {
            Category category = _mapper.Map<Category>(categoryDto);

            _context.Categories.Add(category);
            _context.SaveChanges();
            Console.WriteLine(category.Name);
            return CreatedAtAction(
                nameof(GetCategoryById), new { Id = category.Id }, category);
        }

        [HttpGet]
        public IEnumerable<Category> GetCategories()
        {
            return _context.Categories;
        }

        [HttpGet("{id}")]
        public IActionResult GetCategoryById(int id)
        {
            Category category = _context.Categories.FirstOrDefault(category => category.Id == id);
            if (category != null)
            {
                ReadCategoryDto readCategory = _mapper.Map<ReadCategoryDto>(category);

                return Ok(readCategory);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCategory(int id,
            [FromBody] UpdateCategoryDto updatedCategory)
        {
            Category category = _context.Categories.FirstOrDefault(category => category.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            _mapper.Map(updatedCategory, category);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            Category category = _context.Categories.FirstOrDefault(category => category.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            _context.Remove(category);
            _context.SaveChanges();
            return NoContent();
        }
    }
}

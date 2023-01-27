using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SupermarketAPI.Data;
using SupermarketAPI.Data.Dtos.BrandDtos;
using SupermarketAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupermarketAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BrandController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public BrandController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AddBrand([FromBody] CreateBrandDto brandDto)
        {
            Brand brand = _mapper.Map<Brand>(brandDto);

            _context.Brands.Add(brand);
            _context.SaveChanges();
            Console.WriteLine(brand.Name);
            return CreatedAtAction(
                nameof(GetBrandById), new { Id = brand.Id }, brand);
        }

        [HttpGet]
        public IEnumerable<Brand> GetBrands()
        {
            return _context.Brands;
        }

        [HttpGet("{id}")]
        public IActionResult GetBrandById(int id)
        {
            Brand brand = _context.Brands.FirstOrDefault(brand => brand.Id == id);
            if (brand != null)
            {
                ReadBrandDto readBrand = _mapper.Map<ReadBrandDto>(brand);

                return Ok(readBrand);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBrand(int id,
            [FromBody] UpdateBrandDto updatedBrand)
        {
            Brand brand = _context.Brands.FirstOrDefault(brand => brand.Id == id);
            if (brand == null)
            {
                return NotFound();
            }
            _mapper.Map(updatedBrand, brand);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBrand(int id)
        {
            Brand brand = _context.Brands.FirstOrDefault(brand => brand.Id == id);
            if (brand == null)
            {
                return NotFound();
            }
            _context.Remove(brand);
            _context.SaveChanges();
            return NoContent();
        }
    }
}


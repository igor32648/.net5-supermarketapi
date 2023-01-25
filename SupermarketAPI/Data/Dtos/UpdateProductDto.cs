using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SupermarketAPI.Data.Dtos
{
    public class UpdateProductDto
    {
        [Required(ErrorMessage = "product name is required")]
        [StringLength(30, ErrorMessage = "must be less than 30 characters")]
        public string Name { get; set; }
        public string Brand { get; set; }
        [StringLength(30, ErrorMessage = "must be less than 30 characters")]
        public string Category { get; set; }
        [Required(ErrorMessage = "price is required")]
        public double Price { get; set; }
        public double Weight { get; set; }
    }
}


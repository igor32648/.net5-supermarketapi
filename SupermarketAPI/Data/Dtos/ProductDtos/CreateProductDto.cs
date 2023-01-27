using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SupermarketAPI.Data.Dtos
{
    public class CreateProductDto
    {
        [Required(ErrorMessage = "product name is required")]
        [StringLength(30, ErrorMessage = "must be less than 30 characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "price is required")]
        public double Price { get; set; }
        public double Weight { get; set; }
        [Required]
        public bool Perishable { get; set; }
    }
}

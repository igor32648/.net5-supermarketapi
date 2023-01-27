using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SupermarketAPI.Data.Dtos
{
    public class UpdateCategoryDto
    {
        [Required(ErrorMessage = "category name is required")]
        [StringLength(30, ErrorMessage = "must be less than 30 characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Storage name is required")]
        [StringLength(30, ErrorMessage = "must be less than 30 characters")]
        public string StoragePlace { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SupermarketAPI.Models
{
    public class Brand
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "brand name is required")]
        [StringLength(30, ErrorMessage = "must be less than 30 characters")]
        public string Name { get; set; }
        [Required]
        public bool HighCost { get; set; }
        [StringLength(30, ErrorMessage = "must be less than 30 characters")]
        public string  Purveyor { get; set; }
        [StringLength(30, ErrorMessage = "must be less than 30 characters")]
        public string PurveyorPhone { get; set; }
    }
}

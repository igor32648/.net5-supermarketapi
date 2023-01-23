using Microsoft.EntityFrameworkCore;
using SupermarketAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupermarketAPI.Data
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> opt): base (opt)
        {

        }

        public DbSet<Product> Products { get; set; }
    }
}

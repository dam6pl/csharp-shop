using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopDN.Data.Models.CMS;
using ShopDN.Data.Models.Shop;

namespace ShopDN.Data.Models
{
    public class ShopDNContext : DbContext
    {
        public ShopDNContext (DbContextOptions<ShopDNContext> options)
            : base(options)
        {
        }

        public DbSet<News> News { get; set; }

        public DbSet<Product> Product { get; set; }

        public DbSet<Category> Category { get; set; }

        public DbSet<Option> Option { get; set; }
    }
}

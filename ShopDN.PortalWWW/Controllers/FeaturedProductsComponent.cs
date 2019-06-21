using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopDN.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopDN.PortalWWW.Controllers
{
    public class FeaturedProductsComponent : ViewComponent
    {
        private readonly ShopDNContext _context;

        public FeaturedProductsComponent(ShopDNContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("FeaturedProductsComponent", await _context.Product.Where(prod => prod.IsFeatured == true).Take(3).ToListAsync());
        }
    }
}

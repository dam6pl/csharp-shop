using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopDN.Data.Models;
using ShopDN.Data.Models.Shop;

namespace ShopDN.PortalWWW.Controllers
{
    public class ShopController : Controller
    {
        private readonly ShopDNContext _context;

        public ShopController(ShopDNContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int? categoryId)
        {
            if(categoryId != null && !CategoryExists(categoryId))
            {
                NotFound();
            }

            List<Product> products;

            if (categoryId != null)
            {
                var category = _context.Category.Where(cat => cat.Id == categoryId).First();

                ViewBag.Categories = (
                    from cat in _context.Category
                    where cat.IdParentCategory == category.Id || 
                    (cat.IdParentCategory != null && cat.IdParentCategory == category.IdParentCategory)
                    select cat
                ).ToList();

                var categories = (
                    from cat in _context.Category
                    where cat.Id == categoryId || cat.IdParentCategory == categoryId
                    select cat.Id
                ).ToList();

                products = await _context.Product.Where(cat => categories.Contains(cat.IdCategory)).ToListAsync();
            }
            else
            {
                ViewBag.Categories = (
                    from cat in _context.Category
                    where cat.IdParentCategory == categoryId
                    select cat
                ).ToList();

                products = await _context.Product.ToListAsync();
            }

            return View(products);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .Include(prod => prod.Category)
                .FirstOrDefaultAsync(prod => prod.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        private bool CategoryExists(int? id)
        {
            return _context.Category.Any(cat => cat.Id == id);
        }
    }
}
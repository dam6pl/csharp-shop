using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShopDN.Data.Models;
using ShopDN.Data.Models.Shop;

namespace ShopDN.Intranet.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ShopDNContext _context;

        public ProductsController(ShopDNContext context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            return View(await _context.Product.Include(prod => prod.Category).ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            product.Content = Regex.Replace(product.Content, "<.*?>", String.Empty);

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            var categories = new List<Category>();

            foreach (Category category in _context.Category.Where(cat => cat.ParentCategory == null))
            {
                categories.Add(category);
                categories.AddRange( (
                         from cat in _context.Category
                         where cat.IdParentCategory == category.Id
                         select new Category
                         {
                             Id = cat.Id,
                             Title = " » " + cat.Title
                         }
                     ).ToList<Category>() );
            }

            ViewData["IdCategory"] = new SelectList(categories, "Id", "Title");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Author,Content,Price,PriceEBook,PriceAudiobook,IdCategory,ImageURL,Rating,IsFeatured")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var categories = new List<Category>();

            foreach (Category category in _context.Category.Where(cat => cat.ParentCategory == null))
            {
                categories.Add(category);
                categories.AddRange((
                         from cat in _context.Category
                         where cat.IdParentCategory == category.Id
                         select new Category
                         {
                             Id = cat.Id,
                             Title = " » " + cat.Title
                         }
                     ).ToList<Category>());
            }

            ViewData["IdCategory"] = new SelectList(categories, "Id", "Title");

            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Author,Content,Price,PriceEBook,PriceAudiobook,IdCategory,ImageURL,Rating,IsFeatured")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            product.Content = Regex.Replace(product.Content, "<.*?>", String.Empty);

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Product.FindAsync(id);
            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.Id == id);
        }
    }
}

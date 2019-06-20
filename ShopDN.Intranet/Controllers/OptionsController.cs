using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShopDN.Data.Models;
using ShopDN.Data.Models.CMS;
using ShopDN.Data.Models.Shop;

namespace ShopDN.Intranet.Controllers
{
    public class OptionsController : Controller
    {
        private readonly ShopDNContext _context;

        public OptionsController(ShopDNContext context)
        {
            _context = context;
        }

        // GET: Options
        public async Task<IActionResult> Index()
        {
            return View(await _context.Option.ToListAsync());
        }

        // GET: Options/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var option = await _context.Option
                .FirstOrDefaultAsync(o => o.Id == id);
            if (option == null)
            {
                return NotFound();
            }

            return View(option);
        }

        // GET: Options/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Options/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Value")] Option option)
        {
            option.Name = option.Name.ToLower().Replace(" ", "_");
            if (ModelState.IsValid)
            {
                _context.Add(option);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(option);
        }

        // GET: Options/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var option = await _context.Option.FindAsync(id);
            if (option == null)
            {
                return NotFound();
            }
            
            return View(option);
        }

        // POST: Options/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Value")] Option option)
        {
            if (id != option.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(option);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OptionExists(option.Id))
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
            return View(option);
        }

        // GET: Options/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var option = await _context.Option
                .FirstOrDefaultAsync(m => m.Id == id);
            if (option == null)
            {
                return NotFound();
            }

            return View(option);
        }

        // POST: Options/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var option = await _context.Option.FindAsync(id);
            _context.Option.Remove(option);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OptionExists(int id)
        {
            return _context.Option.Any(e => e.Id == id);
        }
    }
}

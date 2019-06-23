using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firma.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Firma.PortalWWW.Controllers
{
    public class SklepController : Controller
    {
        private readonly FirmaContext _context;

        public SklepController(FirmaContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int? id)
        {
            if (id == null)
            {
                var pierwszy = await _context.Rodzaj.FirstAsync();
                id = pierwszy.IdRodzaju;
            }

            return View(await _context.Towar.Where(towar => towar.IdRodzaju == id).ToListAsync());
        }

        public async Task<IActionResult> Szczegoly(int id)
        {
            ViewBag.Rodzaje = await _context.Rodzaj.ToListAsync();

            return View(await _context.Towar.FindAsync(id));
        }

        public async Task<IActionResult> Promocje()
        {
            return View(await _context.Towar.Where(towar => towar.Promocja == true).ToListAsync());
        }
    }
}
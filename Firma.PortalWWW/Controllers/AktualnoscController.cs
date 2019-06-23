using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Firma.PortalWWW.Models;
using Firma.Data;

namespace Firma.PortalWWW.Controllers
{
    public class AktualnoscController : Controller
    {
        private readonly FirmaContext _context;

        public AktualnoscController(FirmaContext context)
        {
            _context = context;
        }

        public IActionResult Index(int? id)
        {
            ViewBag.ModelStrony =
                (
                    from strona in _context.Strona
                    orderby strona.Pozycja
                    select strona
                ).ToList();

            ViewBag.ModelAktualnosci =
                (
                    from aktualnosc in _context.Aktualnosc
                    select aktualnosc
                ).Take(3).ToArray();

            if (id == null)
                id = _context.Aktualnosc.First().IdAktualnosc;

            return View(_context.Aktualnosc.Find(id));
        }
    }
}

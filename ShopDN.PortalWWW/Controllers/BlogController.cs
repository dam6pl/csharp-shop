using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopDN.Data.Models;
using ShopDN.Data.Models.CMS;

namespace ShopDN.PortalWWW.Controllers
{
    public class BlogController : Controller
    {
        private readonly ShopDNContext _context;

        public BlogController(ShopDNContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var items = (
                     from news in _context.News
                     where news.IsDraft == false
                     select new News
                     {
                         Id = news.Id,
                         Author = news.Author,
                         ImageURL = news.ImageURL,
                         Title = news.Title,
                         PublishDate = news.PublishDate,
                         Content = Regex
                             .Replace(
                                 Regex.Replace(news.Content, "&.*?;", String.Empty),
                                 "<.*?>",
                                 String.Empty
                             )
                             .Substring(0, 150) + "..."
                     }
                 ).OrderByDescending(n => n.Id).Take(3).ToListAsync();

            return View(await items);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = await _context.News
                .FirstOrDefaultAsync(m => m.Id == id);
            if (news == null)
            {
                return NotFound();
            }

            return View(news);
        }
    }
}
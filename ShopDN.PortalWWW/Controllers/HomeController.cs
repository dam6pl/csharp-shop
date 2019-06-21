using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopDN.Data.Models;
using ShopDN.Data.Models.CMS;
using ShopDN.PortalWWW.Models;

namespace ShopDN.PortalWWW.Controllers
{
    public class HomeController : Controller
    {
        private readonly ShopDNContext _context;

        public HomeController(ShopDNContext context)
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

        public IActionResult Contact()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

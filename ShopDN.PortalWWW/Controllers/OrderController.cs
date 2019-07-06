using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopDN.Data.Models;
using ShopDN.Data.Models.Shop;
using ShopDN.PortalWWW.Models.BusinessLogic;

namespace ShopDN.PortalWWW.Controllers
{
    public class OrderController : Controller
    {
        private readonly ShopDNContext _context;

        public OrderController(ShopDNContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Login,FirstName,LastName,Address")] Order order)
        {
            if (ModelState.IsValid)
            {
                order.CreatedAt = DateTime.Now;
                await _context.AddAsync(order);

                CartB cartB = new CartB(_context, this.HttpContext);
                var elements = await cartB.GetCartElements();

                foreach (var element in elements)
                {
                    var orderElement = new OrderElement()
                    {
                        ProductId = element.ProductId,
                        OrderId = order.Id,
                        Price = element.Product.Price,
                        Count = element.Count
                    };
                    await _context.OrderElement.AddAsync(orderElement);
                }

                order.Sum = await cartB.GetCartSum();
                cartB.ClearCart();
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", new { id = order.Id });
            }

            return View(order);
        }

        public async Task<IActionResult> Details(int id)
        {
            var order = await _context.Order.Where(o => o.Id == id)
                .Include(o => o.OrderElements).ThenInclude(e => e.Product)
                .FirstOrDefaultAsync();

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }
    }
}
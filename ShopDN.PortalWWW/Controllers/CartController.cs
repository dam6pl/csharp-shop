using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopDN.Data.Models;
using ShopDN.PortalWWW.Models.BusinessLogic;
using ShopDN.PortalWWW.Models.Shop;

namespace ShopDN.PortalWWW.Controllers
{
    public class CartController : Controller
    {
        private readonly ShopDNContext _context;

        public CartController(ShopDNContext context)
        {
            _context = context;
        }
    
        public async Task<IActionResult> Index()
        {
            CartB cartB = new CartB(_context, this.HttpContext);

            var cartDetails = new CartDetails()
            {
                CartElements = await cartB.GetCartElements(),
                CartSum = await cartB.GetCartSum()
            };

            return View(cartDetails);
        }

        public async Task<IActionResult> AddToCart(int id, int count = 1)
        {
            CartB cartB = new CartB(_context, this.HttpContext);
            cartB.AddToCart(await _context.Product.FindAsync(id), count);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> RemoveFromCart(int id)
        {
            CartB cartB = new CartB(_context, this.HttpContext);
            cartB.RemoveFromCart(await _context.Product.FindAsync(id));

            return RedirectToAction("Index");
        }
    }
}
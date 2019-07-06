using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopDN.Data.Models;
using ShopDN.PortalWWW.Models.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopDN.PortalWWW.Controllers
{
    public class CartIconComponent : ViewComponent
    {
        private readonly ShopDNContext _context;

        public CartIconComponent(ShopDNContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            CartB cartB = new CartB(_context, this.HttpContext);

            return View("CartIconComponent", await cartB.GetCartElementsCount());
        }
    }
}

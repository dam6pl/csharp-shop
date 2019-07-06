using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ShopDN.Data.Models;
using ShopDN.Data.Models.Shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopDN.PortalWWW.Models.BusinessLogic
{
    public class CartB
    {
        private readonly ShopDNContext _context;
        private string CartSessionId;

        public CartB(ShopDNContext context, HttpContext httpContext)
        {
            _context = context;
            CartSessionId = getCartSessionId(httpContext);
        }

        private string getCartSessionId(HttpContext httpContext)
        {
            if (httpContext.Session.GetString("CartSessionId") == null)
            {
                if (!String.IsNullOrWhiteSpace(httpContext.User.Identity.Name))
                {
                    httpContext.Session.SetString("CartSessionId", httpContext.User.Identity.Name);
                }
                else
                {
                    httpContext.Session.SetString("CartSessionId", Guid.NewGuid().ToString());
                }
            }

            return httpContext.Session.GetString("CartSessionId").ToString();
        }

        public void AddToCart(Product product, int count)
        {
            var cartElement = (
                    from element in _context.CartElement
                    where element.SessionId == this.CartSessionId
                    && element.ProductId == product.Id
                    select element
                ).FirstOrDefault();

            if (cartElement == null)
            {
                cartElement = new CartElement()
                {
                    SessionId = this.CartSessionId,
                    ProductId = product.Id,
                    Count = count,
                    CreatedAt = DateTime.Now
                };

                _context.CartElement.Add(cartElement);
            }
            else
            {
                cartElement.Count += count;
            }

            _context.SaveChanges();
        }

        public void RemoveFromCart(Product product)
        {
            var cartElement = (
                    from element in _context.CartElement
                    where element.SessionId == this.CartSessionId
                    && element.ProductId == product.Id
                    select element
                ).FirstOrDefault();

            _context.CartElement.Remove(cartElement);

            _context.SaveChanges();
        }

        public void ClearCart()
        {
            _context.RemoveRange(_context.CartElement.Where(e => e.SessionId == CartSessionId));

            _context.SaveChanges();
        }

        public async Task<List<CartElement>> GetCartElements()
        {
            return await _context.CartElement
                .Where(e => e.SessionId == this.CartSessionId)
                .Include(e => e.Product)
                .ToListAsync();
        }

        public async Task<int> GetCartElementsCount()
        {
            return (await this.GetCartElements()).Count();
        }

        public async Task<decimal> GetCartSum()
        {
            return await (
                    from element in _context.CartElement
                    where element.SessionId == this.CartSessionId
                    select element.Product.Price * element.Count
                ).SumAsync();
        }
    }
}

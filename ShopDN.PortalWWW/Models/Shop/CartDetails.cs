using ShopDN.Data.Models.Shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopDN.PortalWWW.Models.Shop
{
    public class CartDetails
    {
        public List<CartElement> CartElements { get; set; }

        public decimal CartSum { get; set; }
    }
}

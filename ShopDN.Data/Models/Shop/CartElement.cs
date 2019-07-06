using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ShopDN.Data.Models.Shop
{
    public class CartElement
    {
        [Key]
        public int Id { get; set; }

        public string SessionId { get; set; }

        public int ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public virtual Product Product { get; set; }

        public decimal Count { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}

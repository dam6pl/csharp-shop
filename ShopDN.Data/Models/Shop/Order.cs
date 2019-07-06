using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShopDN.Data.Models.Shop
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        [Required(ErrorMessage = "Wpisz login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Wpisz imie")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Wpisz nazwisko")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Wpisz adres")]
        public string Address { get; set; }

        public decimal Sum { get; set; }

        public virtual ICollection<OrderElement> OrderElements { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShopDN.Data.Models.Shop
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Wpisz nazwę produktu")]
        [MaxLength(50, ErrorMessage = "Tytuł moze miec maksymalnie 50 znakow")]
        [Display(Name = "Nazwa produktu")]
        public string Title { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        [Display(Name = "Opis produktu")]
        public string Content { get; set; }

        [Required(ErrorMessage = "Podaj cenę produktu")]
        [Display(Name = "Cena produktu")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Wybierz kategorię produktu")]
        [Display(Name = "Kategoria produktu")]
        public int IdCategory { get; set; }

        public virtual Category Category { get; set; }

        [Required(ErrorMessage = "Wpisz URL obrazka produktu")]
        [Display(Name = "URL obrazka produktu")]
        public string ImageURL { get; set; }
    }
}

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
        [MaxLength(50, ErrorMessage = "Tytuł może miec maksymalnie 50 znakow")]
        [Display(Name = "Nazwa produktu")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Podaj authora produktu")]
        [Display(Name = "Autor produktu")]
        public string Author { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        [Display(Name = "Opis produktu")]
        public string Content { get; set; }

        [Required(ErrorMessage = "Podaj cenę produktu (wersja papierowa)")]
        [Display(Name = "Cena produktu (wersja papierowa)")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Podaj cenę produktu (wersja ebook)")]
        [Display(Name = "Cena produktu (wersja ebook)")]
        public decimal? PriceEBook { get; set; }

        [Required(ErrorMessage = "Podaj cenę produktu (wersja audiobook)")]
        [Display(Name = "Cena produktu (wersja audiobook)")]
        public decimal? PriceAudiobook { get; set; }

        [Required(ErrorMessage = "Wybierz kategorię produktu")]
        [Display(Name = "Kategoria produktu")]
        public int IdCategory { get; set; }

        [ForeignKey(nameof(IdCategory))]
        public virtual Category Category { get; set; }
         
        [Required(ErrorMessage = "Podaj ocenę produktu")]
        [Display(Name = "Ocena produktu")]
        public int Rating { get; set; }

        [Required(ErrorMessage = "Wpisz URL obrazka produktu")]
        [Display(Name = "URL obrazka produktu")]
        public string ImageURL { get; set; }

        [Display(Name = "Produkt promowany")]
        public Boolean IsFeatured { get; set; }
    }
}

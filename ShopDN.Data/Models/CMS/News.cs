using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShopDN.Data.Models.CMS
{
    public class News
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Wpisz tytuł artykułu")]
        [MaxLength(50, ErrorMessage = "Tytuł moze miec maksymalnie 50 znakow")]
        [Display(Name = "Tytuł artykułu")]
        public string Title { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        [Display(Name = "Treść artykułu")]
        public string Content { get; set; }

        [Required(ErrorMessage = "Wpisz autora artykułu")]
        [MaxLength(50, ErrorMessage = "Autor moze miec maksymalnie 50 znakow")]
        [Display(Name = "Autor artykułu")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Wpisz URL obrazka")]
        [Display(Name = "URL obrazka artykułu")]
        public string ImageURL { get; set; }

        [Required(ErrorMessage = "Wpisz datę publikacji")]
        [Display(Name = "Data publikacji")]
        public DateTime PublishDate { get; set; }

        [Display(Name = "Wersja robocza")]
        public Boolean IsDraft { get; set; }
    }
}

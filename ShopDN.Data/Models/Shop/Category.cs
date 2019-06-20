using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShopDN.Data.Models.Shop
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Wpisz nazwę kategorii")]
        [MaxLength(50, ErrorMessage = "Tytuł moze miec maksymalnie 50 znakow")]
        [Display(Name = "Nazwa kategorii")]
        public string Title { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        [Display(Name = "Opis kategorii")]
        public string Content { get; set; }

        [Display(Name = "Kategoria nadrzędna")]
        public int? IdParentCategory { get; set; }

        [ForeignKey(nameof(IdParentCategory))]
        public virtual Category ParentCategory { get; set; }

        public virtual ICollection<Category> Categories { get; set; }

    }
}

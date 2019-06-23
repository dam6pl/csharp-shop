using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Firma.Data.Sklep
{
    public class Towar
    {
        [Key]
        public int IdTowaru { get; set; }

        [Required(ErrorMessage = "Podaj kod towaru")]
        public string Kod { get; set; }

        [Required(ErrorMessage = "Podaj nazwę towaru")]
        public string Nazwa { get; set; }

        [Required(ErrorMessage = "Podaj cenę towaru")]
        [Column(TypeName = "money")]
        public decimal Cena { get; set; }

        [Required(ErrorMessage = "Podaj URL zdjęcia towaru")]
        [Display(Name ="Wybierz zdjęcie")]
        public string ZdjecieUrl { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string Opis { get; set; }
    
        [Required(ErrorMessage = "Podaj rodzaj towaru")]
        [Display(Name = "Rodzaj towaru")]
        public int IdRodzaju { get; set; }

        [Display(Name = "Czy na promocja?")]
        public bool Promocja { get; set; }

        public virtual Rodzaj Rodzaj { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Firma.Intranet.Models.CMS
{
    public class Aktualnosc
    {
        [Key]
        public int IdAktualnosc { get; set; }

        [Required(ErrorMessage = "Wpisz tytul linku")]
        [MaxLength(20, ErrorMessage = "Tytul linku moze miec maksymalnie 20 znakow")]
        [Display(Name = "Tytul linku")]
        public string LinkTytul { get; set; }

        [Required(ErrorMessage = "Wpisz tytul aktualnosci")]
        [MaxLength(50, ErrorMessage = "Tytul aktualnosci moze miec maksymalnie 20 znakow")]
        [Display(Name = "Tytul strony")]
        public string Tytul { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        [Display(Name = "Tresc aktualnosci")]
        public string Tresc { get; set; }

        [Required(ErrorMessage = "Wpisz pozycje aktualnosci w menu")]
        [Display(Name = "Pozycja aktualnosci w menu")]
        public int Pozycja { get; set; }
    }
}

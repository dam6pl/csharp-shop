using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Firma.Intranet.Models.CMS
{
    public class Strona
    {
        [Key]
        public int IdStrony { get; set; }

        [Required(ErrorMessage = "Wpisz tytul linku")]
        [MaxLength(20, ErrorMessage = "Tytul linku moze miec maksymalnie 20 znakow")]
        [Display(Name = "Tytul linku")]
        public string LinkTytul { get; set; }

        [Required(ErrorMessage = "Wpisz tytul strony")]
        [MaxLength(50, ErrorMessage = "Tytul strony moze miec maksymalnie 50 znakow")]
        [Display(Name = "Tytul strony")]
        public string Tytul { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        [Display(Name = "Tresc strony")]
        public string Tresc { get; set; }

        [Required(ErrorMessage = "Wpisz pozycje strony w menu")]
        [Display(Name = "Pozycja strony w menu")]
        public int Pozycja { get; set; }
    }
}

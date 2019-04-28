using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Firma.Data.Sklep
{
    public class Rodzaj
    {
        [Key]
        public int IdRodzaju { get; set; }

        [Required(ErrorMessage = "Podaj nazwę rodzaju")]
        [MaxLength(30, ErrorMessage = "Nazwa rodzaju moze miec maksymalnie 30 znakow")]
        public string Nazwa { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string Opis { get; set; }

        public virtual ICollection<Towar> Towar { get; set; }
    }
}

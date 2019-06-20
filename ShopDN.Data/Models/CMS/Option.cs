using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShopDN.Data.Models.CMS
{
    public class Option
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Wpisz nazwę opcji")]
        [MaxLength(50, ErrorMessage = "Nazwa moze miec maksymalnie 50 znakow")]
        [Display(Name = "Nazwa opcji")]
        public string Name { get; set; }

        [Display(Name = "Wartość opcji")]
        public string Value { get; set; }
    }
}

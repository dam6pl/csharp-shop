using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Data
{
    public class FirmaContext : DbContext
    {
        public FirmaContext(DbContextOptions<FirmaContext> options)
            : base(options)
        {
        }

        public DbSet<CMS.Strona> Strona { get; set; }

        public DbSet<CMS.Aktualnosc> Aktualnosc { get; set; }

        public DbSet<Sklep.Rodzaj> Rodzaj { get; set; }

        public DbSet<Sklep.Towar> Towar { get; set; }
    }
}

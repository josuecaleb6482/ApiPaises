using Microsoft.EntityFrameworkCore;

namespace Paises.Models
{
    public class CountriesContext:DbContext
    {
        public CountriesContext(DbContextOptions<CountriesContext> options)
            : base(options)
            {
            }

            public DbSet<Country> Countries { get; set; }
    }
    
}
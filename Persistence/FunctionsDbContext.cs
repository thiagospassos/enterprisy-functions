using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class FunctionsDbContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }

        public FunctionsDbContext(DbContextOptions<FunctionsDbContext> options) : base(options)
        {

        }
    }
}

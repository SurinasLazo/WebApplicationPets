using Microsoft.EntityFrameworkCore;
using WebApplicationPets.Models;

namespace WebApplicationPets.Context
{
    public class EFContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Pet> Pets { get; set; }

        public EFContext(DbContextOptions<EFContext> options) : base(options) { }
    }
}

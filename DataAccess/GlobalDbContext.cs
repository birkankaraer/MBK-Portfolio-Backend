using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class GlobalDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-F160INQ;Database=GlobalDb;Trusted_Connection=true");
        }

        public DbSet<Hireus> Hireuses { get; set; }
    }
}

using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace DataAccess
{
    public class GlobalDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public GlobalDbContext(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration), "Configuration cannot be null.");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException("Connection string cannot be null or empty. Please check your configuration.");
            }

            optionsBuilder.UseSqlServer(connectionString);
        }

        public virtual DbSet<Contact> Contacts { get; set; }
    }
}

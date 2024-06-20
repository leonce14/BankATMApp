using Microsoft.EntityFrameworkCore;
using BankATMApp.Models;

namespace BankATMApp
{
    public class BankContext: DbContext
    {
        public DbSet<Account> Accounts { get; set; } // Added 'public' access modifier

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=BankATMDb;TrustServerCertificate=true;Trusted_Connection=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.HasDefaultSchema("BankATMSchema");
           modelBuilder.Entity<Account>().ToTable("Accounts"); 
        }
    }
}

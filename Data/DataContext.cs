using Helper.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Helper.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}

        public DbSet<User> Users { get; set; }
        public DbSet<Jednostka> Jednostki { get; set; }

        protected override void OnModelCreating(ModelBuilder  modelBuilder)
        {                               
            modelBuilder.Entity<Jednostka>()
                .HasMany(j => j.Children)
                .WithOne(j => j.Parent)            
                .HasForeignKey(j => j.ParentId);
        }         
    }
}
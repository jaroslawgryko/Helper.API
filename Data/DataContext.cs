using Helper.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Helper.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}

        public DbSet<User> Users { get; set; }
        public DbSet<Jednostka> Jednostki { get; set; }
    }
}
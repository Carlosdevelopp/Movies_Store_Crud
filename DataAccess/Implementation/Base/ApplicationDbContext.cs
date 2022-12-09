using DataAccess.Models.Tables;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Implementation.Base
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() { }

        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public virtual DbSet<Movies> Movies { get; set; }
        public virtual DbSet<Genres> Genres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) { }
    }
}

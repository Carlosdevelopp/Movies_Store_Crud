using DataAccess.Models.Tables;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Implementation.Base
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() { } 

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Movies> Movies { get; set; }
        public virtual DbSet<Genres> Genres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Movies>().ToTable("Movies");
            modelBuilder.Entity<Movies>(entity =>
            {
                entity.HasOne(d => d.Genres)
                      .WithMany(p => p.Movies)
                      .HasForeignKey(d => d.GenreId);

                entity.HasOne(w => w.Awards)
                      .WithMany(w => w.Movies)
                      .HasForeignKey(w => w.AwardId);
            });
        }
    }
}

using Microsoft.EntityFrameworkCore;
using WepApi.Models;

namespace WepApi.Domain_Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
      : base(options)
        { }
        public DbSet<City> Cities { get; set; }
        public DbSet<PointOfInterest> pointOfInterests { get; set; }
        public DbSet<User> users { get; set; }
        //UserPermision
        public DbSet<Permision> permisions { get; set; }
        //public DbSet<UserPermision> userPermisions { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserPermision>()
               .HasKey(s => new { s.UserId, s.PermisionId });

        }

    }
}

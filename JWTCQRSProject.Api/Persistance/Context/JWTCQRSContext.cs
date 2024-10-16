using JWTCQRSProject.Api.Core.Domain;
using JWTCQRSProject.Api.Persistance.Configrations;
using Microsoft.EntityFrameworkCore;

namespace JWTCQRSProject.Api.Persistance.Context
{
    public class JWTCQRSContext : DbContext
    {
        public JWTCQRSContext(DbContextOptions<JWTCQRSContext> opt) : base (opt)
        {
            
        }
        public DbSet<Product> Products { get { return this.Set<Product>(); } }
        public DbSet<Category> Categories { get { return this.Set<Category>(); } }
        public DbSet<AppUser> AppUsers { get { return this.Set<AppUser>(); } }
        public DbSet<AppRole> AppRoles { get { return this.Set<AppRole>(); } }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfigration());
            modelBuilder.ApplyConfiguration(new AppUserConfigration());

            base.OnModelCreating(modelBuilder);
        }
    }
}

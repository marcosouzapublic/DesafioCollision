using DesafioCollision.Domain.Models;
using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;

namespace DesafioCollision.Infra.EFContext
{
    public class EFContext : DbContext
    {
        public EFContext(DbContextOptions<EFContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryProduct> CategoriesProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Notification>();

            modelBuilder
                .Entity<Category>()
                .HasKey(c => c.Id);

            modelBuilder
                .Entity<Product>()
                .HasKey(p => p.Id);

            modelBuilder
             .Entity<CategoryProduct>()
             .HasOne(c => c.Category)
             .WithMany(c => c.Products)
             .HasForeignKey(cl => cl.CategoryId);

            modelBuilder
                .Entity<CategoryProduct>()
                .HasOne(p => p.Product)
                .WithMany(l => l.Categories)
                .HasForeignKey(cl => cl.ProductId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
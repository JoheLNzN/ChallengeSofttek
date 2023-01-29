using JncSofttek.Microservice.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace JncSofttek.Microservice.DataAccess
{
    public class JncSofttekContext : DbContext
    {
        protected JncSofttekContext(DbContextOptions options) : base(options)
        {

        }

        public JncSofttekContext(DbContextOptions<JncSofttekContext> options) : this((DbContextOptions)options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                        .HasIndex(u => u.EmailAddress)
                        .IsUnique();

            modelBuilder.Entity<Article>()
                        .HasIndex(a => a.Sku)
                        .IsUnique();

            modelBuilder.Entity<Order>()
                        .HasOne<User>()
                        .WithMany()
                        .HasForeignKey(o => o.UserId);

            modelBuilder.Entity<Order>()
                        .HasOne<Article>()
                        .WithMany()
                        .HasForeignKey(o => o.ArticleId);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}

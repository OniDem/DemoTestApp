using Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace DemoTestApi.Infrastructure
{
    public class ApplicationContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>(entity =>
            {
                entity.HasIndex(e => e.ShiftIDs).AreNullsDistinct();
                entity.HasIndex(e => e.Username).IsUnique();

            });

            modelBuilder.Entity<OrderEntity>(entity =>
            {
                entity.HasIndex(e => e.OrderId).IsUnique();

            });
        }
    }
}

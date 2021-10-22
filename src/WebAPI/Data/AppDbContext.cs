using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class AppDbContext : DbContext
    {
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDET> Details { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().ToTable("Orders");
            modelBuilder.Entity<OrderDET>().ToTable("Details");

            modelBuilder.Entity<OrderDET>()
                .HasOne<Order>(s => s.Order)
                .WithMany(g => g.Details)
                .HasForeignKey(b => b.OrderId);

            modelBuilder.Entity<Order>()
                .HasMany<OrderDET>(s => s.Details)
                .WithOne(g => g.Order)
                .HasForeignKey(b => b.OrderId);
        }
    }
}

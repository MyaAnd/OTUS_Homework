using EntityFW_ConsoleApp.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace EntityFW_ConsoleApp
{
    public class DBDataContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderInfo> OrderDetails { get; set; }

        public DBDataContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
               .HasMany(e => e.Orders)
               .WithOne(e => e.UserData)
               .HasForeignKey(e => e.UserID);


            modelBuilder.Entity<Order>()
                .HasOne(e => e.UserData)
                .WithMany(e => e.Orders)
                .HasForeignKey(e => e.UserID);




            modelBuilder.Entity<Order>()
                .HasOne(e => e.OrderInformation)
                .WithOne(e => e.OrderData)
                .HasForeignKey<OrderInfo>(e => e.OrderID);

            modelBuilder.Entity<OrderInfo>()
                .HasOne(e => e.OrderData)
                .WithOne(e => e.OrderInformation)
                .HasForeignKey<OrderInfo>(e => e.OrderID);



            modelBuilder.Entity<OrderInfo>()
                .HasOne(e => e.ProductData)
                .WithMany(e => e.OrderInfos)
                .HasForeignKey(e => e.ProductID);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.OrderInfos)
                .WithOne(e => e.ProductData)
                .HasForeignKey(e => e.OrderDetailID);


            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            optionsBuilder.UseNpgsql("Host=localhost;Username=postgres;Password=123;Database=TestDb");

            base.OnConfiguring(optionsBuilder);
        }
    }
}

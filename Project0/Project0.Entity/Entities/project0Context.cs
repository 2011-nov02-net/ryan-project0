using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Project0.Entity.Entities
{
    public partial class project0Context : DbContext
    {
        public project0Context()
        {
        }

        public project0Context(DbContextOptions<project0Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderProduct> OrderProducts { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<StoreInventory> StoreInventories { get; set; }
        public virtual DbSet<StoreLocation> StoreLocations { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Orders", "Project0");

                entity.Property(e => e.OrderTotal).HasColumnType("money");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Orders__StoreId__693CA210");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Orders__UserId__68487DD7");
            });

            modelBuilder.Entity<OrderProduct>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.ProductId })
                    .HasName("PK__OrderPro__08D097A38DAF97EF");

                entity.ToTable("OrderProduct", "Project0");

                entity.Property(e => e.ProductPricePaid).HasColumnType("money");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderProducts)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderProd__Order__6C190EBB");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderProducts)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderProd__Produ__6D0D32F4");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product", "Project0");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.Price).HasColumnType("money");
            });

            modelBuilder.Entity<StoreInventory>(entity =>
            {
                entity.HasKey(e => new { e.LocationId, e.ProductId })
                    .HasName("PK__StoreInv__2CBE68FB0C4F15FB");

                entity.ToTable("StoreInventory", "Project0");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.StoreInventories)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__StoreInve__Locat__6383C8BA");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.StoreInventories)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__StoreInve__Produ__6477ECF3");
            });

            modelBuilder.Entity<StoreLocation>(entity =>
            {
                entity.ToTable("StoreLocation", "Project0");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(300);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users", "Project0");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.UserType).HasDefaultValueSql("((1))");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

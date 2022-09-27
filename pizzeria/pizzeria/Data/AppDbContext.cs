using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using pizzeria.Models;

namespace pizzeria.Data
{
    public partial class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; } = null!;
        public virtual DbSet<AppUser> AppUsers { get; set; } = null!;
        public virtual DbSet<CartItem> CarItems { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<DeliveryCompany> DeliveryCompanies { get; set; } = null!;
        public virtual DbSet<DeliveryPrice> DeliveryPrices { get; set; } = null!;
        public virtual DbSet<DeliveryPriceRule> DeliveryPriceRules { get; set; } = null!;
        public virtual DbSet<Ingredient> Ingredients { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderDetail> OrderDetails { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Status> Statuses { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("name=DefaultConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppUser>(entity =>
            {
                entity.HasMany(d => d.IdAddresses)
                    .WithMany(p => p.IdAppUsers)
                    .UsingEntity<Dictionary<string, object>>(
                        "UsersAddress",
                        l => l.HasOne<Address>().WithMany().HasForeignKey("IdAddress").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_UsersAddresses_Addresses"),
                        r => r.HasOne<AppUser>().WithMany().HasForeignKey("IdAppUser").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_UsersAddresses_AppUsers"),
                        j =>
                        {
                            j.HasKey("IdAppUser", "IdAddress");

                            j.ToTable("UsersAddresses");

                            j.IndexerProperty<string>("IdAppUser").HasMaxLength(250).IsUnicode(false).HasColumnName("Id_AppUser");

                            j.IndexerProperty<int>("IdAddress").HasColumnName("Id_Address");
                        });
            });

            modelBuilder.Entity<CartItem>(entity =>
            {
                entity.HasOne(d => d.IdProductNavigation)
                    .WithMany(p => p.CarItems)
                    .HasForeignKey(d => d.IdProduct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CarItems_Products");
            });

            modelBuilder.Entity<DeliveryPrice>(entity =>
            {
                entity.HasOne(d => d.IdDeliveryPriceRulesNavigation)
                    .WithMany(p => p.DeliveryPrices)
                    .HasForeignKey(d => d.IdDeliveryPriceRules)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DeliveryPrice_DeliveryPriceRules");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasOne(d => d.IdAddressNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.IdAddress)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_Addresses");

                entity.HasOne(d => d.IdAppUserNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.IdAppUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_AppUsers");

                entity.HasOne(d => d.IdDeliveryCompanyNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.IdDeliveryCompany)
                    .HasConstraintName("FK_Orders_DeliveryCompanies");

                entity.HasOne(d => d.IdDeliveryPriceNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.IdDeliveryPrice)
                    .HasConstraintName("FK_Orders_DeliveryPrice");

                entity.HasOne(d => d.IdStatusNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.IdStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_Status");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasKey(e => new { e.IdProduct, e.IdOrder });

                entity.HasOne(d => d.IdOrderNavigation)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.IdOrder)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderDetails_Orders");

                entity.HasOne(d => d.IdProductNavigation)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.IdProduct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderDetails_Products");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasOne(d => d.IdCategoryNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.IdCategory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Products_Categories");

                entity.HasMany(d => d.IdIngredients)
                    .WithMany(p => p.IdProducts)
                    .UsingEntity<Dictionary<string, object>>(
                        "ProductsIngredient",
                        l => l.HasOne<Ingredient>().WithMany().HasForeignKey("IdIngredient").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_ProductsIngredients_Ingredients"),
                        r => r.HasOne<Product>().WithMany().HasForeignKey("IdProduct").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_ProductsIngredients_Products"),
                        j =>
                        {
                            j.HasKey("IdProduct", "IdIngredient");

                            j.ToTable("ProductsIngredients");

                            j.IndexerProperty<int>("IdProduct").HasColumnName("Id_Product");

                            j.IndexerProperty<int>("IdIngredient").HasColumnName("Id_Ingredient");
                        });
            });

            base.OnModelCreating(modelBuilder);
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

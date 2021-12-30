using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SampleShoppingCartAPI.Models
{
    public partial class ShoppingCartSampleContext : DbContext
    {
        public ShoppingCartSampleContext()
        {
        }

        public ShoppingCartSampleContext(DbContextOptions<ShoppingCartSampleContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CartInformation> CartInformations { get; set; }
        public virtual DbSet<CartProductDetail> CartProductDetails { get; set; }
        public virtual DbSet<ProductImage> ProductImages { get; set; }
        public virtual DbSet<ProductInformation> ProductInformations { get; set; }
        public virtual DbSet<UserInformation> UserInformations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=ShoppingCartSample;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CartInformation>(entity =>
            {
                entity.HasKey(e => e.CartId);

                entity.ToTable("CartInformation");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CartInformations)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CartInformation_UserInformation");
            });

            modelBuilder.Entity<CartProductDetail>(entity =>
            {
                entity.HasKey(e => e.CartProductDetailsId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CartProductDetails)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CartProductDetails_ProductInformation");
            });

            modelBuilder.Entity<ProductImage>(entity =>
            {
                entity.Property(e => e.ProductImageId).ValueGeneratedNever();

                entity.Property(e => e.ImageName).IsRequired();

                entity.Property(e => e.ImageUrl).IsRequired();

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductImages)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductImages_ProductInformation");
            });

            modelBuilder.Entity<ProductInformation>(entity =>
            {
                entity.HasKey(e => e.ProductId);

                entity.ToTable("ProductInformation");

                entity.Property(e => e.ProductId).ValueGeneratedNever();

                entity.Property(e => e.ImageName).HasMaxLength(200);

                entity.Property(e => e.ModelNumber).HasMaxLength(50);

                entity.Property(e => e.ProductTitle)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<UserInformation>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("UserInformation");

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.UserName).IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

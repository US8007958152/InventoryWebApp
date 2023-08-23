using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace InventoryWebApp.Models;

public partial class ProductDbContext : DbContext
{
    public ProductDbContext()
    {
    }

    public ProductDbContext(DbContextOptions<ProductDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-IEUGB4QP\\SQLEXPRESS;Database=ProductDB;Trusted_Connection=True;TrustServerCertificate=True; ");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductNo).HasName("PK__Product__B40D3A36FB754B89");

            entity.ToTable("Product");

            entity.Property(e => e.CostPrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ProductName).HasMaxLength(30);
            entity.Property(e => e.SalesPrice).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4CFA549128");

            entity.Property(e => e.Password).HasMaxLength(12);
            entity.Property(e => e.UserName).HasMaxLength(20);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

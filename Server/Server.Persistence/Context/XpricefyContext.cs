using Microsoft.EntityFrameworkCore;
using Server.Domain.Entities;

namespace Server.Persistence.Context;

public class XpricefyContext(DbContextOptions<XpricefyContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductHistory> ProductHistories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>()
            .HasKey(u => u.Id);
        
        modelBuilder.Entity<Product>()
            .HasKey(s => s.Id);

        modelBuilder.Entity<ProductHistory>()
            .HasKey(s => s.Id);
        modelBuilder.Entity<ProductHistory>()
            .Property(ph => ph.Action)
            .HasConversion<int>();
    }
}
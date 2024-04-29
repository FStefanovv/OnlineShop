namespace EFCoreVezba;

using Microsoft.EntityFrameworkCore;

using Model;
using Enums;
using Utils;
using ApiKeyAuth;

public class PostgresDbContext : DbContext {   
    public PostgresDbContext(DbContextOptions<PostgresDbContext> options) : base(options){}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BankAccount>()
            .Property(b => b.UserId)
            .IsRequired(false);

        modelBuilder.Entity<BankAccount>()
            .Property(b => b.CompanyId)
            .IsRequired(false);

        modelBuilder.Entity<Product>()
            .HasIndex(p => new { p.Name, p.CompanyId })
            .IsUnique();

        DataSeeding.Seed(modelBuilder);
    }

 

    public DbSet<User> Users {get; set;}
    public DbSet<BankAccount> BankAccounts {get; set;}
    public DbSet<Company> Companies {get; set;}
    public DbSet<Product> Products {get; set;}
    public DbSet<CompanyApiKey> ApiKeys {get; set;}
    public DbSet<Discount> Discounts {get; set;}
    public DbSet<Order> Orders {get; set;}

}
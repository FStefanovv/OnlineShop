namespace EFCoreVezba.Utils;

using Microsoft.EntityFrameworkCore;

using Model;
using Enums;


public static class DataSeeding {
    public static void Seed(ModelBuilder modelBuilder) {

        string company1Id = Guid.NewGuid().ToString();
        string company2Id = Guid.NewGuid().ToString();

        string bankAccount1Id = Guid.NewGuid().ToString();
        string bankAccount2Id = Guid.NewGuid().ToString();

        modelBuilder.Entity<Company>().HasData(
            new Company
            {
                Id = company1Id,
                Name = "Company 1",
                Email = "company1@example.com",
                BankAccountId = bankAccount1Id
            },
            new Company
            {
                Id = company2Id,
                Name = "Company 2",
                Email = "company2@example.com",
                BankAccountId = bankAccount2Id
            }
        );

        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = "1",
                FirstName = "Petar",
                LastName = "Petrovic",
                Email = "petrovic@gmail.com",
                DateOfBirth = new DateTime(1998, 5, 6, 0, 0, 0, DateTimeKind.Utc),
                RegisteredOn = DateTime.UtcNow,
                Password = PasswordHasher.HashPassword("password")
            },
            new User
            {
                Id = "2",
                FirstName = "Relja",
                LastName = "Ostojic",
                Email = "reljaprecisti@example.com",
                DateOfBirth = new DateTime(1990, 1, 15, 0, 0, 0, DateTimeKind.Utc),
                RegisteredOn = DateTime.UtcNow,
                Password = PasswordHasher.HashPassword("password")
            },
            new User
            {
                Id = "3",
                FirstName = "Coja",
                LastName = "Stankovic",
                Email = "stankela@example.com",
                DateOfBirth = new DateTime(1990, 1, 15, 0, 0, 0, DateTimeKind.Utc),
                RegisteredOn = DateTime.UtcNow,
                Password = PasswordHasher.HashPassword("password")
            }
        );

        modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = Guid.NewGuid().ToString(),
                CompanyId = company1Id,
                Name = "Product 1",
                Quantity = 10,
                UnitPrice = 20,
                Description = "Description for Product 1"
            },
            new Product
            {
                Id = Guid.NewGuid().ToString(),
                CompanyId = company1Id,
                Name = "Product 2",
                Quantity = 15,
                UnitPrice = 30,
                Description = "Description for Product 2"
            },
            new Product
            {
                Id = Guid.NewGuid().ToString(),
                CompanyId = company1Id,
                Name = "Product 3",
                Quantity = 20,
                UnitPrice = 25,
                Description = "Description for Product 3"
            },
            new Product
            {
                Id = Guid.NewGuid().ToString(),
                CompanyId = company2Id,
                Name = "Product 4",
                Quantity = 8,
                UnitPrice = 25,
                Description = "Description for Product 4"
            },
            new Product
            {
                Id = Guid.NewGuid().ToString(),
                CompanyId = company2Id,
                Name = "Product 5",
                Quantity = 12,
                UnitPrice = 35,
                Description = "Description for Product 5"
            },
            new Product
            {
                Id = Guid.NewGuid().ToString(),
                CompanyId = company2Id,
                Name = "Product 6",
                Quantity = 18,
                UnitPrice = 40,
                Description = "Description for Product 6"
            }
        );

        modelBuilder.Entity<BankAccount>().HasData(
            new BankAccount
            {
                Id = bankAccount1Id,
                Currency = Currency.EUR,
                CompanyId = company1Id,
                UserId = null,
                Balance = 40000,
                Active = true,
                Type = AccountType.COMPANY
            },
            new BankAccount
            {
                Id = bankAccount2Id,
                Currency = Currency.EUR,
                CompanyId = company2Id,
                UserId = null,
                Balance = 100000,
                Active = true,
                Type = AccountType.COMPANY
            }
        );

        modelBuilder.Entity<BankAccount>().HasData(
            new BankAccount
            {
                Id = Guid.NewGuid().ToString(),
                Currency = Currency.RSD,
                CompanyId = null,
                UserId = "1",
                Balance = 15000,
                Active = true,
                Type = AccountType.PERSONAL
            },
            new BankAccount
            {
                Id = Guid.NewGuid().ToString(),
                Currency = Currency.EUR,
                CompanyId = null,
                UserId = "2",
                Balance = 200,
                Active = true,
                Type = AccountType.PERSONAL
            },
            new BankAccount
            {
                Id = Guid.NewGuid().ToString(),
                Currency = Currency.EUR,
                CompanyId = null,
                UserId = "3",
                Balance = 500,
                Active = true,
                Type = AccountType.PERSONAL
            }
        );
    }
}
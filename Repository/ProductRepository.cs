namespace EFCoreVezba.Repository;

using EFCoreVezba.Model;
using Microsoft.EntityFrameworkCore;


public class ProductRepository : IProductRepository {
    private readonly PostgresDbContext _context;

    public ProductRepository(PostgresDbContext context) {
        _context = context;
    }

    public void Add(Product product) {
        _context.Products.Add(product);
        _context.SaveChanges();
    }

    public bool ProductExists(string productName, string companyId) {
        bool exists = _context.Products.Any(p => p.Name == productName && p.CompanyId == companyId);
    
        return exists;
    }

    public Product GetById(string productId) {
        return _context.Products.FirstOrDefault(x => x.Id == productId);
    }

    public void AddDiscount(Discount discount)
    {
        try {
            _context.Discounts.Add(discount);
            _context.SaveChanges();
        } catch (DbUpdateException ex){
            throw new Exception(ex.Message);
        }
    }

    public void SaveChanges() {
        _context.SaveChanges();
    }


}
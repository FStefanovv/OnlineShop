namespace EFCoreVezba.Repository;

using EFCoreVezba.Model;


public interface IProductRepository {
    void Add(Product product);
    bool ProductExists(string productName, string companyId);
    Product GetById(string productId);
    void SaveChanges();
    void AddDiscount(Discount discount);
}
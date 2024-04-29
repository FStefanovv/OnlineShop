namespace EFCoreVezba.Services;

using EFCoreVezba.Dto;
using EFCoreVezba.Repository;
using EFCoreVezba.Model;
using EFCoreVezba.Exceptions;

public class ProductService : IProductService {
    private readonly IProductRepository _repository;
    public ProductService(IProductRepository repository) {
        _repository = repository;
    }
    
    public void Add(AddProductDTO addProductDTO, string companyId) {

        if(_repository.ProductExists(addProductDTO.Name, companyId) == null)
            throw new Exception("Product already exists");

        if(addProductDTO.Quantity < 0) 
            throw new Exception("Quantity has to be non-negative number");
        
        Product product = new Product 
            {
                Name = addProductDTO.Name,
                CompanyId = companyId,
                UnitPrice = addProductDTO.UnitPrice,
                Quantity = addProductDTO.Quantity,
                Description = addProductDTO.Description
            };
        
        _repository.Add(product);
    }

    public void IncreaseQuantity(IncreaseQuantityDTO dto, string companyId)
    {
        Product product = _repository.GetById(dto.ProductId) ?? throw new Exception("Non-existent product");

        if (product.CompanyId != companyId)
            throw new ForbiddenActionException("Not authorized to update products not owned by the company");
        
        if (dto.newQuantity <= 0)
            throw new Exception("Quantity must be a positive number");

        product.Quantity += dto.newQuantity;

        _repository.SaveChanges();
    }

    public void AddDiscount(string companyId, DiscountDTO dto) {
        Product product = _repository.GetById(dto.ProductId);
        if(companyId != product.CompanyId)
            throw new ForbiddenActionException("Discount can only be added by a the company owning the product");
        if(dto.DiscountAmount<=0 || dto.DiscountAmount>=100)
            throw new Exception("Discount must be between 0 and 100%");
        
        try {
            _repository.AddDiscount(
                new Discount 
                {ProductId = dto.ProductId, ValidUntil = dto.ValidUntil.ToUniversalTime(), DiscountAmount = dto.DiscountAmount}
            );
        } catch (Exception ex) {
            throw new Exception(ex.Message);
        }
    }

}
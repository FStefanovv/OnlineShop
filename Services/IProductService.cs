namespace EFCoreVezba.Services;

using EFCoreVezba.Dto;

public interface IProductService {
    void Add(AddProductDTO addProductDTO, string companyId);
    void IncreaseQuantity(IncreaseQuantityDTO dto, string companyId);
    void AddDiscount(string companyId, DiscountDTO dto);
}
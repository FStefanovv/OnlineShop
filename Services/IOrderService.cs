namespace EFCoreVezba.Services;

using EFCoreVezba.Dto;

public interface IOrderService {
    void Create(CreateOrderDTO dto, string userId, string userEmail);
    void Pay(string userId, OrderPaymentDTO dto);
}
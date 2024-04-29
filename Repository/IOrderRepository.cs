namespace EFCoreVezba.Repository;

using EFCoreVezba.Model;

public interface IOrderRepository {
    void Create(Order order);
    Order GetById(string id);
}
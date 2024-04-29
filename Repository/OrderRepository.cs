namespace EFCoreVezba.Repository;

using EFCoreVezba.Model;

public class OrderRepository : IOrderRepository {
    private readonly PostgresDbContext _context; 

    public OrderRepository(PostgresDbContext context) {
        _context = context;
    }

    public void Create(Order order){
        _context.Orders.Add(order);
        _context.SaveChanges();
    }

    public Order GetById(string id) {
        return _context.Orders.FirstOrDefault(o => o.Id == id);
    }

}
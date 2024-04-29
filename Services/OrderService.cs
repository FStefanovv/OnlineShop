namespace EFCoreVezba.Services;

using EFCoreVezba.Repository;
using EFCoreVezba.Dto;
using EFCoreVezba.Model;
using EFCoreVezba.Enums;
using EFCoreVezba.Exceptions;
using EFCoreVezba.EmailSender;

public class OrderService : IOrderService {
    private readonly IOrderRepository _orderRepository;
    private readonly IProductRepository _productRepository;
    private readonly IBankAccountService _bankAccountService;
    private readonly IEmailSender _emailSender;
    private readonly ILogger<OrderService> _logger;

    public OrderService(IOrderRepository orderRepository, IProductRepository productRepository,
                        IBankAccountService bankAccountService, IEmailSender emailSender,
                        ILogger<OrderService> logger) 
    {
        _orderRepository = orderRepository;
        _productRepository = productRepository;
        _bankAccountService = bankAccountService;
        _emailSender = emailSender;
        _logger = logger;
    }

    public void Create(CreateOrderDTO dto, string userId, string userEmail) {
        Product product = _productRepository.GetById(dto.ProductId);

        if(product == null) 
            throw new Exception("Product doesnt exist");

        if(product.Quantity < dto.Quantity)
            throw new Exception("Product quantity not sufficient for order");

        var unitPrice = product.GetUnitPrice();
        var totalPrice = (float)unitPrice * dto.Quantity;

        var order = new Order {
            OrdererId = userId,
            ProductId = dto.ProductId,
            Quantity = dto.Quantity,
            CompanyId = product.CompanyId,
            Currency = product.Company.BankAccount.Currency,
            OrderTime = DateTime.UtcNow,
            PricePerUnit = (float)unitPrice,
            TotalPrice = totalPrice,
            Status = OrderStatus.PENDING
        };


         product.Quantity -= dto.Quantity;
        _orderRepository.Create(order);

        //var messageForUser = _emailSender.GenerateOrderMessage(order, true);
        //_emailSender.SendEmail(userEmail, "Successful order", messageForUser);        
    }

    public void Pay(string userId, OrderPaymentDTO dto) {
        Order order = _orderRepository.GetById(dto.OrderId);

        if(order == null)
            throw new Exception("Order not found");
        if(order.OrdererId != userId)
            throw new ForbiddenActionException("Unauthorized access to request");
        if(order.Status != OrderStatus.PENDING)
            throw new Exception("Order resolved");

        order.Status = OrderStatus.COMPLETE;

        _bankAccountService.Transfer(userId, dto.BankAccountId, order.Company.BankAccount.Id, order.TotalPrice, false);
    }
}
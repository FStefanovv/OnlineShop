namespace EFCoreVezba.Dto;

public class CreateOrderDTO {
    public CreateOrderDTO(){}
    public string ProductId { get; set; }
    public uint Quantity { get; set; }
}
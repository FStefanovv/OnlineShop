namespace EFCoreVezba.Dto;

public class IncreaseQuantityDTO {
    public IncreaseQuantityDTO(){}

    public string ProductId { get; set; }
    public uint newQuantity { get; set; }
}
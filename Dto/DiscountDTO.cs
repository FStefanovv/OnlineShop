namespace EFCoreVezba.Dto;

public class DiscountDTO {
    public DiscountDTO(){}

    public string ProductId {get; set;}
    public double DiscountAmount {get; set;}
    public DateTime ValidUntil {get; set;}
}
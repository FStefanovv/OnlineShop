namespace EFCoreVezba.Dto;

public class AddProductDTO {
    public AddProductDTO(){}

    public string Name {get;set;}
    public uint Quantity {get; set;}
    public float UnitPrice {get; set;}
    public string Description {get;set;}
}
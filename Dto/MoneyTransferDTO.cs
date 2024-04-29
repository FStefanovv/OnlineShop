namespace EFCoreVezba.Dto;

public class MoneyTransferDTO {
    public MoneyTransferDTO(){}

    public string SourceAccountId {get; set;}
    public string DestinationAccountId {get; set;}
    public double Amount {get; set;}
}
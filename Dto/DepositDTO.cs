using EFCoreVezba.Enums;

namespace EFCoreVezba.Dto;


public class DepositDTO {
    public DepositDTO(){}

    public string BankAccountId {get; set;}
    public double Amount {get; set;}
    public Currency Currency {get; set;}
}
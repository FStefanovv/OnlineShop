using EFCoreVezba.Enums;

namespace EFCoreVezba.Dto;

public class CreateBankAccountDTO {
    public CreateBankAccountDTO(){}

    public Currency Currency {get; set;}
    public AccountType Type {get; set;}
}
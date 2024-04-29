namespace EFCoreVezba.Model;

using EFCoreVezba.Enums;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

public class BankAccount {
    public BankAccount(){}

    public BankAccount(Currency currency, AccountType type, string userId) {
        Balance = 0;
        Currency = currency;       
        if(type == AccountType.COMPANY) {
            CompanyId = userId;
            UserId = null; 
        }
        else {
            UserId = userId;
            CompanyId = null;
        }
        Active = true;
        Type = type;
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string Id {get; set;}
    public double Balance {get; set;}
    public Currency Currency {get; set;}
    public string UserId {get; set;}
    public string CompanyId {get; set;}
    public bool Active {get; set;}
    public AccountType Type {get; set; }
}
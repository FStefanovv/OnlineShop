namespace EFCoreVezba.Services;

using EFCoreVezba.Model;
using EFCoreVezba.Repository;
using EFCoreVezba.Utils;
using EFCoreVezba.Dto;
using EFCoreVezba.Exceptions;

public class BankAccountService: IBankAccountService {
    private readonly IBankAccountRepository _repository;

    public BankAccountService(){}

    public BankAccountService(IBankAccountRepository repository) {
        _repository = repository;
    }

    public string Create(string userId, CreateBankAccountDTO dto) {
        BankAccount bankAccount = new BankAccount(dto.Currency, dto.Type, userId);

        _repository.Create(bankAccount);

        return bankAccount.Id;
    }

    public BankAccount GetById(string id) {
        return _repository.GetById(id) ?? throw new Exception("Account not found");
    }
    

    public void Transfer(string userId, string sourceAccountId, string destinationAccountId, double amount, bool sourceCurrency){
        BankAccount sourceAccount = _repository.GetById(sourceAccountId) ?? throw new Exception("Source account not found");
        
        if(sourceAccount.UserId!=userId)
            throw new ForbiddenActionException("Unauthorized user access to bank account");

        BankAccount destinationAccount = _repository.GetById(destinationAccountId) ?? throw new Exception("Destination account no found");

        double sourceAmount = amount, destAmount = amount;

        if(sourceAccount.Currency!=destinationAccount.Currency) {
            if(!sourceCurrency) {
                sourceAmount =  CurrencyConversions.Convert(destinationAccount.Currency, sourceAccount.Currency, amount);
                destAmount = amount;
            }
            else {
                sourceAmount = amount;
                destAmount = CurrencyConversions.Convert(sourceAccount.Currency, destinationAccount.Currency, amount);
            }
        }

        if(sourceAmount>sourceAccount.Balance) throw new Exception("Not enough money");
            
        sourceAccount.Balance -= sourceAmount;
        destinationAccount.Balance += destAmount;

        _repository.SaveChanges();
    }

    public void Deposit(string? userId, string? userEmail, DepositDTO dto){
        if(dto.Amount<=0) throw new Exception("Deposit amount must be greater than 0");

        BankAccount bankAccount = _repository.GetById(dto.BankAccountId) ?? throw new Exception("Bank account not found");
        
        if(dto.Currency != bankAccount.Currency) {
            dto.Amount = CurrencyConversions.Convert(dto.Currency, bankAccount.Currency, dto.Amount);
        }

        bankAccount.Balance += dto.Amount;
        _repository.SaveChanges();
    }

    public void Withdraw(string userId, WithdrawalDTO dto) {
        BankAccount bankAccount = _repository.GetById(dto.AccountId) ?? throw new Exception("Bank account not found");
        
        if(userId != bankAccount.UserId) throw new Exception("User not authorized to perform withdrawal");

        if(dto.Amount > bankAccount.Balance) throw new Exception("Not enough money");


        bankAccount.Balance -= dto.Amount;
        _repository.SaveChanges();
    }

    public void Deactivate(string userId, string accountId){
        BankAccount bankAccount = _repository.GetById(accountId) ?? throw new Exception("Account not found");

        if(userId != bankAccount.UserId) throw new Exception("User unauthorized to perform deativation");

        bankAccount.Active = false;

        _repository.SaveChanges();
    }

}
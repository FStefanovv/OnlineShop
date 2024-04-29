using EFCoreVezba.Dto;
using EFCoreVezba.Model;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreVezba.Services;

public interface IBankAccountService {
    void Transfer(string userId, string sourceAccount, string destinationAccount, double amount, bool sourceCurrency);
    void Deposit(string? userId, string? userEmail, DepositDTO dto);
    void Withdraw(string userId, WithdrawalDTO dto);
    void Deactivate(string userId, string accountId);
    string Create(string userId, CreateBankAccountDTO dto);
    BankAccount GetById(string id);
}
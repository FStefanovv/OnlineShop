using EFCoreVezba.Model;

namespace EFCoreVezba.Repository;

public interface IBankAccountRepository {
    BankAccount? GetById(string id);
    void SaveChanges();
    void Create(BankAccount account);
}
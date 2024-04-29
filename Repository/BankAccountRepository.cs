namespace EFCoreVezba.Repository;

using EFCoreVezba.Model;

public class BankAccountRepository : IBankAccountRepository {
    private readonly PostgresDbContext _context;

    public BankAccountRepository(PostgresDbContext context) {
        _context = context;
    }

    public void SaveChanges(){
        _context.SaveChanges();
    }
    
    public BankAccount? GetById(string id){
        return _context.BankAccounts.Where(acc => acc.Id == id && acc.Active == true).FirstOrDefault();
    }

    public void Create(BankAccount account) {
        _context.BankAccounts.Add(account);
        _context.SaveChanges();
    }
}
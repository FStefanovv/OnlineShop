using EFCoreVezba.Dto;
using EFCoreVezba.Model;
using Microsoft.EntityFrameworkCore;

namespace EFCoreVezba.Repository;

public class UserRepository : IUserRepository
{
    private readonly PostgresDbContext _context;
    
    public UserRepository(PostgresDbContext context) {
        _context = context;
    }

    public async Task Register(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
    }

    public async Task<User> GetByEmail(string email) {
        return await _context.Users.Where(u => u.Email == email).FirstOrDefaultAsync();
    }
}
namespace EFCoreVezba.Repository;

using EFCoreVezba.Dto;
using EFCoreVezba.Model;

public interface IUserRepository {
    Task Register(User user);
    Task<User> GetByEmail(string email);
}
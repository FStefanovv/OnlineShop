namespace EFCoreVezba.Services;

using EFCoreVezba.Dto;
using EFCoreVezba.Model;

public interface IUserService {
    Task Register(User user);
    Task<string> Login(LoginDTO loginDTO);

}
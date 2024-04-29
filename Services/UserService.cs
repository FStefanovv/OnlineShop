namespace EFCoreVezba.Services;

using EFCoreVezba.Dto;
using EFCoreVezba.Model;
using EFCoreVezba.Repository;
using EFCoreVezba.Utils;

public class UserService : IUserService {
    private readonly IUserRepository _repository;
    private readonly JwtTokenGenerator _tokenGenerator;

    public UserService(IUserRepository repository, JwtTokenGenerator tokenGenerator){
        _repository = repository;
        _tokenGenerator = tokenGenerator;
    }

    public async Task<string> Login(LoginDTO loginDTO){
        User user = await _repository.GetByEmail(loginDTO.Email) ?? throw new Exception("No account associated with email");

        if(PasswordHasher.VerifyPassword(loginDTO.Password, user.Password)){
            return _tokenGenerator.Generate(user.Id, user.Email);
        }
        else throw new Exception("Wrong password");
    }

    public async Task Register(User user){
        await _repository.Register(user);
    }
}
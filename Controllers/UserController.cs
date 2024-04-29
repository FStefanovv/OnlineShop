namespace EFCoreVezba.Controller;

using Microsoft.AspNetCore.Mvc;

using EFCoreVezba.Model;
using EFCoreVezba.Services;
using EFCoreVezba.Dto;
using EFCoreVezba.Utils;
using EFCoreVezba.ApiKeyAuth;

[ApiController]
[Route("users")]
public class UserController : ControllerBase {
    private readonly IUserService _userService;
    private readonly IApiKeyRepository _apiKeyRepository;

    public UserController(IUserService userService, IApiKeyRepository apiKeyRepository) {
        _userService = userService;
        _apiKeyRepository = apiKeyRepository;
    }

    [HttpPost]
    [Route("register")]
    public async Task<ActionResult> RegisterUser([FromBody] UserDTO userDTO) {
        var hashedPassword = PasswordHasher.HashPassword(userDTO.Password);
        User user = new User(userDTO.FirstName, userDTO.LastName, userDTO.Email, userDTO.DateOfBirth.ToUniversalTime(), hashedPassword);

        try {
            await _userService.Register(user);
            return Ok("User successfully added");
        } catch (Exception ex) {
            return BadRequest(ex.Message);
        }
    }  

    [HttpPost]
    [Route("login")]
    public async Task<ActionResult> Login([FromBody] LoginDTO loginDTO) {
        try {
            var token = await _userService.Login(loginDTO);
            return Ok(token);
        } catch (Exception ex) {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    [Route("generate-api-key/{companyId}")]
    public async Task<ActionResult> GenerateApiKey(string companyId) {
        bool exists = _apiKeyRepository.ValidKeyExists(companyId);
        if(exists)
            return BadRequest("Valid api key already exists");
        else 
            return Ok(_apiKeyRepository.Create(companyId));
    }
}
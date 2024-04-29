namespace EFCoreVezba.Utils;

using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

public class JwtTokenGenerator {
    private readonly IConfiguration _configuration;

    public JwtTokenGenerator(IConfiguration configuration){
        _configuration = configuration;
    }

    public string Generate(string userId, string email){
         var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.Email, email),
                new Claim(ClaimTypes.NameIdentifier, userId)
            };
            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                "no_audience",
                claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: credentials);


            return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
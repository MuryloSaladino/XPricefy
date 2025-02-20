using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Server.Application.Config;
using Server.Domain.Contracts;

namespace Server.Application.Services;

public class AuthenticationService : IAuthenticationService
{
    public string SecretKey { get; private set; } = DotEnv.Get("SECRET_KEY");
    public int ExpireHours { get; private set; } = int.Parse(DotEnv.Get("EXPIRE_HOURS"));

    public string GenerateUserToken(string userId, string username)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(SecretKey);
        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity([ 
                new Claim("userId", userId),
                new Claim("username", username), 
            ]),
            
            Expires = DateTime.UtcNow.AddHours(ExpireHours),
            
            SigningCredentials = new(
                new SymmetricSecurityKey(key), 
                SecurityAlgorithms.HmacSha256Signature
            ),
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}


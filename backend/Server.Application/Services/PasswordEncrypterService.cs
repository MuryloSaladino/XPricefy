using Microsoft.AspNetCore.Identity;
using Server.Domain.Contracts;
using Server.Domain.Entities;

namespace Server.Application.Services;

public class PasswordEncrypterService : IPasswordEncrypter
{
    private readonly PasswordHasher<User> hasher = new();

    public string Hash(User user)
    {
        return hasher.HashPassword(user, user.Password);
    }

    public bool Matches(User user, string password)
    {
        var result = hasher.VerifyHashedPassword(user, user.Password, password);
        return result == PasswordVerificationResult.Success;
    }
}
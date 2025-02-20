namespace Server.Domain.Contracts;

public interface IAuthentication
{
    string GenerateUserToken(string userId, string username);
}
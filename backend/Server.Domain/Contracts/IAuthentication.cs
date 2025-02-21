using Server.Domain.Common;

namespace Server.Domain.Contracts;

public interface IAuthentication
{
    string GenerateUserToken(string userId, string username);
    UserSession ExtractToken(string token);
}
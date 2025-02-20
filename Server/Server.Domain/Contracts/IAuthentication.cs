namespace Server.Domain.Contracts;

public interface IAuthenticationService {
    string GenerateUserToken(string userId, string username);
}
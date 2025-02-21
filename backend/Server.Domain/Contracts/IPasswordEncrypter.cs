using Server.Domain.Entities;

namespace Server.Domain.Contracts;

public interface IPasswordEncrypter
{
    string Hash(User user);
    bool Matches(User user, string password);
}
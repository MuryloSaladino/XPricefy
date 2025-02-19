using Server.Domain.Entities;

namespace Server.Application.Repository.Users;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User?> GetByUsername(string username, CancellationToken cancellationToken);
}
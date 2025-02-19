using Server.Domain.Entities;

namespace Server.Application.Repository.UserRepository;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User?> GetByUsername(string username, CancellationToken cancellationToken);
}
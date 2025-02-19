using Microsoft.EntityFrameworkCore;
using Server.Application.Repository.Users;
using Server.Domain.Entities;
using Server.Persistence.Context;

namespace Server.Persistence.Repository.Users;

public class UserRepository(XpricefyContext xpricefyContext)
    : BaseRepository<User>(xpricefyContext), IUserRepository
{
    public Task<User?> GetByUsername(string username, CancellationToken cancellationToken)
        => context
            .Set<User>()
            .FirstOrDefaultAsync(user => user.Username == username, cancellationToken);
}
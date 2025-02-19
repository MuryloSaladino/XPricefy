using Microsoft.EntityFrameworkCore;
using Server.Application.Repository;
using Server.Domain.Common;
using Server.Persistence.Context;

namespace Server.Persistence.Repository;

public class BaseRepository<TEntity>(XpricefyContext xpricefyContext) : IBaseRepository<TEntity>
    where TEntity : BaseEntity
{
    protected readonly XpricefyContext context = xpricefyContext;


    public void Create(TEntity entity)
        => context.Add(entity);

    public void Update(TEntity entity)
        => context.Update(entity);

    public Task<TEntity?> Get(Guid id, CancellationToken cancellationToken)
        => context.Set<TEntity>().FirstOrDefaultAsync(entity => entity.Id == id, cancellationToken);

    public Task<List<TEntity>> GetAll(CancellationToken cancellationToken)
        => context.Set<TEntity>().ToListAsync(cancellationToken);

    public void Delete(TEntity entity)
    {
        entity.DeletedAt = DateTime.Now;
        context.Update(entity);
    }
}
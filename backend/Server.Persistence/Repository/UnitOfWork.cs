using Server.Application.Repository;
using Server.Persistence.Context;

namespace Server.Persistence.Repository;

public class UnitOfWork(XpricefyContext ctx) : IUnitOfWork
{
    private readonly XpricefyContext context = ctx;
    
    public Task Save(CancellationToken cancellationToken)
    {
        return context.SaveChangesAsync(cancellationToken);
    }
}
using Microsoft.EntityFrameworkCore;
using Server.Application.Repository.Products;
using Server.Domain.Entities;
using Server.Persistence.Context;

namespace Server.Persistence.Repository.Products;

public class ProductRepository(XpricefyContext xpricefyContext)
    : BaseRepository<Product>(xpricefyContext), IProductRepository
{
    public async Task<List<Product>> GetProductsByPrice(CancellationToken cancellationToken)
        => await context
            .Set<Product>()
            .OrderByDescending(p => p.Price)
            .ToListAsync(cancellationToken);

    public async Task<Product?> GetProductWithHistory(Guid id, CancellationToken cancellationToken)
        => await context
            .Set<Product>()
            .Include(p => p.ProductHistories)
            .FirstOrDefaultAsync(p => p.Id == id && p.DeletedAt == null, cancellationToken);
}
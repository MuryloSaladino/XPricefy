using Server.Domain.Entities;

namespace Server.Application.Repository.Products;

public interface IProductRepository : IBaseRepository<Product>
{
    Task<Product?> GetProductWithHistory(Guid id, CancellationToken cancellationToken);
}
using Server.Domain.Entities;

namespace Server.Application.Repository.Products;

public interface IProductRepository : IBaseRepository<Product>
{
    Task<List<Product>> GetProductsByPrice(CancellationToken cancellationToken);
    Task<Product?> GetProductWithHistory(Guid id, CancellationToken cancellationToken);
}
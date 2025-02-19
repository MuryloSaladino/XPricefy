using Server.Application.Repository.Products;
using Server.Domain.Entities;
using Server.Persistence.Context;

namespace Server.Persistence.Repository.Products;

public class ProductRepository(XpricefyContext xpricefyContext) 
    : BaseRepository<Product>(xpricefyContext), IProductRepository
{ }
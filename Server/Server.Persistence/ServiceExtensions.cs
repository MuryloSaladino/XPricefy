using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Server.Application.Repository;
using Server.Application.Repository.Products;
using Server.Application.Repository.Users;
using Server.Persistence.Context;
using Server.Persistence.Repository;
using Server.Persistence.Repository.Products;
using Server.Persistence.Repository.Users;

namespace Skills.Persistence;

public static class ServiceExtensions
{
    public static void ConfigurePersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var connection = configuration.GetConnectionString("XpricefyContext");
        services.AddDbContext<XpricefyContext>(opt => opt.UseSqlServer(connection));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IProductHistoryRepository, ProductHistoryRepository>();
    }
}
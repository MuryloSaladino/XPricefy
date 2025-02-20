using AutoMapper;
using Server.Domain.Entities;

namespace Server.Application.Features.Products.FindAll;

public sealed class FindAllProductsMapper : Profile
{
    public FindAllProductsMapper()
    {
        CreateMap<Product, FindAllProductsResponse>();
    }
}
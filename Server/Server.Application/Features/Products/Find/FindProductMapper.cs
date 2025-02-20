using AutoMapper;
using Server.Domain.Entities;

namespace Server.Application.Features.Products.Find;

public sealed class FindProductMapper : Profile
{
    public FindProductMapper()
    {
        CreateMap<Product, FindProductResponse>();
    }
}
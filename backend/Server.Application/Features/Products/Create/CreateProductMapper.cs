using AutoMapper;
using Server.Domain.Entities;

namespace Server.Application.Features.Products.Create;

public sealed class CreateProductMapper : Profile
{
    public CreateProductMapper()
    {
        CreateMap<CreateProductRequest, Product>();
        CreateMap<Product, CreateProductResponse>();
    }
}
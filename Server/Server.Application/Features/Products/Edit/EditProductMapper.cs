using AutoMapper;
using Server.Domain.Entities;

namespace Server.Application.Features.Products.Edit;

public sealed class EditProductMapper : Profile
{
    public EditProductMapper()
    {
        CreateMap<EditProductRequest, Product>();
        CreateMap<Product, EditProductResponse>();
    }
}
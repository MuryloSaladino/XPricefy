using AutoMapper;
using Server.Domain.Entities;

namespace Server.Application.Features.Products.Find;

public sealed class FindProductMapper : Profile
{
    public FindProductMapper()
    {
        CreateMap<Product, FindProductResponse>()
            .ForMember(dest => dest.ProductHistories, opt => opt.MapFrom(src => src.ProductHistories));

        CreateMap<ProductHistory, ProductHistoryResponse>()
            .ForMember(dest => dest.Action, opt => opt.MapFrom(src => src.Action));
    }
}
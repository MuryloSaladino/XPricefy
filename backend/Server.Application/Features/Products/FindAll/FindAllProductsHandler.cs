using AutoMapper;
using MediatR;
using Server.Application.Repository.Products;

namespace Server.Application.Features.Products.FindAll;

public sealed class FindAllProductsHandler(
    IProductRepository productRepository,
    IMapper mapper
) : IRequestHandler<FindAllProductsRequest, List<FindAllProductsResponse>>
{
    private readonly IProductRepository productRepository = productRepository;
    private readonly IMapper mapper = mapper;

    public async Task<List<FindAllProductsResponse>> Handle(
        FindAllProductsRequest request, CancellationToken cancellationToken)
    {
        var products = await productRepository.GetProductsByPrice(cancellationToken);
        return mapper.Map<List<FindAllProductsResponse>>(products);
    }
}